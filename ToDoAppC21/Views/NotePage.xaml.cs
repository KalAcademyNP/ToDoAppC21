using ToDoAppC21.Models;

namespace ToDoAppC21.Views;
[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    public string ItemId { 
        set { 
            LoadNote(value); 
        } }
    public NotePage()
	{
		InitializeComponent();
        var randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
        LoadNote(Path.Combine(FileSystem.AppDataDirectory, randomFileName));
	}

    private void LoadNote(string fileName)
    {
        var noteModel = new Note
        {
            Filename = fileName,
        };
        if (File.Exists(fileName))
        {
            noteModel.Text = File.ReadAllText(fileName);
            noteModel.Date = File.GetCreationTime(fileName);
        }
        BindingContext = noteModel;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
        {
            File.WriteAllText(note.Filename, TextEditor.Text);
        }
        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
        {
            File.Delete(note.Filename);
        }
        await Shell.Current.GoToAsync("..");
    }
}