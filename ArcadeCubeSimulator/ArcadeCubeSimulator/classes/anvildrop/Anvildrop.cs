using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcadeCubeSimulator.classes.main;
using System.Windows;
using ArcadeCubeSimulator.enums;
using System.Windows.Input;

namespace ArcadeCubeSimulator.classes.anvildrop
{
    class Anvildrop
    {
        private Random _random;

        private LedCube _ledCube;

        private AnvildropPlayer _player = new AnvildropPlayer() ;

        List<Anvil> _anvils = new List<Anvil>();

        public Anvildrop(LedCube ledCube, Random random)
        {
            _ledCube = ledCube;
            _random = random;
            ClearCube();
            SpawnPlayer();
            CreateAnvil();
        }

        private void ClearCube()
        {
            foreach (LedPlane plane in _ledCube.LedPlanes)
            {
                foreach (LedRow ledRow in plane.LedRows)
                {
                    foreach (Led led in ledRow.Leds)
                    {
                        led.Value = 0;
                    }
                }
            }
        }

        private void CreateAnvil()
        {
            List<Led> AnvilSpawns = new List<Led>();
            foreach(LedRow row in _ledCube.LedPlanes[0].LedRows)
            {
                foreach (Led led in row.Leds)
                {
                    if(led.Value == 0 || led.Value == 3)
                    {
                        AnvilSpawns.Add(led);
                    }
                }
            }
            Led spawnLed = AnvilSpawns[_random.Next(0,AnvilSpawns.Count)];
            Anvil anvil = new Anvil(spawnLed.X, spawnLed.Y, spawnLed.Z);
            spawnLed.Value = 1;
            _anvils.Add(anvil);
            if (anvil.X == _player.X && anvil.Y == _player.Y && anvil.Z == _player.Z)
            {
                MessageBox.Show("je hebt verloren");
                ResetGame();
            }
        }
        
        public void DropAnvils()
        {
            try
            {
                List<Anvil> anvilsToDelete = new List<Anvil>();
                foreach (Anvil anvil in _anvils)
                {
                    if (anvil.X == 4)
                    {
                        anvilsToDelete.Add(anvil);
                    }
                    else if (_ledCube.LedPlanes[anvil.X + 1].LedRows[anvil.Y].Leds[anvil.Z].Value == 1)
                    {
                        anvilsToDelete.Add(anvil);
                    }
                    else if (_ledCube.LedPlanes[anvil.X + 1].LedRows[anvil.Y].Leds[anvil.Z].Value == 3)
                    {
                        MessageBox.Show("je hebt verloren");
                        ResetGame();
                    }
                    else if (_ledCube.LedPlanes[anvil.X + 1].LedRows[anvil.Y].Leds[anvil.Z].Value == 0)
                    {
                        _ledCube.LedPlanes[anvil.X + 1].LedRows[anvil.Y].Leds[anvil.Z].Value = 1;
                        _ledCube.LedPlanes[anvil.X].LedRows[anvil.Y].Leds[anvil.Z].Value = 0;
                        anvil.X++;
                    }
                }
                foreach (Anvil anvil in anvilsToDelete)
                {
                    _anvils.Remove(anvil);
                    CreateAnvil();
                }
                DropPlayer();
            }
            catch(Exception e)
            {
                
            }

        }

        private void ResetGame()
        {
            GameTimers.AnvildropTimer.Stop();
            ClearCube();
            _anvils = new List<Anvil>();
            SpawnPlayer();
            CreateAnvil();
        }

        private void SpawnPlayer()
        {
            Led led = _ledCube.LedPlanes[4].LedRows[_random.Next(0, 5)].Leds[_random.Next(0, 5)];
            led.Value = 3;
            _player.X = 4;
            _player.Y = led.Y;
            _player.Z = led.Z;
        }

        private void DropPlayer()
        {
            bool dropped = false;
            while (dropped == false)
            {
                if (_player.X < 4)
                {
                    if (_ledCube.LedPlanes[_player.X + 1].LedRows[_player.Y].Leds[_player.Z].Value == 0)
                    {
                        _ledCube.LedPlanes[_player.X].LedRows[_player.Y].Leds[_player.Z].Value = 0;
                        _ledCube.LedPlanes[_player.X + 1].LedRows[_player.Y].Leds[_player.Z].Value = 3;
                        _player.X++;
                    }
                    else
                    {
                        dropped = true;
                    }
                }
                else
                {
                    dropped = true;
                }
            }
        }
        
