using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ScottPlot;
using ScottPlot.Avalonia;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using VINCENT.Nicolas.Poo.Tracker.Controllers;
using VINCENT.Nicolas.Poo.Tracker.Datas;
using VINCENT.Nicolas.Poo.Tracker.Domains;


namespace VINCENT.Nicolas.Poo.Tracker.Gui
{
    public partial class MainWindow : Window, IMainView
    {
        WrapPanel _taskView;
        WrapPanel _delay;

        ComboBox _filter;
        ComboBox _tri;

        TextBox _valueFilter;


        DatePicker _startDate;
        DatePicker _endDate;
        ComboBox _genrateGraph;

        AvaPlot _plotContainer;

        TextBlock _erreurDate;

        
        public JsonRepositoty Json { get; set; }
        


        public event EventHandler<List<string>> Filter;
        public event EventHandler<List<string>> Graph;

        private ITaskRepository _repository;

        public ITaskRepository Tasks
        {
            get => _repository;
            set
            {
                _repository = value;
                _repository.SortDate();
                _repository.CollectionChanged += Repository_CollectionChanged;
            }

            
        }

        public MainWindow()
        {
            InitializeComponent();
            LocateControl();
#if DEBUG
            this.AttachDevTools();
            


#endif
        }

        private void LocateControl()
        {
            _taskView = this.FindControl<WrapPanel>("TaskList");
            _delay = this.FindControl<WrapPanel>("Delay");
            _tri = this.FindControl<ComboBox>("Tri");
            _filter = this.FindControl<ComboBox>("Filter");
            _valueFilter = this.FindControl<TextBox>("ValueFilter");
            _endDate = this.FindControl<DatePicker>("End");
            _startDate = this.FindControl<DatePicker>("Start");
            _genrateGraph = this.FindControl<ComboBox>("Graph");
            _plotContainer = this.FindControl<AvaPlot>("PlotContainer");
            _erreurDate = this.FindControl<TextBlock>("erreurDate");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void Repository_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (NotifyCollectionChangedAction.Reset != e.Action) return;

            _taskView.Children.Clear();
            UpdateTask();
            _repository.CreateGraph(_repository.Start, _repository.End, _repository.Value);
            UpdatePlot();
            GenerateDelay();

        }

        private void UpdateTask()
        {
            foreach (var vm in _repository)
            {
                var mainWindow = new TaskWindow { ViewModel = new TaskViewModel(vm) };
                var controlleur = new TaskController(Tasks, Json);
                mainWindow.StartTask += controlleur.AffectDateTaskStart;
                mainWindow.EndTask += controlleur.AffectDateTaskEnd;
                _taskView.Children.Add(mainWindow);
            }
        }

        private void GenerateDelay()
        {
            var delay = _repository.ExtractAssembly();
            _delay.Children.Clear();
            foreach (var item in delay)
            {
                var mainWindow = new DelayWindow { ViewModel = new DelayViewModel(item.Value) };
                _delay.Children.Add(mainWindow);
            }
        }

        private void Click_Filter(object? sender, RoutedEventArgs args)
        {

            List<string> save = new();
            save.Add(_tri.SelectedIndex + "");
            save.Add( _filter.SelectedIndex +"");
            save.Add(_valueFilter.Text);
            Filter(this, save);
            _valueFilter.Clear();

        }



        private void Click_Graph(object? sender, RoutedEventArgs args) 
        {
            DateTimeOffset? dateStart = _startDate.SelectedDate;
            DateTimeOffset? dateEnd = _endDate.SelectedDate;
            if (dateStart != null && dateEnd !=null)
            {
                GenerateGraph(dateStart, dateEnd);
            }
            else
            {
                _erreurDate.Text = "Un des champ est vide merci de le compléter ";
            }
        }

        private void GenerateGraph(DateTimeOffset? dateStart, DateTimeOffset? dateEnd)
        {
            try
            {
                List<string> save = new();
                SaveFilter(dateStart, dateEnd, save);
                Graph(this, save);
                _erreurDate.Text = "";
            }
            catch (Exception ex)
            {
                _erreurDate.Text = ex.Message;

            }
        }

        private void SaveFilter(DateTimeOffset? dateStart, DateTimeOffset? dateEnd, List<string> save)
        {
            var start = dateStart.Value.DateTime;
            var end = dateEnd.Value.DateTime;
            save.Add(start.ToString("yyyy-MM-dd"));
            save.Add(end.ToString("yyyy-MM-dd"));
            save.Add(_genrateGraph.SelectedIndex + "");
        }

        private void UpdatePlot()
        {
            var mainPlot = new Plot();
            mainPlot.AddBar(_repository.TabValue, _repository.TabIndex);
            _plotContainer.Reset(mainPlot);
            _plotContainer.Refresh();
            _startDate.SelectedDate = new DateTimeOffset(_repository.Start);
            _endDate.SelectedDate = new DateTimeOffset(_repository.End);
        }

        

        


    }
}
