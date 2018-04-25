using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoWandRepositories.Interfaces
{
   public interface IShopUnitOfWork:IDisposable
    {
        int Commit();
    }
}
