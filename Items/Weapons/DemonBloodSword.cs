using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Weapons {
	public class DemonBloodSword : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("A family heirloom.");  //The (English) text shown below your weapon's name
		}

		public override void SetDefaults() {
            Item.damage = 50; 
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20; 
			Item.useAnimation = 20;
			Item.knockBack = 6;
			Item.value = Singularity.ToCopper(0, 0, 30, 0); 
			Item.rare = ItemRarityID.LightRed; 
			Item.UseSound = SoundID.Item1; 
			Item.autoReuse = true;
			Item.crit = 6;
			Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.Swing; 
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
			recipe.AddIngredient(null, "DemonBlood", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}