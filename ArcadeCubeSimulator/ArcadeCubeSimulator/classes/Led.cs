using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ArcadeCubeSimulator.classes
{
    public class Led: PropertyChange
    {

        public Brush Color
        {
            get 
            {
                switch (Value)
                {
                    case 0:
                        return Brushes.Black;
                    case 1:
                        return Brushes.Red;
                    case 2:
                        return Brushes.LimeGreen;
                    case 3:
                        return Brushes.Blue;
                    case 4:
                        return Brushes.Yellow;
                    case 5:
                        return Brushes.Cyan;
                    case 6:
                        return Brushes.Magenta;
                    default:
                        return Brushes.Black;
                }
               
            }       
        }

        private byte _value;

        public byte Value
        {
            get { return _value; }
            set { _value = value; OnPropertyChanged("Color"); }
        }


    }
}
