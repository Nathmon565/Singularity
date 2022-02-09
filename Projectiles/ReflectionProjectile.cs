using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Singularity.Projectiles {
	public class ReflectionProjectile : ModProjectile {
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			projectile.alpha = 255;
			projectile.friendly = true;
			projectile.penetrate = 3;			
			projectile.width = 60;
			projectile.height = 60;
			projectile.scale = 0.83f;
			projectile.timeLeft = 80;
			projectile.knockBack = 0f;
			projectile.tileCollide = false;
		}

		public override void AI(){
			projectile.spriteDirection = projectile.direction;
			projectile.ai[0] += 1f;
			if (projectile.ai[0] > 2f && projectile.ai[0] <= 10f) {
				// Fade in
				projectile.alpha -= 1;
			}
			if (projectile.ai[0] > 10f && projectile.ai[0] <= 20f) {
				projectile.rotation -= 0.05f * (float)projectile.direction;
			}
			if (projectile.ai[0] > 40f) {
				projectile.rotation += 0.2f * (float)projectile.direction;
			}
			if (projectile.ai[0] > 65f) {
				// Fade out
				projectile.alpha += 1;
			if (projectile.alpha > 255) {
				projectile.alpha = 255;
			}
			}
		}
	}
}