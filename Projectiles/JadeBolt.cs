using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class JadeBolt : ModProjectile {

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
			Lighting.AddLight(projectile.Center, 0.6f, 0.5f, 0.9f);
            projectile.rotation += 0.4f * (float)projectile.direction;
			Vector2 dustPosition = projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 273, null, 100, default(Color), 1.2f);
			dust.velocity *= 0.1f;
			dust.noGravity = true;
			Vector2 dustPosition2 = projectile.Center + new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4));
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 61, null, 100, default(Color), 1.6f);
			dust2.velocity = projectile.velocity * 0.9f;
			dust2.noGravity = true;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.Kill();
            for (int i = 0; i < 3; i++) {
	        }
            return false;
        }   
        public override void Kill(int timeLeft) {
            for (int i = 0; i < 2; i++) {
                float posX = projectile.Center.X * Main.rand.NextFloat(1f, 1f) + Main.rand.NextFloat(-2f, 2f);
                float posY = projectile.Center.Y * Main.rand.NextFloat(1f, 1f) + Main.rand.NextFloat(-2f, 2f);
	            float speedX = projectile.velocity.X * 0.3f + Main.rand.NextFloat(-1.6f, 1.6f);
	            float speedY = projectile.velocity.Y * 0.3f + Main.rand.NextFloat(-1.6f, 1.6f); 
	            Projectile.NewProjectile(posX, posY, speedX, speedY, 228, (int)(projectile.damage * 0.3f), 0f, projectile.owner, 0f, 0f);
	        }
        }
	}
}