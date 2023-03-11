using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;

namespace SystemPr1
{
    public partial class MainWindow : Window
    {
        DispatcherTimer TimerOfThreads = new();

        public MainWindow()
        {
            InitializeComponent();

            ShowProcesses();
            RunTimer();
        }
        
        public void RunTimer()
        {
            TimerOfThreads.Interval = new TimeSpan(0, 0, 2);
            TimerOfThreads.Tick += timer_Tick;
            TimerOfThreads.Start();
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            ShowProcesses();
        }



        public class MyProcess
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public int HandleCount { get; set; }
            public int ThreadsCount { get; set; }
            public override string ToString()
            {
                return $"{Name}";
            }

        }

        public void ShowProcesses()
        {

            int counter = 0;
            List<MyProcess> Processes = new();
            var processes = Process.GetProcesses().ToList();
            for (int i = 0; i < processes.Count; i++)
            {
                Processes.Add(new MyProcess() { Name = processes[i].ProcessName, HandleCount = processes[i].HandleCount, Id = processes[i].Id, ThreadsCount = processes[i].Threads.Count });
                counter += processes[i].Threads.Count;
            }

            processesList.ItemsSource = Processes;
            NumberofThreads.Content = $" {counter}";

        }

        

        private void Button_Click_Add_List(object sender, RoutedEventArgs e)
        {
            ShowProcesses();
            RunTimer();
        }

        private void Button_Click_End_Task(object sender, RoutedEventArgs e)
        {
            TimerOfThreads.Interval = new TimeSpan(0, 0, 5);
            NumberofThreads.Content = " Choose Task!";
            TimerOfThreads.Interval = new TimeSpan(0, 0, 1);
            if (processesList.SelectedValue != null)
            {
                Process[] prs = Process.GetProcesses();
                foreach (Process process in prs)
                {
                    if (process.ProcessName == processesList.SelectedItem.ToString())
                    {
                        process.Kill();
                    }
                }
                ShowProcesses();

            }
        }

        private void Button_Click_Run_new_Task(object sender, RoutedEventArgs e)
        {
            RunningNewTask window = new();
            window.ShowDialog();
        }

        private void Button_Click_Add_to_Blacklist(object sender, RoutedEventArgs e)
        {
            AddingToBlacklist form = new();
            form.ShowDialog();
        }
    }
}

