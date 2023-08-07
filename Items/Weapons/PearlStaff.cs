using Singularity.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Weapons {
	public class PearlStaff : ModItem {
		public override void SetStaticDefaults() {
			Item.staff[Item.type] = true;
		}

        public override void SetDefaults() {
			Item.damage = 11;
			Item.crit = 8;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 6;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 4.75f;
			Item.value = Singularity.ToCopper(0, 0, 30, 0);
			Item.rare = 1;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("PearlBolt").Type;
			Item.shootSpeed = 7f;
		}
	}
}