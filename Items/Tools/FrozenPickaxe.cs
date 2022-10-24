using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Tools {
	public class FrozenPickaxe : ModItem {
		public override void SetDefaults() {
            Item.damage = 8; 
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20; 
			Item.useAnimation = 20;
			Item.knockBack = 6;
            Item.pick = 40;
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
		}
	}
}