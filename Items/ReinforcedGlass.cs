using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Singularity.Items {
	public class ReinforcedGlass : ModItem {
		public override void SetStaticDefaults(){
			Tooltip.SetDefault("Used for crafting more 'safe' glass items.");
		}
		public override void SetDefaults() {
			Item.maxStack = 99;
			Item.value = Singularity.ToCopper(0, 0, 20, 0);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Glass, 4);
			recipe.AddIngredient(ItemID.Obsidian,1);
			recipe.AddTile(TileID.Hellforge);
			recipe.Register();
		}
	}
}