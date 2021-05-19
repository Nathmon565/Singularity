using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Weapons {
	public class DragonSlayer : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("It was too big to be called a sword.\nMassive, thick, heavy, and far too rough.\nIndeed, it was a heap of raw iron.");  //The (English) text shown below your weapon's name
		}

		public override void SetDefaults() {
            item.damage = 300; 
			item.melee = true;
			item.width = 45;
			item.height = 45;
			item.useTime = 50; 
			item.useAnimation = 50;
			item.knockBack = 60;
			item.value = Singularity.ToCopper(0, 12, 0, 0); 
			item.rare = ItemRarityID.LightPurple; 
			item.UseSound = SoundID.Item1; 
			item.autoReuse = false;
			item.crit = 6;
            item.useStyle = ItemUseStyleID.SwingThrow; 
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			// Add the Onfire buff to the NPC for 1 second when the weapon hits an NPC
			// 60 frames = 1 second
			target.AddBuff(189, 180);
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BreakerBlade);
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}