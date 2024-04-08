using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_server.models
{
    public class Scheduling
{
    public List<int> Chosen { get; set; }
    public Scheduling()
        {
            this.Chosen = new List<int>()
            {
                -1,-1,-1,-1,-1
            };
        }
}
}
