using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Body)]
	public class TemperedGlassBreastplate : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("6% increased damage");
		}
		public override void SetDefaults() {
			item.rare = ItemRarityID.Blue;
			item.value = Singularity.ToCopper(0, 4, 0, 0);
			item.defense = 14;
		}

		public override bool DrawBody() {
			return false;
		}

		public override void UpdateEquip(Player player) {
			player.allDamage += 0.06f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ReinforcedGlass", 20);
			recipe.AddIngredient(ItemID.FrostCore, 1);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}