using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using VINCENT.Nicolas.Poo.Tracker.Controllers;
using VINCENT.Nicolas.Poo.Tracker.Datas;
using VINCENT.Nicolas.Poo.Tracker.Domains;


namespace VINCENT.Nicolas.Poo.Tracker.Gui
{
    public class App : Application
    {
        
        private MainWindow _mainWindow;
       
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = CreateMainWindow();
            }
            base.OnFrameworkInitializationCompleted();
        }

        private Window CreateMainWindow()
        {
            _mainWindow = new MainWindow();
            _mainWindow.Opened += MainWindow_Opened;
            return _mainWindow;
        }
        private void MainWindow_Opened(object? sender, EventArgs e)
        {
            var factory = new Domains.LoginFactory();

            var loginWindow = new LoginWindow
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                SystemDecorations = SystemDecorations.BorderOnly,
                Factory = factory
            };

            var loginController = CreateLoginControlleur(factory.NewLogin);

            loginWindow.QuitRequested += loginController.OnQuitRequested;
            loginWindow.LoginRequested += loginController.VerifyConnection;
            loginWindow.CommitLogin += CommitLogin;
            
           
            loginWindow.ShowDialog(sender as Window);

           
        }

        

        private void CommitLogin(object sender, Login e) 
        {
            var repository = new SetTaskRepository()
            {
                new List<Task>(new AllData().TakeTaskUserConnected(e.Code))
            };
            _mainWindow.Tasks = repository;
            
       
            var controlleur = new MainControlleur(repository);
            _mainWindow.Filter += controlleur.Affect;

            
            
          
        }

        

        private LoginControlleur CreateLoginControlleur(Func<string, string, Login> newLogin)
        {
            var controller = new LoginControlleur(newLogin);
            controller.AboutToQuit += Superviseur_AboutToQuit;
            return controller;
        }

       

        private void Superviseur_AboutToQuit(object? sender, EventArgs e)
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.Shutdown(0);
            }
        }
    }
}
