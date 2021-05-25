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