using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Legs)]
	public class GlassLeggings : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("8% increased damge");
		}
		public override void SetDefaults() {
			item.rare = ItemRarityID.Blue;
			item.value = Singularity.ToCopper(0, 0, 30, 0);
			item.defense = 2;
		}
		public override bool DrawLegs() {
			return false;
		}
		public override void UpdateEquip(Player player) {
			player.allDamage += 0.08f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Glass, 25);
			recipe.AddIngredient(ItemID.FossilOre, 8);
			recipe.AddTile(TileID.GlassKiln);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}