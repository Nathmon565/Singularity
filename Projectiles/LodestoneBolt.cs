using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class LodestoneBolt : ModProjectile {

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
			Vector2 dustPosition = projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 58, null, 100, default(Color), 1.2f);
			dust.velocity *= 0.1f;
			dust.noGravity = true;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.Kill(); 
            return false;
        }   
        public override void Kill(int timeLeft) {
            for (int i = 0; i < 4; i++) {
                float posX = projectile.position.X * Main.rand.NextFloat(1f, 1f) + Main.rand.NextFloat(-1.3f, 1.3f);
                float posY = projectile.position.Y * Main.rand.NextFloat(1f, 1f) + Main.rand.NextFloat(-80f, -88f) * 6f;
	            float speedX = projectile.velocity.X * Main.rand.NextFloat(0f, 0f) + Main.rand.NextFloat(-1.2f, 1.2f);
	            float speedY = projectile.velocity.Y * Main.rand.NextFloat(0f, 0f) + Main.rand.NextFloat(12f, 10f) * 1.2f; 
	            Projectile.NewProjectile(posX, posY, speedX + projectile.velocity.X * 0.2f, speedY, 9, (int)(projectile.damage), 0f, projectile.owner, 0f, 0f);
	        }
        }
	}
}