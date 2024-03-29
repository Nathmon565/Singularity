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
			Item.mana = 12;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 1.75f;
			Item.value = Singularity.ToCopper(0, 0, 30, 0);
			Item.rare = 1;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("OnyxBolt").Type;
			Item.shootSpeed = 9f;
		}
	}
}