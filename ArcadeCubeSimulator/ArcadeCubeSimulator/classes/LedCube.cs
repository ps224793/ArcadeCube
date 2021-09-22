using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeCubeSimulator.classes
{
    public class LedCube
    {
        const int NrOfLedPlanes = 5;

        private ObservableCollection<LedPlane> _ledPlanes = new ObservableCollection<LedPlane>();

        public ObservableCollection<LedPlane> LedPlanes
        {
            get { return _ledPlanes; }
            set { _ledPlanes = value; }
        }

        public byte[] Value
        {
            get
            {
                byte[] value = new byte[0];

                IEnumerable<byte> total = value.Concat(LedPlanes[0].Value).Concat(LedPlanes[1].Value).Concat(LedPlanes[2].Value).Concat(LedPlanes[3].Value).Concat(LedPlanes[4].Value);

                return total.ToArray();
            }
        }

        public LedCube()
        {
            for (int i = 0; i < NrOfLedPlanes; i++)
            {
                _ledPlanes.Add(new LedPlane());
            }
        }
    }
}
