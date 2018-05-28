using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoWandRepositories.Entities.Account
{
    public class OparationDetailsUoW
    {
        public OparationDetailsUoW(bool succedeed, string message, string prop)
        {
            Succedeed = succedeed;
            Message = message;
            Property = prop;
        }
        public bool Succedeed { get; private set; }
        public string Message { get; private set; }
        public string Property { get; private set; }
    }
}
