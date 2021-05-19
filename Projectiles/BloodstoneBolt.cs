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
			projectile.alpha = 60;
			projectile.width = 16;
			projectile.height = 16;
		}
		
		public override void AI() {
			Lighting.AddLight(projectile.position, 1f, 0.5f, 0.4f);
			Dust.NewDust(projectile.position, projectile.width, projectile.height, 5, projectile.velocity.X * 0.7f, projectile.velocity.Y * 0.7f, 5, default(Color), 1);
			Dust.NewDust(projectile.position, projectile.width, projectile.height, 115, projectile.velocity.X * 0.7f, projectile.velocity.Y * 0.7f, 5, default(Color), 1);
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.Kill();
            return false;
        }   
        public override void Kill(int timeLeft) {
            for (int i = 0; i < 3; i++) {
                float posX = projectile.position.X * Main.rand.NextFloat(1f, 1f) + Main.rand.NextFloat(-2f, 2f);
                float posY = projectile.position.Y * Main.rand.NextFloat(1f, 1f) + Main.rand.NextFloat(-5f, -7f);
	            float speedX = projectile.velocity.X * Main.rand.NextFloat(0f, 0f) + Main.rand.NextFloat(-0.5f, 0.5f);
	            float speedY = projectile.velocity.Y * Main.rand.NextFloat(0f, 0f) + Main.rand.NextFloat(-4f, -7f); 
	            Projectile.NewProjectile(posX, posY, speedX, speedY, 280, (int)(projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
	        }
        }
	}
}