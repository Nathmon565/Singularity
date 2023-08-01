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
			Projectile.friendly = true;
			Projectile.damage = 30;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 2;
			Projectile.timeLeft = 120;
			Projectile.aiStyle = 0;
			Projectile.alpha = 255;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.tileCollide = false;
		}
		private const float TrailDensity = 4;
		public override void AI() {
			Vector2 dustPosition2 = Projectile.Center;
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 133, null, 40, default(Color), 1f);
			dust2.velocity = Projectile.velocity * 0f;
			dust2.noGravity = true;
			if (Projectile.localAI[0] == 0f) {
				AdjustMagnitude(ref Projectile.velocity);
				Projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
			float distance = 400f;
			bool target = false;
			for (int k = 0; k < 200; k++) {
				if (Main.npc[k].active && !Main.npc[k].friendly) {
					Vector2 newMove = Main.npc[k].Center - Projectile.Center;
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
				Projectile.velocity = (10 * Projectile.velocity + move) / 11f;
				AdjustMagnitude(ref Projectile.velocity);
			}
       }
	   private void AdjustMagnitude(ref Vector2 vector) {
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 30f) {
				vector *= 30f / magnitude;
			}
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			//target.immune[projectile.owner] = 20;
			Projectile.velocity.Y = -30f;
			Projectile.velocity.X = (Main.rand.Next(-20, 20));
			int k = 0;
		}
	}
}