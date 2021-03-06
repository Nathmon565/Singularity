using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class SpiderBolt : ModProjectile {

		public override void SetDefaults() {
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 60;
			projectile.aiStyle = 29;
			projectile.alpha = 255;
			projectile.width = 16;
			projectile.height = 16;
			projectile.scale = 0.7f;
		}
		
		public override void AI() {
			Lighting.AddLight(projectile.Center, 0.7f, 0.6f, 0.7f);
        	Vector2 dustPosition = projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 1, null, 100, default(Color), 1.2f);
			dust.velocity *= 0.1f;
			dust.noGravity = true;
			Vector2 dustPosition2 = projectile.Center + new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4));
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 1, null, 100, default(Color), 1.6f);
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
        public override void Kill(int timeLeft) {
            for (int i = 0; i < 1; i++) {
	            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 3.8f + Main.rand.NextFloat(-0.9f, 0.9f), 9.2f + Main.rand.NextFloat(-0.9f, 0.9f), mod.ProjectileType("SpiderShard"), (int)(projectile.damage), 0f, projectile.owner, 0f, 0f);
	            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -3.8f + Main.rand.NextFloat(-0.9f, 0.9f), 9.2f + Main.rand.NextFloat(-0.9f, 0.9f), mod.ProjectileType("SpiderShard"), (int)(projectile.damage), 0f, projectile.owner, 0f, 0f);
	            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 3.8f + Main.rand.NextFloat(-0.9f, 0.9f), -9.2f + Main.rand.NextFloat(-0.9f, 0.9f), mod.ProjectileType("SpiderShard"), (int)(projectile.damage), 0f, projectile.owner, 0f, 0f);
	            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -3.8f + Main.rand.NextFloat(-0.9f, 0.9f), -9.2f + Main.rand.NextFloat(-0.9f, 0.9f), mod.ProjectileType("SpiderShard"), (int)(projectile.damage), 0f, projectile.owner, 0f, 0f);
	            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 9.2f + Main.rand.NextFloat(-0.9f, 0.9f), 3.8f + Main.rand.NextFloat(-0.9f, 0.9f), mod.ProjectileType("SpiderShard"), (int)(projectile.damage), 0f, projectile.owner, 0f, 0f);
	            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -9.2f + Main.rand.NextFloat(-0.9f, 0.9f), 3.8f + Main.rand.NextFloat(-0.9f, 0.9f), mod.ProjectileType("SpiderShard"), (int)(projectile.damage), 0f, projectile.owner, 0f, 0f);
	            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 9.2f + Main.rand.NextFloat(-0.9f, 0.9f), -3.8f + Main.rand.NextFloat(-0.9f, 0.9f), mod.ProjectileType("SpiderShard"), (int)(projectile.damage), 0f, projectile.owner, 0f, 0f);
	            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -9.2f + Main.rand.NextFloat(-0.9f, 0.9f), -3.8f + Main.rand.NextFloat(-0.9f, 0.9f), mod.ProjectileType("SpiderShard"), (int)(projectile.damage), 0f, projectile.owner, 0f, 0f);

	        }
        }
	}
}