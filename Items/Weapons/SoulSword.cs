using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Weapons {
	public class SoulSword : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("The soul's ideal blade.");  //The (English) text shown below your weapon's name
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() {
            item.damage = 50; 
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 10; 
			item.useAnimation = 25;
			item.knockBack = 6;
			item.value = Singularity.ToCopper(0, 0, 30, 0); 
			item.rare = ItemRarityID.LightRed; 
			item.UseSound = SoundID.Item1; 
			item.autoReuse = true;
			item.crit = 6;
            item.useStyle = 5; 
            item.shoot = 660;
			item.shootSpeed = 24f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddIngredient(null, "SoulGem", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}