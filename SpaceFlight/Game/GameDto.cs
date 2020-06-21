using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFlight.Objects.Rocket;
using SpaceFlight.Objects.Terrain;

namespace SpaceFlight.Game
{
    class GameDto
    {
        public List<RocketDto> Rockets;
        public List<TerrainDto> Planets;

        public GameDto(List<RocketDto> rockets, List<TerrainDto> planets)
        {
            Rockets = rockets;
            Planets = planets;
        }
    }
}
