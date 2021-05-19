using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class SulfurBolt : ModProjectile {

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
			Lighting.AddLight(projectile.Center, 0.6f, 0.5f, 0.9f);
            projectile.rotation += 0.4f * (float)projectile.direction;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.Kill();
            for (int i = 0; i < 3; i++) {
                float posX = projectile.position.X * Main.rand.NextFloat(1f, 1f) + Main.rand.NextFloat(-2f, 2f);
                float posY = projectile.position.Y * Main.rand.NextFloat(1f, 1f) + Main.rand.NextFloat(-80f, -88f) * 4f;
	            float speedX = projectile.velocity.X * Main.rand.NextFloat(0f, 0f) + Main.rand.NextFloat(-0.4f, 0.4f);
	            float speedY = projectile.velocity.Y * Main.rand.NextFloat(0f, 0f) + Main.rand.NextFloat(12f, 10f) * 1.2f; 
	            Projectile.NewProjectile(posX, posY, speedX, speedY, 9, (int)(projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
	        }
            return false;
        }   
        public override void Kill(int timeLeft) {
            for (int i = 0; i < 3; i++) {
                float posX = projectile.position.X * Main.rand.NextFloat(1f, 1f) + Main.rand.NextFloat(-2f, 2f);
                float posY = projectile.position.Y * Main.rand.NextFloat(1f, 1f) + Main.rand.NextFloat(-80f, -88f) * 4f;
	            float speedX = projectile.velocity.X * Main.rand.NextFloat(0f, 0f) + Main.rand.NextFloat(-0.4f, 0.4f);
	            float speedY = projectile.velocity.Y * Main.rand.NextFloat(0f, 0f) + Main.rand.NextFloat(12f, 10f) * 1.2f; 
	            Projectile.NewProjectile(posX, posY, speedX, speedY, 9, (int)(projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
	        }
        }
	}
}