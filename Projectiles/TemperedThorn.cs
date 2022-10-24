using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Singularity.Projectiles {
	public class TemperedThorn : ModProjectile {
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			Projectile.width = 60;
			Projectile.height = 60;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.alpha = 255;
			Projectile.timeLeft = 30;
			Projectile.knockBack = 4f;
			Projectile.tileCollide = false;
			Projectile.penetrate = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
		}

		public override void AI(){	
		}
	}
}