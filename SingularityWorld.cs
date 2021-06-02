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
            int shiniesIndex = tasks.FindIndex(x => x.Name.Equals("Random Gems"));
            if(shiniesIndex != -1)
            {
                tasks.Insert(shiniesIndex + 1, new PassLegacy("Singularity Ore Generation", OreGeneration));
            }
        }

        private void OreGeneration(GenerationProgress progress)
        {
            progress.Message = "Singularity Mod Ores";

            for(int i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 2E-03); i++) 
            {
                int x = WorldGen.genRand.Next(0, (int)Main.maxTilesX);
                int y = WorldGen.genRand.Next(0, (int)Main.worldSurface / 3);
                Tile tile = Framing.GetTileSafely(x, y);
                if(tile.active() && (tile.type == TileID.Dirt))
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(4, 6), WorldGen.genRand.Next(2, 3), TileType<Tiles.EnchantedOre>(), true, 0, 0, false, true);
                }
            }
            for(int i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 2E-04); i++) 
            {
                int x = WorldGen.genRand.Next(0, (int)Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)Main.rockLayer, (int)Main.maxTilesY);
                Tile tile = Framing.GetTileSafely(x, y);
                if(tile.active() && (tile.type == TileID.SnowBlock || tile.type == TileID.IceBlock))
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(4, 6), WorldGen.genRand.Next(2, 3), TileType<Tiles.OpalOre>(), true, 0, 0, false, true);
                }
            }
            for(int i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 1E-03); i++) 
            {
                int x = WorldGen.genRand.Next(0, (int)Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)Main.rockLayer, (int)Main.maxTilesY);
                Tile tile = Framing.GetTileSafely(x, y);
                if(tile.active() && (tile.type == TileID.SnowBlock || tile.type == TileID.IceBlock))
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(6, 8), WorldGen.genRand.Next(2, 3), TileType<Tiles.GlacialFragment>(), true, 0, 0, false, true);
                }
            }
        }
    }
}