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
        private LedCube _ledCube = new LedCube();
        private Anvildrop _anvildrop;
        private SnakeGame snakeGame;

        public DispatcherTimer _snakeTimer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromMilliseconds(1000)
        };

        public LedCube MyLedCube
        {
            get { return _ledCube; }
            set { _ledCube = value; }
        }

        public MainWindow()
        {
            DataContext = MyLedCube;
            InitializeComponent();
            _snakeTimer.Tick += _snakeTimer_Tick;
            _snakeTimer.Start();
        }


        private void _snakeTimer_Tick(object sender, EventArgs e)
        {
            if(snakeGame != null)
            {
                snakeGame.MoveSnake();
            }
            if(_anvildrop != null)
            {
                _anvildrop.DropAnvils();
            }
        }

        private void MovesetSnake(object sender, KeyEventArgs e)
        {
            if(snakeGame != null)
            {
                snakeGame.Snakekey(sender, e);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            byte[] array  = MyLedCube.Value;
        }

        private void Snake_Click(object sender, RoutedEventArgs e)
        {

            _anvildrop = null;
            snakeGame = new SnakeGame(_ledCube);
        }

        private void Anvil_Click(object sender, RoutedEventArgs e)
        {
            snakeGame = null;
            _anvildrop = new Anvildrop(_ledCube, new Random());
        }
    }
}
