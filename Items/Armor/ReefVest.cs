using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Body)]
	public class ReefVest : ModItem {
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Reduces damage taken by 2%");
		}
		public override void SetDefaults() {
			Item.rare = ItemRarityID.Blue;
			Item.value = Singularity.ToCopper(0, 0, 30, 0);
			Item.defense = 5;
		}
		public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Generic) -= 0.02f;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "Nacre", 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}