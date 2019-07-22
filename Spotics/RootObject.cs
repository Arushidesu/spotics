using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotics
{
    class RootObject
    {
        public string type { get; set; }
        public Art art { get; set; }
        public Mu[] mus { get; set; }
        public bool badwords { get; set; }
    }
}
