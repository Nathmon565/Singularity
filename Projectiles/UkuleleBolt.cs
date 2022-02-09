using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class UkuleleBolt : ModProjectile {

public override void SetStaticDefaults() {
}
		public override void SetDefaults() {
			projectile.friendly = true;
			projectile.damage = 30;
			projectile.ranged = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 120;
			projectile.aiStyle = 29;
			projectile.alpha = 255;
			projectile.width = 16;
			projectile.height = 16;
			projectile.tileCollide = false;

		}
		private const float TrailDensity = 4;
		public override void AI() {
        	Vector2 dustPosition2 = projectile.Center;
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 133, null, 40, default(Color), 1f);
			dust2.velocity = projectile.velocity * 0f;
			dust2.noGravity = true;
			if (projectile.localAI[0] == 0f) {
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
			float distance = 400f;
			bool target = false;
			for (int k = 0; k < 200; k++) {
				if (Main.npc[k].active && !Main.npc[k].friendly) {
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance) {
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			if (target) {
				AdjustMagnitude(ref move);
				projectile.velocity = (10 * projectile.velocity + move) / 11f;
				AdjustMagnitude(ref projectile.velocity);
			}
       }
	   private void AdjustMagnitude(ref Vector2 vector) {
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 30f) {
				vector *= 30f / magnitude;
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			//target.immune[projectile.owner] = 20;
			projectile.velocity.Y = -30f;
			projectile.velocity.X = (Main.rand.Next(-20, 20));
			int k = 0;
		}
	}
}