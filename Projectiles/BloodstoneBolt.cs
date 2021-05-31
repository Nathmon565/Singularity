using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class BloodstoneBolt : ModProjectile {

		public override void SetDefaults() {
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 600;
			projectile.aiStyle = 29;
			projectile.alpha = 255;
			projectile.width = 16;
			projectile.height = 16;
		}
		
		public override void AI() {
			Lighting.AddLight(projectile.position, 1.2f, 0.5f, 0.4f);
        	Vector2 dustPosition = projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 5, null, 100, default(Color), 1.2f);
			dust.velocity *= 0.1f;
			dust.noGravity = true;
			Vector2 dustPosition2 = projectile.Center + new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4));
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 115, null, 100, default(Color), 1.6f);
			dust2.velocity = projectile.velocity * 0.9f;
			dust2.noGravity = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			for (int i = 0; i < 4; i++) {
			float speedX = projectile.velocity.X * Main.rand.NextFloat(1.1f, 1.3f) + Main.rand.NextFloat(-0.9f, 0.9f);
			float speedY = projectile.velocity.Y * Main.rand.NextFloat(1.1f, 1.3f) + Main.rand.NextFloat(-0.9f, 0.9f);
	        Projectile.NewProjectile(projectile.position.X, projectile.position.Y, speedX, speedY, mod.ProjectileType("BloodstoneShard"), (int)(projectile.damage * 0.2), 0f, projectile.owner, 0f, 0f);
	        }
			projectile.Kill();
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
			for (int i = 0; i < 4; i++) {
            float speedX = projectile.velocity.X;
			float speedY = projectile.velocity.Y;
			if (projectile.velocity.X != oldVelocity.X) {
			speedX = -oldVelocity.X;
			speedY = projectile.velocity.Y + Main.rand.NextFloat(-0.5f, 0.5f);
			}
			if (projectile.velocity.Y != oldVelocity.Y) {
			speedY = -oldVelocity.Y;
			speedX = projectile.velocity.X + Main.rand.NextFloat(-0.5f, 0.5f);
			}
	        Projectile.NewProjectile(projectile.position.X, projectile.position.Y, speedX, speedY, mod.ProjectileType("BloodstoneShard"), (int)(projectile.damage * 0.2), 0f, projectile.owner, 0f, 0f);
	        }
			projectile.Kill();
            return false;
		}
	}
}