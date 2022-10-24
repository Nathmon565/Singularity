using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Weapons {
	public class DragonSlayer : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("It was too big to be called a sword.\nMassive, thick, heavy, and far too rough.\nIndeed, it was a heap of raw iron.");  //The (English) text shown below your weapon's name
		}

		public override void SetDefaults() {
            Item.damage = 300; 
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 96;
			Item.height = 96;
			Item.useTime = 50; 
			Item.useAnimation = 50;
			Item.knockBack = 60;
			Item.value = Singularity.ToCopper(0, 12, 0, 0); 
			Item.rare = ItemRarityID.LightPurple; 
			Item.UseSound = SoundID.Item1; 
			Item.autoReuse = false;
			Item.crit = 6;
            Item.useStyle = ItemUseStyleID.Swing; 
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			// Add the Onfire buff to the NPC for 1 second when the weapon hits an NPC
			// 60 frames = 1 second
			target.AddBuff(189, 180);
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BreakerBlade);
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}