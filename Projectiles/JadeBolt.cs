using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class JadeBolt : ModProjectile {

		public override void SetDefaults() {
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 600;
			Projectile.aiStyle = 29;
			Projectile.alpha = 255;
			Projectile.width = 16;
			Projectile.height = 16;
		}
		
		public override void AI() {
			Lighting.AddLight(Projectile.Center, 0.6f, 0.5f, 0.9f);
            Projectile.rotation += 0.4f * (float)Projectile.direction;
			Vector2 dustPosition = Projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 273, null, 100, default(Color), 1.2f);
			dust.velocity *= 0.1f;
			dust.noGravity = true;
			Vector2 dustPosition2 = Projectile.Center + new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4));
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 61, null, 100, default(Color), 1.6f);
			dust2.velocity = Projectile.velocity * 0.9f;
			dust2.noGravity = true;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
            Projectile.Kill();
            for (int i = 0; i < 3; i++) {
			}
            return false;
        }   
        public override void Kill(int timeLeft) {
            for (int i = 0; i < 2; i++) {
                float posX = Projectile.Center.X * Main.rand.NextFloat(1f, 1f) + Main.rand.NextFloat(-2f, 2f);
                float posY = Projectile.Center.Y * Main.rand.NextFloat(1f, 1f) + Main.rand.NextFloat(-2f, 2f);
	            float speedX = Projectile.velocity.X * 0.3f + Main.rand.NextFloat(-1.6f, 1.6f);
	            float speedY = Projectile.velocity.Y * 0.3f + Main.rand.NextFloat(-1.6f, 1.6f); 
	            Projectile.NewProjectile(Projectile.GetSource_FromThis(), new Vector2 (posX,posY), new Vector2 (speedX,speedY), 228, (int)(Projectile.damage * 0.3f), 0f, Projectile.owner, 0f, 0f);
			}
        }
	}
}