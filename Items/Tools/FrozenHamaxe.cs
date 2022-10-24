using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Tools {
	public class FrozenHamaxe : ModItem {
		public override void SetDefaults() {
            Item.damage = 8; 
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20; 
			Item.useAnimation = 20;
			Item.knockBack = 6;
            Item.axe = 9; //this is multiplied by 5 in game for some reason don't ask
            Item.hammer = 40;
			Item.value = Singularity.ToCopper(0, 0, 30, 0); 
			Item.rare = ItemRarityID.LightRed; 
			Item.UseSound = SoundID.Item1; 
			Item.autoReuse = true;
			Item.crit = 6;
            Item.useStyle = ItemUseStyleID.Swing; 
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "GlacialBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
            Recipe recipe2 = Recipe.Create(724);
			recipe2.AddIngredient(null, "GlacialBar", 14);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
            Recipe recipe3 = Recipe.Create(670);
			recipe3.AddIngredient(null, "GlacialBar", 8);
			recipe3.AddTile(TileID.Anvils);
			recipe3.Register();
		}
	}
}