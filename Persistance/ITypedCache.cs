using ASP_pl.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Persistance
{
    public interface ITypedCache<TEntity, TModel>
        where TEntity : IEntity
        where TModel: IEntityModel
    {
        public IEnumerable<TModel> GetAll();
        public TModel GetById(int id);
        public void Invalidate();
    }
}
