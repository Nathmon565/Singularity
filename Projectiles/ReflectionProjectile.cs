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
			Projectile.alpha = 255;
			Projectile.friendly = true;
			Projectile.penetrate = 3;			
			Projectile.width = 60;
			Projectile.height = 60;
			Projectile.scale = 0.83f;
			Projectile.timeLeft = 70;
			Projectile.knockBack = 0f;
			Projectile.tileCollide = false;
		}

		public override void AI(){
			Lighting.AddLight(Projectile.Center, 0.3f, 0.34f, 0.3f);
			Projectile.spriteDirection = Projectile.direction;
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] > 2f && Projectile.ai[0] <= 10f) {
				// Fade in
				Projectile.alpha -= 1;
			}
			if (Projectile.ai[0] > 10f && Projectile.ai[0] <= 20f) {
				Projectile.rotation -= 0.05f * (float)Projectile.direction;
			}
			if (Projectile.ai[0] > 40f) {
				Projectile.rotation += 0.2f * (float)Projectile.direction;
			}
			if (Projectile.ai[0] > 65f) {
				// Fade out
				Projectile.alpha += 1;
			if (Projectile.alpha > 255) {
				Projectile.alpha = 255;
			}
			}
		}
	}
}