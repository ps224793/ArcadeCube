using System;
using System.Collections.Generic;
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
using ArcadeCubeSimulator.classes.anvildrop;
using ArcadeCubeSimulator.classes.main;
using ArcadeCubeSimulator.enums;

namespace ArcadeCubeSimulator
{
    /// <summary>
    /// Interaction logic for AnvildropWindow.xaml
    /// </summary>
    public partial class AnvildropWindow : Window
    {
        private LedCube _ledCube = new LedCube();
        private Random _random = new Random();

        private Anvildrop _anvildrop;

        public AnvildropWindow()
        {
            DataContext = _ledCube;
            InitializeComponent();
            _anvildrop = new Anvildrop(_ledCube, _random);
            GameTimers.AnvildropTimer.Tick += Anvildrop_Tick;          
        }

        private void Anvildrop_Tick(object sender, EventArgs e)
        {
            _anvildrop.DropAnvils();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            GameTimers.AnvildropTimer.Start();
        }

        private void MovePlayer(object sender, KeyEventArgs e)
        {
            
        }
    }
}
