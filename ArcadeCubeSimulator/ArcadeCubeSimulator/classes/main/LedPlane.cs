using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeCubeSimulator.classes.main
{
    public class LedPlane
    {
        const int NrOfLedRows = 5;
        private int _planeCordinate;


        private ObservableCollection<LedRow> _ledRows = new ObservableCollection<LedRow>();

        public ObservableCollection<LedRow> LedRows
        {
            get { return _ledRows; }
            set { _ledRows = value; }
        }

        public byte[] Value
        {
            get
            {
                byte[] value = new byte[0];

                IEnumerable<byte> total = value.Concat(LedRows[0].Value).Concat(LedRows[1].Value).Concat(LedRows[2].Value).Concat(LedRows[3].Value).Concat(LedRows[4].Value);
                              
                return total.ToArray();
            }
        }

        public LedPlane(int planeCordinate)
        {
            _planeCordinate = planeCordinate;
            for (int i = 0; i < NrOfLedRows; i++)
            {
                _ledRows.Add(new LedRow(_planeCordinate, i));
            }
        }
    }
}
