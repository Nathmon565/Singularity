using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Body)]
	public class GlassBreastplate : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("8% increased damage");
		}
		public override void SetDefaults() {
			item.rare = ItemRarityID.Blue;
			item.value = Singularity.ToCopper(0, 0, 30, 0);
			item.defense = 3;
		}
		public override void UpdateEquip(Player player) {
			player.allDamage += 0.08f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Glass, 25);
			recipe.AddIngredient(ItemID.FossilOre, 18);
			recipe.AddTile(TileID.GlassKiln);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}