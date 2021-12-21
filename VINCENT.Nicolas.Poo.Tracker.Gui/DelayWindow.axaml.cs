using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Gui
{
    public partial class DelayWindow : UserControl
    {

        TextBlock _name;
        TextBlock _delay;


        public DelayWindow()
        {
            InitializeComponent();
            LocateControls();
#if DEBUG

#endif
        }

        private void LocateControls()
        {
            _delay = this.FindControl<TextBlock>("Delay");
            _name = this.FindControl<TextBlock>("AssemblyName");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

       
        public DelayViewModel ViewModel
        {

            init 
            {
                _name.Text = value.Name;
                _delay.Text = value.Delay;
            
            }
        }


       


        
    }

}

