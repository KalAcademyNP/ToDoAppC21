﻿namespace ToDoAppC21
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.NotesPage),
                typeof(Views.NotesPage));
        }
    }
}
