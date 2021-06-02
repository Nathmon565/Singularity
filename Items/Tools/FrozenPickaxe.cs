using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Tools {
	public class FrozenPickaxe : ModItem {
		public override void SetDefaults() {
            item.damage = 8; 
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20; 
			item.useAnimation = 20;
			item.knockBack = 6;
            item.pick = 40;
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
		}
	}
}