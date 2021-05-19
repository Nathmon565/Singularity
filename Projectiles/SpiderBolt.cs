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
			projectile.penetrate = 12;
			projectile.timeLeft = 60;
			projectile.aiStyle = 29;
			projectile.alpha = 60;
			projectile.width = 16;
			projectile.height = 16;
			projectile.scale = 0.7f;
		}
		
		public override void AI() {
			Lighting.AddLight(projectile.Center, 0.6f, 0.5f, 0.9f);
			Dust.NewDust(projectile.position, projectile.width, projectile.height, 1, projectile.velocity.X * 0.7f, projectile.velocity.Y * 0.7f, 5, default(Color), 1);
			Dust.NewDust(projectile.position, projectile.width, projectile.height, 17, projectile.velocity.X * 0.9f, projectile.velocity.Y * 0.9f, 5, default(Color), 1);
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
			//If collide with tile, reduce the penetrate.
			//So the projectile can reflect at most 5 times
			projectile.penetrate--;
			if (projectile.penetrate <= 0) {
				projectile.Kill();
			}
			else {
				Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
				Main.PlaySound(SoundID.Item10, projectile.position);
				if (projectile.velocity.X != oldVelocity.X) {
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y) {
					projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
		}
        public override void Kill(int timeLeft) {
            for (int i = 0; i < 1; i++) {
	            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 3.8f, 9.2f, 27, (int)(projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
	            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -3.8f, 9.2f, 27, (int)(projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
	            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 3.8f, -9.2f, 27, (int)(projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
	            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -3.8f, -9.2f, 27, (int)(projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
	            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 9.2f, 3.8f, 27, (int)(projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
	            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -9.2f, 3.8f, 27, (int)(projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
	            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 9.2f, -3.8f, 27, (int)(projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
	            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -9.2f, -3.8f, 27, (int)(projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);

	        }
        }
	}
}