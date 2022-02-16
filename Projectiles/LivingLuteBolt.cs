using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace Singularity.Projectiles {
	public class LivingLuteBolt : ModProjectile {

		public override void SetDefaults() {
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 90;
			projectile.aiStyle = 29;
			projectile.alpha = 100;
			projectile.width = 16;
			projectile.height = 12;
			projectile.scale = 1.3f;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
		}
		
		public override void AI() {
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f + 3.14159f/2f;
		}
		public override void Kill(int timeLeft) {
			Dust dust2 = Dust.NewDustPerfect(projectile.Center, 61, null, 100, default(Color), 3f);
			dust2.velocity = projectile.velocity * 1.5f;
			dust2.noGravity = true;
		}
	}
}