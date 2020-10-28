using ASP_pl.Extensions;
using ASP_pl.Localization;
using ASP_pl.Persistance.Entities;
using ASP_pl.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductE = ASP_pl.Persistance.Entities.Product;

namespace ASP_pl.Persistance
{
    public abstract class TypedCache<TEntity, TModel> : ITypedCache<TEntity, TModel>
        where TEntity : class, IEntity
        where TModel : class, IEntityModel
    {
        protected IServiceScopeFactory _scopeFactory;
        protected IMemoryCache _cache;
        private string Name { get; } = typeof(TModel).Name;

        protected abstract Func<TEntity, AppDbContext, TModel> Converter { get; }
        protected abstract Func<DbSet<TEntity>, IQueryable<TEntity>> Includes { get; }
        public TypedCache(IMemoryCache cache, IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            _cache = cache;
            Initialize();
        }

        private void Initialize()
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            _cache.Set<IEnumerable<TModel>>(Name, Includes(dbContext.Set<TEntity>()).ToList().Select(ent => Converter(ent, dbContext)).ToList());
        }

        public void Invalidate()
        {
            _cache.Remove(Name);
            Initialize();
        }

        public IEnumerable<TModel> GetAll() => _cache.Get(Name) as IEnumerable<TModel>;

        public TModel GetById(int id) => GetAll().Find(id);
    }

    public class ProductCache : TypedCache<ProductE, ProductModel>
    {
        public ProductCache(IMemoryCache cache, IServiceScopeFactory scopeFactory) : base(cache, scopeFactory)
        {
        }

        

        protected override Func<ProductE, AppDbContext, ProductModel> Converter => (ent, dbContext) => new ProductModel
        {
            Id = ent.ProductId,
            Code = ent.Code,
            Description = ent.Description is { } d 
                ? new TranslationModel
                {
                    LangaugeId = d.LanguageId,
                    OriginalId = d.OriginalId,
                    Text = d.Text,
                    TranslationId = d.TranslationId
                }
                : null,
            Prices = dbContext
                    .ProductHasPrices
                    .Where(php => php.ProductId == ent.ProductId)
                    .AsEnumerable()
                    .Select(php => (php.ErpType, php.Price))
                    .ToList(),
        };

        protected override Func<DbSet<ProductE>, IQueryable<ProductE>> Includes => set => set.Include(x => x.Description);
    }

    public class LangCache : TypedCache<Language, LanguageModel>
    {
        public LangCache(IMemoryCache cache, IServiceScopeFactory scopeFactory) : base(cache, scopeFactory)
        {
        }

        protected override Func<Language, AppDbContext, LanguageModel> Converter => (ent, _) => new LanguageModel
        {
            LangId = ent.LanguageId,
            Name = ent.Name,
        };

        protected override Func<DbSet<Language>, IQueryable<Language>> Includes => set => set;
    }
}
