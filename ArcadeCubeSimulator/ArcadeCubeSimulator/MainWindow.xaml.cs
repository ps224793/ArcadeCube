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

namespace ArcadeCubeSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LedCube _ledCube = new LedCube();

        private SnakeGame snakeGame;


        public LedCube MyLedCube
        {
            get { return _ledCube; }
            set { _ledCube = value; }
        }

        public MainWindow()
        {
            DataContext = MyLedCube;
            InitializeComponent();

            snakeGame = new SnakeGame(_ledCube);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            byte[] array  = MyLedCube.Value;
        }

        private void MovesetSnake(object sender, KeyEventArgs e)
        {
            snakeGame.Snakekey(sender, e);
        }
    }
}
