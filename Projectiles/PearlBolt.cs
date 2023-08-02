using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class PearlBolt : ModProjectile {

		public override void SetDefaults() {
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 500;
			Projectile.aiStyle = 29;
			Projectile.alpha = 255;
			Projectile.width = 16;
			Projectile.height = 16;
		}
		
		public override void AI() {
			Lighting.AddLight(Projectile.Center, 0.6f, 0.5f, 0.9f);
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] < 34f)
			{
			Vector2 dustPosition = Projectile.Center + new Vector2(Main.rand.Next(-5, 5), Main.rand.Next(-5, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 173, null, 100, default(Color), 1f);
			dust.velocity *= 0.4f;
			dust.noGravity = true;
            Vector2 dustPosition2 = Projectile.Center + new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4));
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 173, null, 100, default(Color), 1f);
			dust2.velocity = Projectile.velocity * 0.9f;
			dust2.noGravity = true;
			Lighting.AddLight(Projectile.Center, 1f, 0.1f, 1f);
			}
			if (Projectile.ai[0] >= 34f && Projectile.ai[0] < 35f)
			{
			Projectile.velocity.X = Projectile.velocity.X * 2f;
			Projectile.velocity.Y = Projectile.velocity.Y * 2f;
			Projectile.damage = Projectile.damage + 7;
			Projectile.penetrate = Projectile.penetrate + 3;
			}
			if (Projectile.ai[0] >= 35)
			{
			Projectile.ai[0] = 35;
			Vector2 dustPosition3 = Projectile.Center + new Vector2(Main.rand.Next(-5, 5), Main.rand.Next(-5, 5));
			Dust dust3 = Dust.NewDustPerfect(dustPosition3, 264, null, 100, default(Color), 1.4f);
			dust3.velocity *= 0.2f;
			dust3.noGravity = true;
            Vector2 dustPosition4 = Projectile.Center + new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4));
			Dust dust4 = Dust.NewDustPerfect(dustPosition4, 264, null, 100, default(Color), 1.3f);
			dust4.velocity = Projectile.velocity * 0.8f;
			dust4.noGravity = true;
			Lighting.AddLight(Projectile.Center, 1.4f, 1.6f, 1.4f);
			}
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
            Projectile.Kill();
            return false;
        }   
	}
}