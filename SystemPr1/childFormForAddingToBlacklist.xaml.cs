using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SystemPr1
{
    public partial class AddingToBlacklist : Window
    {
        public AddingToBlacklist()
        {
            InitializeComponent();
        }
        static List<string> Elems = new();

        private void Button_Click_Submit(object sender, RoutedEventArgs e)
        {
            if (Tb.Text != "")
            {
                //Process pr = new Process();
                //pr.StartInfo.FileName = Tb.Text;
                //pr.Start();
                //Thread.Sleep(2000);
                //pr.Kill();

                int counter = 0;
                for (int i = 0; i < Elems.Count; i++)
                {
                    if (Elems[i] != Tb.Text)
                    {
                        counter++;
                    }
                }


                if (counter == Elems.Count)
                {
                    EnterName.Foreground = Brushes.White;
                    EnterName.Content = "Enter Name:";
                    
                    Process.Start($"{Tb.Text}");
                    Process[] procs = Process.GetProcesses();

                    foreach (Process process in procs)
                    {
                        if (process.ProcessName == Tb.Text)
                        {
                            Thread.Sleep(2000);
                            process.Kill();
                        }
                    }
                }
                else if (counter != Elems.Count)
                {
                    EnterName.Foreground = Brushes.Red;
                    EnterName.Content = "ERROR!!!";
                }
                
            }
            this.Close();
        }
    }
}
