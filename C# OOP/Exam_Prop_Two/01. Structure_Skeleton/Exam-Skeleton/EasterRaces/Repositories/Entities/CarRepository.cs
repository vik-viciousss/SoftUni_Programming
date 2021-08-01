using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly Dictionary<string, ICar> carsByModel;

        public CarRepository()
        {
            this.carsByModel = new Dictionary<string, ICar>();
        }

        public void Add(ICar model)
        {
            this.carsByModel.Add(model.Model, model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return this.carsByModel.Values.ToList().AsReadOnly();
        }

        public ICar GetByName(string name)
        {
            return this.carsByModel.Values.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(ICar model)
        {
            return this.carsByModel.Remove(model.Model);
        }
    }
}
