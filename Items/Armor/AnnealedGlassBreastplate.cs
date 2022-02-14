using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Body)]
	public class AnnealedGlassBreastplate : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("12% increased damage");
		}
		public override void SetDefaults() {
			item.rare = ItemRarityID.Blue;
			item.value = Singularity.ToCopper(0, 4, 0, 0);
			item.defense = 8;
		}
		public override void UpdateEquip(Player player) {
			player.allDamage += 0.12f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ReinforcedGlass", 20);
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 1);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}