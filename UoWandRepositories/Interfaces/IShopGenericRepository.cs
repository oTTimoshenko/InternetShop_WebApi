using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UoWandRepositories.Interfaces
{
    public interface IShopGenericRepository<TInputEntity, TDomainEntity>
        where TInputEntity: class 
        where TDomainEntity:class
    {
        IEnumerable<TInputEntity> GetAll();
        //IEnumerable<TInputEntity> FindBy(Expression<Func<TInputEntity, bool>> predicate);
        void Add(TInputEntity entity);
        void Delete(TInputEntity entity);
        void DeleteById(int Id);
        void Edit(TInputEntity entity);
    }
}
