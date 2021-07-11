using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMelody.Model
{
    public class Setting
    {
        public string FolderWithMusic { get; set; }
        public int TimeToAnswer { get; set; }
        public int TimeToMusic { get; set; }
        public int PointsForAnswer { get; set; }
        public bool RandomMusic { get; set; }
    }
}
