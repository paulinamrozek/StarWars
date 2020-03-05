using Characters;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class PlanetRepository : RepositoryBase<Planet>, IPlanetRepository
    {
        public PlanetRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public Planet GetPlanet(int planetId) =>
             FindByCondition(p => p.PlanetId.Equals(planetId)).FirstOrDefault();
    }
}
