using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ArcadeCubeSimulator.classes.main
{
    public static class GameTimers
    {
        private static DispatcherTimer _snakeTimer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromMilliseconds(500)
        };

        public static DispatcherTimer SnakeTimer
        {
            get { return _snakeTimer; }
            set { _snakeTimer = value; }
        }

        private static DispatcherTimer _anvildropTimer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromMilliseconds(500)
        };
        

        public static DispatcherTimer AnvildropTimer
        {
            get { return _snakeTimer; }
            set { _snakeTimer = value; }
        }
    }
}
