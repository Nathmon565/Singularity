using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace Singularity.Projectiles {
	public class LivingLuteBolt : ModProjectile {

		public override void SetDefaults() {
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 90;
			Projectile.aiStyle = 29;
			Projectile.alpha = 100;
			Projectile.width = 16;
			Projectile.height = 12;
			Projectile.scale = 1.3f;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = false;
		}
		
		public override void AI() {
			Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f + 3.14159f/2f;
		}
		public override void Kill(int timeLeft) {
			Dust dust2 = Dust.NewDustPerfect(Projectile.Center, 61, null, 100, default(Color), 3f);
			dust2.velocity = Projectile.velocity * 1.5f;
			dust2.noGravity = true;
		}
	}
}