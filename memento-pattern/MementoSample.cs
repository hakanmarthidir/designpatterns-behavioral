using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memento_pattern
{

    public class GodOfWar
    {
        public int EarnPoint { get; set; }
        public byte Level { get; set; }
        public string MapPoint { get; set; }

        public GodOfWarMemento Save()
        {
            GodOfWarMemento memento = new() { EarnPoint = this.EarnPoint, Level = this.Level, MapPoint = this.MapPoint };
            return memento;
        }

        public void LoadSavedPoint(GodOfWarMemento memento)
        {
            this.EarnPoint = memento.EarnPoint;
            this.Level = memento.Level;
            this.MapPoint = memento.MapPoint;
        }

    }

    public class GodOfWarMemento
    {
        public int EarnPoint { get; set; }
        public byte Level { get; set; }
        public string MapPoint { get; set; }
    }

    public class MementoCareTaker
    {
        public GodOfWarMemento GodOfWarMemento { get; set; }
        //you can use the Stack or other Lists..
    }



}
