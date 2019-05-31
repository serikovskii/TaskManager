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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskManager.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitTaskManager();
        }

        public void InitTaskManager()
        {
            var processes = Process.GetProcesses();
            processesName.ItemsSource = processes;
        }

        private void RemoveProcesses(object sender, RoutedEventArgs e)
        {
            var processes = Process.GetProcesses();
            var sort = processesName.SelectedIndex;
            if (sort != -1)
            {
                var procRemove = Process.GetProcessesByName(processes[sort].ProcessName);
                foreach (var proc in procRemove)
                {
                    proc.Kill();
                }
                MessageBox.Show($"{processes[sort].ProcessName} - удалили");
                InitTaskManager();
            }
            else
                MessageBox.Show("Выберете задачу");
        }

    }
}
