using RimWorld;
using RimWorld.Planet;

namespace BiomesRebalanceHSK
{
    public class BiomeWorker_DenseTemperateForest : BiomeWorker
    {
#if V15
        public override float GetScore(Tile tile, int tileID)
#else
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile)
#endif
        {
            if (tile.WaterCovered)
            {
                return -100f;
            }
            if (tile.temperature < -10f || tile.rainfall < 1300f)
            {
                return 0f;
            }
            // Base 22 needed to outscore TemperateForest (15 + (rain-600)/180) at rain >= 1300
            return 22f + (tile.temperature - 7f) + (tile.rainfall - 1300f) / 180f;
        }
    }
}
