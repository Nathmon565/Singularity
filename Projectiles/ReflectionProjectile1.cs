using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Singularity.Projectiles {
	public class ReflectionProjectile1 : ModProjectile {
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
            projectile.friendly = true;
			projectile.width = 20;
			projectile.height = 20;
			projectile.alpha = 125;
			projectile.timeLeft = 30;
			projectile.knockBack = 0f;
			projectile.penetrate = 1;
		}

		public override void AI(){
			
		}
	}
}