using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;

namespace Singularity
{
    public class SingularityWorld : ModWorld
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(x => x.Name.Equals("Shinies"));
            if(shiniesIndex != -1)
            {
                tasks.Insert(shiniesIndex + 1, new PassLegacy("Singularity Ore Generation", OreGeneration));
            }
        }

        private void OreGeneration(GenerationProgress progress)
        {
            progress.Message = "Singularity Mod Ores";

            for(int i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 7E-03); i++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next(0, (int)WorldGen.worldSurfaceLow);

                Tile tile = Framing.GetTileSafely(x, y);
                if(tile.active() && (tile.type == TileID.Dirt || tile.type == TileID.Stone))
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(8, 12), WorldGen.genRand.Next(1, 3), TileType<Tiles.EnchantedOre>());
                }
            }
        }
    }
}