using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Tiles
{
	public class OpalOre : ModTile
	{
		public override void SetStaticDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileOreFinderPriority[Type] = 410; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("OpalOre");
			AddMapEntry(new Color(157, 188, 242), name);

			DustType = 84;
			ItemDrop = ModContent.ItemType<Items.Opal>();
			HitSound = SoundID.Tink;
			//soundStyle/* tModPorter Note: Removed. Integrate into HitSound */ = 1;
			//mineResist = 4f;
			//minPick = 200;
		}
	}
}