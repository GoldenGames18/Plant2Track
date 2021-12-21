using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Gui
{
    public partial class TaskWindow :  UserControl
    {

        private TextBlock _assembly;
        private TextBlock _task;
        private TextBlock _date;
        private TextBlock _delay;
        private TextBlock _statut;


        private Button _effectiveDateStart;
        private Button _effectiveDateEnd;


        private Border _stackPanel;
        public Task _taskData;



        public event EventHandler<Task> StartTask;
        public event EventHandler<Task> EndTask;

        

        public TaskWindow()
        {
            InitializeComponent();
            LocateControls();
#if DEBUG
            
#endif
        }

        private void LocateControls()
        {
            _assembly = this.FindControl<TextBlock>("Assembly");
            _task = this.FindControl<TextBlock>("Task");
            _date = this.FindControl<TextBlock>("Date");
            _delay = this.FindControl<TextBlock>("Delay");
            _statut = this.FindControl<TextBlock>("Statut");

            _effectiveDateEnd = this.FindControl<Button>("DateEnd");
            _effectiveDateStart = this.FindControl<Button>("DateStart");

            _stackPanel = this.FindControl<Border>("Border");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void Click_Start(object? sender, RoutedEventArgs args)
        {
          
            StartTask?.Invoke(this, _taskData);
        }

        private void Click_End(object? sender, RoutedEventArgs args)
        {
            
            EndTask?.Invoke(this, _taskData);
        }


        public TaskViewModel ViewModel
        {
            init
            {
                _assembly.Text = value.Chantier;
                _date.Text = value.Date;
                _statut.Text = string.Format("Statut : {0}", value.Statut);
                DelayColor(value);
                _task.Text = value.Description;
                LockButton(value);
                _taskData = value.Task;
            }


        }

        private void LockButton(TaskViewModel value)
        {
            if (value.EffectiveDateStart == default)
            {
                _effectiveDateStart.Content = "Commencer";
                _effectiveDateEnd.Content = "Terminer";
                _effectiveDateEnd.IsEnabled = false;
            }
            else if (value.EffectiveDateEnd == default)
            {
                _effectiveDateStart.Content = string.Format("Commencer le {0}", value.EffectiveDateStart.ToString("dd-MM-yyyy"));
                _effectiveDateStart.IsEnabled = false;
                _effectiveDateEnd.Content = "Terminer";
            }
            else if (value.EffectiveDateEnd != default && value.EffectiveDateStart != default)
            {
                _effectiveDateStart.Content = string.Format("Commencer le {0}", value.EffectiveDateStart.ToString("dd-MM-yyyy"));
                _effectiveDateStart.IsEnabled = false;
                _effectiveDateEnd.Content = string.Format("Terminer le {0}", value.EffectiveDateEnd.ToString("dd-MM-yyyy"));
                _effectiveDateEnd.IsEnabled = false;

            }
        }

        private void DelayColor(TaskViewModel value)
        {
            if (value.Delay > 0)
            {
                _stackPanel.Background = new SolidColorBrush(Colors.IndianRed);
                _delay.Text = string.Format("Jour de retard :  {0} jour ", value.Delay);

            }
            else
            {
                _stackPanel.Background = new SolidColorBrush(Colors.LightGreen);
                _delay.Text = string.Format("Jour de retard :  {0} jour ", value.Delay);

            }
        }
    }
}
