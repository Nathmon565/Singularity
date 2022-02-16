using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Weapons {
	public class DemonBloodSword : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("A family heirloom.");  //The (English) text shown below your weapon's name
		}

		public override void SetDefaults() {
            item.damage = 50; 
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20; 
			item.useAnimation = 20;
			item.knockBack = 6;
			item.value = Singularity.ToCopper(0, 0, 30, 0); 
			item.rare = ItemRarityID.LightRed; 
			item.UseSound = SoundID.Item1; 
			item.autoReuse = true;
			item.crit = 6;
			item.useTurn = true;
            item.useStyle = ItemUseStyleID.SwingThrow; 
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
			recipe.AddIngredient(null, "DemonBlood", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}