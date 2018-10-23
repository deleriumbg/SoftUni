namespace PhotoShare.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;

    using Data;
    using Models;
    using Contracts;

    public class TownService : ITownService
    {
        private readonly PhotoShareContext context;

        public TownService(PhotoShareContext context)
        {
            this.context = context;
        }

        public TModel ById<TModel>(int id)
            => By<TModel>(a => a.Id == id).SingleOrDefault();

        public TModel ByName<TModel>(string name)
            => By<TModel>(a => a.Name == name).SingleOrDefault();

        public bool Exists(int id)
            => ById<Town>(id) != null;

        public bool Exists(string name)
            => ByName<Town>(name) != null;

        public Town Add(string townName, string countryName)
        {
            var town = new Town
            {
                Name = townName,
                Country = countryName
            };

            this.context.Towns.Add(town);
            this.context.SaveChanges();
            return town;
        }

        private IEnumerable<TModel> By<TModel>(Func<Town, bool> predicate) =>
            this.context.Towns
                .Where(predicate)
                .AsQueryable()
                .ProjectTo<TModel>();
    }
}
