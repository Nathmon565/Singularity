using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Weapons {
	public class SoulSword : ModItem {
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("The soul's ideal blade.");  //The (English) text shown below your weapon's name
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults() {
            Item.damage = 50; 
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10; 
			Item.useAnimation = 25;
			Item.knockBack = 6;
			Item.value = Singularity.ToCopper(0, 0, 30, 0); 
			Item.rare = ItemRarityID.LightRed; 
			Item.UseSound = SoundID.Item1; 
			Item.autoReuse = true;
			Item.crit = 6;
            Item.useStyle = 5; 
            Item.shoot = 660;
			Item.shootSpeed = 24f;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddIngredient(null, "SoulGem", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}