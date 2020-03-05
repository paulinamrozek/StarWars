using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Characters
{
    public interface IPlanetRepository
    {
        Planet GetPlanet(int planetId);
    }
}
