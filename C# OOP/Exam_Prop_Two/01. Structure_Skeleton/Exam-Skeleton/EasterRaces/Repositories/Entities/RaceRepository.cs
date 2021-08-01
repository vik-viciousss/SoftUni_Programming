using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly Dictionary<string, IRace> racesByName;

        public RaceRepository()
        {
            racesByName = new Dictionary<string, IRace>();
        }

        public void Add(IRace model)
        {
            this.racesByName.Add(model.Name, model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.racesByName.Values.ToList().AsReadOnly();
        }

        public IRace GetByName(string name)
        {
            return this.racesByName.Values.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IRace model)
        {
            return this.racesByName.Remove(model.Name);
        }
    }
}
