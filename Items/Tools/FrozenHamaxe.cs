using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Tools {
	public class FrozenHamaxe : ModItem {
		public override void SetDefaults() {
            item.damage = 8; 
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20; 
			item.useAnimation = 20;
			item.knockBack = 6;
            item.axe = 9; //this is multiplied by 5 in game for some reason don't ask
            item.hammer = 40;
			item.value = Singularity.ToCopper(0, 0, 30, 0); 
			item.rare = ItemRarityID.LightRed; 
			item.UseSound = SoundID.Item1; 
			item.autoReuse = true;
			item.crit = 6;
            item.useStyle = ItemUseStyleID.SwingThrow; 
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GlacialBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(null, "GlacialBar", 14);
			recipe2.AddTile(TileID.Anvils);
			recipe2.SetResult(724);
			recipe2.AddRecipe();
            ModRecipe recipe3 = new ModRecipe(mod);
			recipe3.AddIngredient(null, "GlacialBar", 8);
			recipe3.AddTile(TileID.Anvils);
			recipe3.SetResult(670);
			recipe3.AddRecipe();
		}
	}
}