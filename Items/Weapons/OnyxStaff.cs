using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Weapons {
	public class OnyxStaff : ModItem {
		public override void SetStaticDefaults() {
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults() {
			Item.damage = 40;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 20;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 4.75f;
			Item.value = Singularity.ToCopper(0, 0, 30, 0);
			Item.rare = 1;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("OnyxBolt").Type; //Amber staff
			Item.shootSpeed = 9f;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
			recipe.AddIngredient(null, "Onyx", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}