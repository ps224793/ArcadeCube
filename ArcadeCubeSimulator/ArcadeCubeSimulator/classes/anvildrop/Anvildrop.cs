using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcadeCubeSimulator.classes.main;

namespace ArcadeCubeSimulator.classes.anvildrop
{
    class Anvildrop
    {
        private Random _random;

        private LedCube _ledCube;

        List<Anvil> _anvils = new List<Anvil>();

        public Anvildrop(LedCube ledCube, Random random)
        {
            _ledCube = ledCube;
            _random = random;
            ClearCube();
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
        }
        
    }
}
