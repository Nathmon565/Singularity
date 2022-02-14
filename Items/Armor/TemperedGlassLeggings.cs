using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Legs)]
	public class TemperedGlassLeggings : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("6% increased damge");
		}
		public override void SetDefaults() {
			item.rare = ItemRarityID.Blue;
			item.value = Singularity.ToCopper(0, 3, 0, 0);
			item.defense = 9;
		}
		public override bool DrawLegs() {
			return false;
		}
		public override void UpdateEquip(Player player) {
			player.allDamage += 0.06f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ReinforcedGlass", 16);
			recipe.AddIngredient(ItemID.FrostCore, 1);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}