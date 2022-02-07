using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Singularity.Projectiles {
	public class ReflectionProjectile0 : ModProjectile {
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
            projectile.friendly = true;
			projectile.width = 20;
			projectile.height = 20;
			projectile.alpha = 105;
			projectile.timeLeft = 35;
			projectile.knockBack = 0f;
			projectile.penetrate = 1;
		}

		public override void AI(){
			
		}
	}
}