using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Legs)]
	public class FrozenLeggings : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("2% increased melee speed");
		}
		public override void SetDefaults() {
			item.rare = ItemRarityID.Blue;
			item.value = Singularity.ToCopper(0, 0, 30, 0);
			item.defense = 3;
		}
		public override bool DrawLegs() {
			return false;
		}
		public override void UpdateEquip(Player player) {
			player.meleeSpeed += 0.02f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GlacialBar", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}