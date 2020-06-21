using System.Collections.Generic;
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
