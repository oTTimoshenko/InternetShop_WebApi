using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Interfaces;
using AutoMapper;
using Domain.Context;
using Domain.Interfaces;

namespace UoWandRepositories.Repositories
{
    public abstract class ShopGenericRepository<TInputEntity, TDomainEntity>:IShopGenericRepository<TInputEntity, TDomainEntity> 
        where TInputEntity : class
        where TDomainEntity:class
    {
        protected IEFshopContext _entities;
        protected readonly IDbSet<TDomainEntity> _dbset;
        protected readonly IMapper mapper;

        public ShopGenericRepository(IEFshopContext context, IMapper mapper)
        {
            _entities = context;
            _dbset = _entities.Set<TDomainEntity>();
            this.mapper = mapper;
        }

        public virtual IEnumerable<TInputEntity> GetAll()
        {
            return mapper.Map<IEnumerable<TInputEntity>>(_dbset.AsEnumerable<TDomainEntity>());
        }

        public virtual void Add(TInputEntity entity)
        {
            var _entity = mapper.Map<TDomainEntity>(entity);
             _dbset.Add(_entity);
        }

        public virtual void Delete(TInputEntity entity)
        {
            var _entity = mapper.Map<TDomainEntity>(entity);
            _dbset.Remove(_entity);
        }

        public virtual void DeleteById(int Id)
        {
            var _entity = _dbset.Find(Id);
            _dbset.Remove(_entity);
            var entity = mapper.Map<TInputEntity>(_entity);
        }

        public virtual void Edit(TInputEntity entity)
        {
            var _entity = mapper.Map<TDomainEntity>(entity);
            _entities.Entry(_entity).State = EntityState.Modified;
        }
    }
}
