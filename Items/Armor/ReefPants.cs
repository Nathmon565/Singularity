using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Legs)]
	public class ReefPants : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Reduces damage taken by 1%");
		}
		public override void SetDefaults() {
			item.rare = ItemRarityID.Blue;
			item.value = Singularity.ToCopper(0, 0, 30, 0);
			item.defense = 4;
		}
        public override bool DrawLegs() {
			return false;
		}
		public override void UpdateEquip(Player player) {
			player.allDamage -= 0.01f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Nacre", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}