        public void MovePlayer(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.S:
                    if (_player.Y < 4)
                    {
                        if (_ledCube.LedPlanes[_player.X].LedRows[_player.Y+1].Leds[_player.Z].Value == 1)
                        {
                            if (_ledCube.LedPlanes[_player.X - 1].LedRows[_player.Y + 1].Leds[_player.Z].Value == 0 && _ledCube.LedPlanes[_player.X - 1].LedRows[_player.Y].Leds[_player.Z].Value == 0)
                            {
                                _ledCube.LedPlanes[_player.X].LedRows[_player.Y].Leds[_player.Z].Value = 0;
                                _ledCube.LedPlanes[_player.X - 1].LedRows[_player.Y + 1].Leds[_player.Z].Value = 3;
                                _player.Y++;
                                _player.X--;
                            }
                        }
                        else
                        {
                            _ledCube.LedPlanes[_player.X].LedRows[_player.Y].Leds[_player.Z].Value = 0;
                            _ledCube.LedPlanes[_player.X].LedRows[_player.Y + 1].Leds[_player.Z].Value = 3;
                            _player.Y++;
                        }
                    }
                    break;
                case Key.W:
                    if (_player.Y > 0)
                    {
                        if (_ledCube.LedPlanes[_player.X].LedRows[_player.Y - 1].Leds[_player.Z].Value == 1)
                        {
                            if (_ledCube.LedPlanes[_player.X - 1].LedRows[_player.Y - 1].Leds[_player.Z].Value == 0 && _ledCube.LedPlanes[_player.X - 1].LedRows[_player.Y].Leds[_player.Z].Value == 0)
                            {
                                _ledCube.LedPlanes[_player.X].LedRows[_player.Y].Leds[_player.Z].Value = 0;
                                _ledCube.LedPlanes[_player.X - 1].LedRows[_player.Y - 1].Leds[_player.Z].Value = 3;
                                _player.Y--;
                                _player.X--;
                            }
                        }
                        else
                        {
                            _ledCube.LedPlanes[_player.X].LedRows[_player.Y].Leds[_player.Z].Value = 0;
                            _ledCube.LedPlanes[_player.X].LedRows[_player.Y - 1].Leds[_player.Z].Value = 3;
                            _player.Y--;
                        }
                    }
                    break;
                case Key.A:
                    if (_player.Z > 0)
                    {
                        if (_ledCube.LedPlanes[_player.X].LedRows[_player.Y].Leds[_player.Z - 1].Value == 1)
                        {
                            if (_ledCube.LedPlanes[_player.X - 1].LedRows[_player.Y].Leds[_player.Z - 1].Value == 0 && _ledCube.LedPlanes[_player.X - 1].LedRows[_player.Y].Leds[_player.Z].Value == 0)
                            {
                                _ledCube.LedPlanes[_player.X].LedRows[_player.Y].Leds[_player.Z].Value = 0;
                                _ledCube.LedPlanes[_player.X - 1].LedRows[_player.Y].Leds[_player.Z - 1].Value = 3;
                                _player.Z--;
                                _player.X--;
                            }
                        }
                        else
                        {
                            _ledCube.LedPlanes[_player.X].LedRows[_player.Y].Leds[_player.Z].Value = 0;
                            _ledCube.LedPlanes[_player.X].LedRows[_player.Y].Leds[_player.Z - 1].Value = 3;
                            _player.Z--;
                        }
                    }
                    break;
                case Key.D:
                    if (_player.Z < 4)
                    {
                        if (_ledCube.LedPlanes[_player.X].LedRows[_player.Y].Leds[_player.Z + 1].Value == 1)
                        {
                            if (_ledCube.LedPlanes[_player.X - 1].LedRows[_player.Y].Leds[_player.Z + 1].Value == 0 && _ledCube.LedPlanes[_player.X - 1].LedRows[_player.Y].Leds[_player.Z].Value == 0)
                            {
                                _ledCube.LedPlanes[_player.X].LedRows[_player.Y].Leds[_player.Z].Value = 0;
                                _ledCube.LedPlanes[_player.X - 1].LedRows[_player.Y].Leds[_player.Z + 1].Value = 3;
                                _player.Z++;
                                _player.X--;
                            }
                        }
                        else
                        {
                            _ledCube.LedPlanes[_player.X].LedRows[_player.Y].Leds[_player.Z].Value = 0;
                            _ledCube.LedPlanes[_player.X].LedRows[_player.Y].Leds[_player.Z + 1].Value = 3;
                            _player.Z++;
                        }
                    }
                    break;
                default:
                    break;
            }
            DropPlayer();
        }
    }
}
