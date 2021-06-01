using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Tiles
{
	public class EnchantedOre : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileValue[Type] = 410; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("EnchantedOre");
			AddMapEntry(new Color(157, 188, 242), name);

			dustType = 84;
			drop = ModContent.ItemType<Items.Placeable.EnchantedOre>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			//mineResist = 4f;
			//minPick = 200;
		}
	}
}