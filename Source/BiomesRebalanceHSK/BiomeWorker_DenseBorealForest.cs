using RimWorld;
using RimWorld.Planet;

namespace BiomesRebalanceHSK
{
    public class BiomeWorker_DenseBorealForest : BiomeWorker
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
            if (tile.temperature < -10f || tile.temperature > 5f || tile.rainfall < 1300f)
            {
                return 0f;
            }
            // Vanilla BorealForest: ~22 base at temp=-5, rain=600+
            // We need base high enough to outscore it at rain >= 1300
            // BorealForest score at rain=1300: ~22 + (1300-600)/180 = 22 + 3.89 = 25.89
            // Dense base must exceed that: use 28
            return 28f + (tile.temperature + 5f) + (tile.rainfall - 1300f) / 180f;
        }
    }
}
