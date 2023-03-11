using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
    public partial class RunningNewTask : Window
    {
        public RunningNewTask()
        {
            InitializeComponent();   
        }

        private void Button_Click_Submit(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != "")
            {
                Process.Start($"{textBox.Text}.exe");
                this.Close();
            }
            else
                this.Close();
        }
    }
}
