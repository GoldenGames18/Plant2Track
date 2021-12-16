using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using VINCENT.Nicolas.Poo.Tracker.Controllers;
using VINCENT.Nicolas.Poo.Tracker.Domains;


namespace VINCENT.Nicolas.Poo.Tracker.Gui
{
    public partial class MainWindow : Window, IMainView
    {
        WrapPanel _taskView;

        ComboBox _filter;
        ComboBox _tri;

        TextBox _valueFilter;


        DatePicker _startDate;
        DatePicker _endDate;
        ComboBox _genrateGraph;
 

        public event EventHandler<List<string>> Filter;
        public event EventHandler<List<string>> Graph;

        private ITaskRepository _repository;
        private ITaskRepository _copyPlanning;

        public ITaskRepository Tasks
        {
            get => _repository;
            set
            {
                _repository = value;
                _copyPlanning = value;
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
            PlotDiagram();


#endif
        }

        private void LocateControl()
        {
            _taskView = this.FindControl<WrapPanel>("TaskList");

            _tri = this.FindControl<ComboBox>("Tri");
            _filter = this.FindControl<ComboBox>("Filter");

            _valueFilter = this.FindControl<TextBox>("ValueFilter");


            _endDate = this.FindControl<DatePicker>("End");
            _startDate = this.FindControl<DatePicker>("Start");
            _genrateGraph = this.FindControl<ComboBox>("Graph");

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void Repository_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (NotifyCollectionChangedAction.Reset != e.Action) return;

            _taskView.Children.Clear();
            foreach (var vm in _repository)
            {
                var mainWindow = new TaskWindow { ViewModel = new TaskViewModel(vm) };
                var controlleur = new TaskController(Tasks);
                mainWindow.StartTask += controlleur.AffectDateTaskStart;
                mainWindow.EndTask += controlleur.AffectDateTaskEnd;
                _taskView.Children.Add(mainWindow);
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
            List<string> save = new();
            DateTimeOffset? dateStart = _startDate.SelectedDate;
            var start = dateStart.Value.DateTime;
            save.Add(start.ToString("yyyy-MM-dd"));


            DateTimeOffset? dateEnd = _endDate.SelectedDate;
            var end = dateEnd.Value.DateTime;
            save.Add(end.ToString("yyyy-MM-dd"));

            save.Add(_genrateGraph.SelectedIndex + "");

            Graph(this, save);

        }

        private void PlotDiagram()
        {
           // var plotContainer = this.FindControl<AvaPlot>("PlotContainer");
            //var mainPlot = new Plot();
            

            double[] dataX = new double[] { 1, 2, 3, 4, 5 };
            double[] dataZ = new double[] { 5, 10, 15, 20, 100 };


            //var bars = mainPlot.AddBar(dataZ, dataX);

            DateTime dateTime = new(2021, 12, 12);
            int month = dateTime.Month;

    

            //plotContainer.Reset(mainPlot);
            //plotContainer.Refresh();
            

        }


    }
}
