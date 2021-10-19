using ArcadeCubeSimulator.classes;
using ArcadeCubeSimulator.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using ArcadeCubeSimulator.classes.main;
using ArcadeCubeSimulator.classes.Snake;
using ArcadeCubeSimulator.classes.anvildrop;
using System.Windows.Threading;

namespace ArcadeCubeSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Snake_Click(object sender, RoutedEventArgs e)
        {
            SnakeWindow snakeWindow = new SnakeWindow();
            this.Hide();
            snakeWindow.ShowDialog();
            this.Show();
        }

        private void Anvil_Click(object sender, RoutedEventArgs e)
        {
            AnvildropWindow anvildropWindow = new AnvildropWindow();
            this.Hide();
            anvildropWindow.ShowDialog();
            this.Show();
        }
    }
}
