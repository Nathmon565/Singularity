using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Singularity.Projectiles {
	public class TemperedThorn : ModProjectile {
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			projectile.width = 60;
			projectile.height = 60;
			projectile.melee = true;
			projectile.alpha = 255;
			projectile.timeLeft = 30;
			projectile.knockBack = 4f;
			projectile.tileCollide = false;
			projectile.penetrate = 1;
			projectile.friendly = true;
			projectile.hostile = false;
		}

		public override void AI(){	
		}
	}
}