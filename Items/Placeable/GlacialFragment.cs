using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Placeable
{
	public class GlacialFragment : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
		}

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.GlacialFragment>();
			Item.width = 12;
			Item.height = 12;
			Item.value = 3000;
		}
	}
}