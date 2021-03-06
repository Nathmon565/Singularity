using Terraria.ID;
using Terraria.ModLoader;


namespace Singularity.Items {
	public class EnchantedBar : ModItem {
		public override void SetDefaults() {
			item.maxStack = 99;
			item.value = Singularity.ToCopper(0, 0, 20, 0);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EnchantedOre", 3);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}