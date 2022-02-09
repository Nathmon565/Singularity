using Terraria.ID;
using Terraria.ModLoader;


namespace Singularity.Items {
	public class ReinforcedGlass : ModItem {
		public override void SetStaticDefaults(){
			Tooltip.SetDefault("Used for crafting more 'safe' glass items.");
		}
		public override void SetDefaults() {
			item.maxStack = 99;
			item.value = Singularity.ToCopper(0, 0, 20, 0);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Glass, 4);
			recipe.AddIngredient(ItemID.Obsidian,1);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}