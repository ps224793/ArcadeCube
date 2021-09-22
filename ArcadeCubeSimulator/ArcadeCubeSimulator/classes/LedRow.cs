using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeCubeSimulator.classes
{
    public class LedRow
    {
        public const int NrOfLeds = 5;

        private ObservableCollection<Led> _leds= new ObservableCollection<Led>();

        public ObservableCollection<Led> Leds
        {
            get { return _leds; }
            set { _leds = value; }
        }

        public byte[] Value
        {
            get 
            {
                Byte[] value = new Byte[NrOfLeds];
                for (int i = 0; i < NrOfLeds; i++)
                {
                    value[i] = Leds[i].Value;
                }
                return value; 
            }
        }

        public LedRow()
        {
            for (int i = 0; i < NrOfLeds; i++)
            {
                _leds.Add(
                    new Led()
                    {
                        Value = 0
                    }
                    );
            }
        }

    }
}
