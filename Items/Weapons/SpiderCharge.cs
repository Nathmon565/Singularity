using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Weapons {
	public class SpiderCharge : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Spider Bolt");
		}

		public override void SetDefaults() {
			Item.damage = 40;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 12;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 4.75f;
			Item.value = Singularity.ToCopper(0, 0, 30, 0);
			Item.rare = 1;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("SpiderBolt").Type;
			Item.shootSpeed = 8f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.WaterBolt);
			recipe.AddIngredient(null, "ToughSilk", 8);
			recipe.AddIngredient(ItemID.SpiderFang, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}