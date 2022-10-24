using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class SulfurBolt : ModProjectile {

		public override void SetDefaults() {
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 40;
			Projectile.timeLeft = 600;
			Projectile.aiStyle = 29;
			Projectile.alpha = 255;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
		}
		
		public override void AI() {
			Lighting.AddLight(Projectile.Center, 0.6f, 0.5f, 0.9f);
			Projectile.ai[0] +=1f;
			Vector2 dustPosition = Projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 57, null, 100, default(Color), 1.2f);
			dust.velocity *= 0.1f;
			dust.noGravity = true;
			Vector2 dustPosition2 = Projectile.Center + new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4));
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 75, null, 100, default(Color), 1.6f);
			dust2.velocity = Projectile.velocity * 0.9f;
			dust2.noGravity = true;
			if (Projectile.ai[0] >= 30f && Projectile.ai[0] < 45f) {
			Projectile.velocity.X = Projectile.velocity.X * 0.85f;
			Projectile.velocity.Y = Projectile.velocity.Y * 0.85f;
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 106, (Main.rand.Next(-5, 5)), (Main.rand.Next(-5, 5)), 5, default(Color), 1);
			}
			if (Projectile.ai[0] >= 60f && Projectile.ai[0] < 75f) {
			Projectile.velocity.X = Projectile.velocity.X * 1.1764059f;
			Projectile.velocity.Y = Projectile.velocity.Y * 1.1764059f;
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 106, (Main.rand.Next(-5, 5)), (Main.rand.Next(-5, 5)), 5, default(Color), 1);
			}
			if (Projectile.ai[0] >= 75f) {
			Projectile.ai[0] = 0;
			}
		}
	}
}