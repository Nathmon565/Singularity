using Terraria.ID;
using Terraria.ModLoader;


namespace Singularity.Items.Ammo {
	public class SilkBall : ModItem {
		public override void SetDefaults() {
			item.maxStack = 999;
			item.damage = 3000;
			item.value = Singularity.ToCopper(0, 0, 0, 10);
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ToughSilk");
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}