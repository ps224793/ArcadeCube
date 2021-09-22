using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using ArcadeCubeSimulator.enums;

namespace ArcadeCubeSimulator.classes
{
    class SnakeGame
    {
        public LedCube MyLedCube { get; set; }

        private Snake _snake;

        private Led _food;

        private Random _random = new Random();

        private Led _snakeHeading;

        DispatcherTimer _turnTimer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromSeconds(1)
        };


        public SnakeGame(LedCube ledCube)
        {
            MyLedCube = ledCube;
            Setup();
        }

        private void Setup()
        {
            foreach (LedPlane plane in MyLedCube.LedPlanes)
            {
                foreach (LedRow ledRow in plane.LedRows)
                {
                    foreach (Led led in ledRow.Leds)
                    {
                        led.Value = 0;
                    }
                }
            }

            List<Led> leds = new List<Led>();
            leds.Add(MyLedCube.LedPlanes[0].LedRows[0].Leds[0]);
            _snake = new Snake(leds);

            SpawnFood();

            _turnTimer.Tick += _turnTimer_Tick;
            _turnTimer.Start();
        }

        private void _turnTimer_Tick(object sender, EventArgs e)
        {
            MoveSnake();
        }

        private void SpawnFood()
        {
            List<Led> spawnLocations = new List<Led>();
            foreach (LedPlane plane in MyLedCube.LedPlanes)
            {
                foreach (LedRow ledRow in plane.LedRows)
                {
                    spawnLocations.AddRange(ledRow.Leds);
                }
            }
            foreach (Led led in _snake.MyBody)
            {
                spawnLocations.Remove(led);
            }
            if(spawnLocations.Count == 0)
            {
                Setup();
            }
            else
            {
                int location = _random.Next(0, spawnLocations.Count);
                _food = spawnLocations[location];
                _food.Value = 1;
            }
        }

        private void MoveSnake()
        {
            SetSnakeHeading();

            if (CollisionSnake())
            {
                Setup();
            }
            else if (_snake.MyBody[_snake.MyBody.Count - 1] == _food)
            {
                EatFood();
            }
            else
            {
                _snakeHeading.Value = 2;
                _snake.MyBody.Add(_snakeHeading);
                _snake.MyBody[0].Value = 0;
                _snake.MyBody.RemoveAt(0);
                /*                _snake.Head[1]++;*/
                switch (_snake.MyDirection) 
                {
                    case Direction.PositiveX:
                        _snake.Head[2]++;
                        break;
                    case Direction.NegetiveX:
                        _snake.Head[2]--;
                        break;
                    case Direction.PositiveY:
                        _snake.Head[1]++;
                        break;
                    case Direction.NegativeY:
                        _snake.Head[1]--;
                        break;
                    case Direction.PositiveZ:
                        _snake.Head[0]++;
                        break;
                    case Direction.NegativeZ:
                        _snake.Head[0]++;
                        break;
                    default:
                        break;
                }
            }
        }

        private bool CollisionSnake()
        {
            if (_snakeHeading.Value == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void EatFood()
        {
            _snake.MyBody.Add(_snakeHeading);
            _snakeHeading.Value = 2;
            SpawnFood();
        }

        private void SetSnakeHeading()
        {
            switch (_snake.MyDirection)
            {
                case Direction.PositiveX:
                    _snakeHeading = MyLedCube.LedPlanes[_snake.Head[0]].LedRows[_snake.Head[1]].Leds[(_snake.Head[2] + 1) % 5];
                    break;
                case Direction.NegetiveX:
                    _snakeHeading = MyLedCube.LedPlanes[_snake.Head[0]].LedRows[_snake.Head[1]].Leds[(_snake.Head[2] - 1) % 5];
                    break;
                case Direction.PositiveY:
                    _snakeHeading = MyLedCube.LedPlanes[_snake.Head[0]].LedRows[(_snake.Head[1] + 1) % 5].Leds[_snake.Head[2]];
                    break;
                case Direction.NegativeY:
                    _snakeHeading = MyLedCube.LedPlanes[_snake.Head[0]].LedRows[(_snake.Head[1] - 1) % 5].Leds[_snake.Head[2]];
                    break;
                case Direction.PositiveZ:
                    _snakeHeading = MyLedCube.LedPlanes[(_snake.Head[0] + 1) % 5].LedRows[_snake.Head[1]].Leds[_snake.Head[2]];
                    break;
                case Direction.NegativeZ:
                    _snakeHeading = MyLedCube.LedPlanes[(_snake.Head[0] - 1) % 5].LedRows[_snake.Head[1]].Leds[_snake.Head[2]];
                    break;
                default:
                    break;

            }
        }
    }
}
