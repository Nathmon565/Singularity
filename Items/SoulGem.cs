using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Singularity.Items {
	public class SoulGem : ModItem {
		public override void SetDefaults() {
			Item.maxStack = 99;
			Item.value = Singularity.ToCopper(0, 0, 30, 0);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SoulofFright);
            recipe.AddIngredient(ItemID.SoulofMight);
			recipe.AddIngredient(ItemID.SoulofSight);
			recipe.AddTile(TileID.Furnaces);
			recipe.Register();
		}
	}
}