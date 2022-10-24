using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Singularity.Items {
	public class EnchantedBar : ModItem {
		public override void SetDefaults() {
			Item.maxStack = 99;
			Item.value = Singularity.ToCopper(0, 0, 20, 0);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "EnchantedOre", 3);
			recipe.AddTile(TileID.Furnaces);
			recipe.Register();
		}
	}
}