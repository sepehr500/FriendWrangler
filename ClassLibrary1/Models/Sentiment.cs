using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendWrangler.Core.Models
{

    public class Sentiment
    {
        public Probability probability { get; set; }
        public string label { get; set; }
    }

    public class Probability
    {
        public float neg { get; set; }
        public float neutral { get; set; }
        public float pos { get; set; }
    }


}
