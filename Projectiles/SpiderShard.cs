using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class SpiderShard : ModProjectile {

		public override void SetDefaults() {
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 12;
			projectile.timeLeft = 60;
			projectile.aiStyle = 29;
			projectile.alpha = 255;
			projectile.width = 8;
			projectile.height = 8;
			projectile.scale = 0.7f;
		}
		
		public override void AI() {
			Lighting.AddLight(projectile.Center, 0.7f, 0.6f, 0.7f);
            Vector2 dustPosition = projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 1, null, 100, default(Color), 0.6f);
			dust.velocity *= 0.3f;
			dust.noGravity = true;
            Vector2 dustPosition2 = projectile.Center + new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4));
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 1, null, 100, default(Color), 0.8f);
			dust2.velocity = projectile.velocity * 0.9f;
			dust2.noGravity = true;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
				Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
				Main.PlaySound(SoundID.Item10, projectile.position);
				if (projectile.velocity.X != oldVelocity.X) {
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y) {
					projectile.velocity.Y = -oldVelocity.Y;
			}
			return false;
		}
	}
}