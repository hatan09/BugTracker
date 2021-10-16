using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Entities
{
    public class Admin : User
    {
        public virtual Company? Company { get; set; }
    }
}
