using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Body)]
	public class FrozenBreastplate : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("2% increased melee speed");
		}
		public override void SetDefaults() {
			Item.rare = ItemRarityID.Blue;
			Item.value = Singularity.ToCopper(0, 0, 30, 0);
			Item.defense = 4;
		}
		public override void UpdateEquip(Player player) {
			player.GetAttackSpeed(DamageClass.Melee) += 0.02f;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "GlacialBar", 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}