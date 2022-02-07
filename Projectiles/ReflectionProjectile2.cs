using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Singularity.Projectiles {
	public class ReflectionProjectile2 : ModProjectile {
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
            projectile.friendly = true;
			projectile.width = 20;
			projectile.height = 20;
			projectile.alpha = 165;
			projectile.timeLeft = 25;
			projectile.knockBack = 0f;
			projectile.penetrate = 1;
		}

		public override void AI(){
			
		}
	}
}