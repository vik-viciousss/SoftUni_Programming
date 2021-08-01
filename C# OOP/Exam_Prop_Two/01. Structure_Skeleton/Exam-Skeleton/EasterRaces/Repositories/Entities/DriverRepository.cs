using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly Dictionary<string, IDriver> driversByName;

        public DriverRepository()
        {
            driversByName = new Dictionary<string, IDriver>();
        }

        public void Add(IDriver model)
        {
            this.driversByName.Add(model.Name, model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.driversByName.Values.ToList().AsReadOnly();
        }

        public IDriver GetByName(string name)
        {
            return this.driversByName.Values.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IDriver model)
        {
            return this.driversByName.Remove(model.Name);
        }
    }
}
