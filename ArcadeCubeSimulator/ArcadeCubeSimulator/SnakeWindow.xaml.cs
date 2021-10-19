using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using ArcadeCubeSimulator.classes.main;
using ArcadeCubeSimulator.classes.Snake;
using ArcadeCubeSimulator.enums;

namespace ArcadeCubeSimulator
{
    /// <summary>
    /// Interaction logic for SnakeWindow.xaml
    /// </summary>
    public partial class SnakeWindow : Window
    {

        private LedCube _ledCube = new LedCube();
        private SnakeGame _snakeGame;


        public SnakeWindow()
        {
            DataContext = _ledCube;
            InitializeComponent();
            _snakeGame = new SnakeGame(_ledCube);
            GameTimers.SnakeTimer.Tick += _snakeTimer_Tick;
        }


        private void _snakeTimer_Tick(object sender, EventArgs e)
        {
           _snakeGame.MoveSnake();
        }

        private void MovesetSnake(object sender, KeyEventArgs e)
        {
            _snakeGame.Snakekey(sender, e);
        }

        private void Start_CLick(object sender, RoutedEventArgs e)
        {
            GameTimers.SnakeTimer.Start();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            GameTimers.SnakeTimer.Stop();
        }
    }
}
