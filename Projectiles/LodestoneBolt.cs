using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class LodestoneBolt : ModProjectile {

		public override void SetDefaults() {
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 600;
			Projectile.aiStyle = 29;
			Projectile.alpha = 60;
			Projectile.width = 16;
			Projectile.height = 16;
		}
		public override void AI() {
			Lighting.AddLight(Projectile.Center, 0.6f, 0.5f, 0.9f);
			Projectile.rotation += 0.4f * (float)Projectile.direction;
			Vector2 dustPosition = Projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 58, null, 100, default(Color), 1.2f);
			dust.velocity *= 0.1f;
			dust.noGravity = true;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
			Projectile.Kill(); 
			return false;
		}   
		public override void Kill(int timeLeft) {
			Vector2 dustPosition = Projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 58, null, 100, default(Color), 1.2f);
			dust.velocity *= 0.1f;
			dust.noGravity = true;
			for (int i = 0; i < 4; i++) {
				float posX = Projectile.position.X * Main.rand.NextFloat(1f, 1f) + Main.rand.NextFloat(-50.3f, 50.3f);
				float posY = Projectile.position.Y * Main.rand.NextFloat(1f, 1f) + Main.rand.NextFloat(-80f, -120f) * 6f;
				float speedX = Projectile.velocity.X * Main.rand.NextFloat(0f, 0f) + Main.rand.NextFloat(-1.2f, 1.2f);
				float speedY = Projectile.velocity.Y * Main.rand.NextFloat(0f, 0f) + Main.rand.NextFloat(12f, 10f) * 1.2f; 
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), posX, posY, speedX, speedY, 9, (int)(Projectile.damage), 0f, Projectile.owner, 0f, 0f);
			}
		}
	}
}