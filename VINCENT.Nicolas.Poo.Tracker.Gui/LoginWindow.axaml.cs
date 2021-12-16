using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Gui
{
    public partial class LoginWindow : Window
    {

        private TextBox _code;
        private TextBox _mdps;
        private TextBlock _error;

        private ILoginView _login;

        public ILoginView Factory
        {
            get => _login;
            init
            {
                _login = value;
                _login.PropertyChanged += (o, e) => Close();
            }
        }
  


        public LoginWindow()
        {
            InitializeComponent();
            LocateControls();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        public event EventHandler QuitRequested;
        public event EventHandler<Login> LoginRequested;
        public event EventHandler<Login> CommitLogin;

        private void LocateControls()
        {
            _code = this.FindControl<TextBox>("Login");
            _mdps = this.FindControl<TextBox>("Mdps");
            _error = this.FindControl<TextBlock>("Error");
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

        }

        private void Click_Leave(object? sender, RoutedEventArgs args)
        {
            QuitRequested(this, EventArgs.Empty);
        }

        private void Click_Login(object? sender, RoutedEventArgs args)
        {
            try
            {
                LoginRequested(this, new Login(_code.Text, _mdps.Text));
                CommitLogin(this, new Login(_code.Text, _mdps.Text));
            }
            catch (Exception ex)
            {
                errorMessage(ex.Message);
            }
        }

        private void errorMessage(string error)
        {
            _error.Text = error;
            
        }
    }
}
