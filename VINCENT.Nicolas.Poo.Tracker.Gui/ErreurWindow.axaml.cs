using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Gui
{
    public partial class ErreurWindow : Window
    {

        TextBlock _erreur;

       
       
        


        public ErreurWindow()
        {
            InitializeComponent();
            LocateControls();
#if DEBUG
            this.AttachDevTools();
#endif
        }


          public string Erreur { set { _erreur.Text = value; } }
      

        private void LocateControls()
        {
            _erreur = this.FindControl<TextBlock>("Erreur");
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

        }

        
    }
}
