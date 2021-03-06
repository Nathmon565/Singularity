using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class PearlBolt : ModProjectile {

		public override void SetDefaults() {
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 500;
			projectile.aiStyle = 29;
			projectile.alpha = 255;
			projectile.width = 16;
			projectile.height = 16;
		}
		
		public override void AI() {
			Lighting.AddLight(projectile.Center, 0.6f, 0.5f, 0.9f);
			projectile.ai[0] += 1f;
			if (projectile.ai[0] < 34f)
			{
			Vector2 dustPosition = projectile.Center + new Vector2(Main.rand.Next(-5, 5), Main.rand.Next(-5, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 173, null, 100, default(Color), 1f);
			dust.velocity *= 0.4f;
			dust.noGravity = true;
        	Vector2 dustPosition2 = projectile.Center + new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4));
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 173, null, 100, default(Color), 1f);
			dust2.velocity = projectile.velocity * 0.9f;
			dust2.noGravity = true;
			Lighting.AddLight(projectile.Center, 1f, 0.1f, 1f);
			}
			if (projectile.ai[0] >= 34f && projectile.ai[0] < 35f)
			{
			projectile.velocity.X = projectile.velocity.X * 2f;
			projectile.velocity.Y = projectile.velocity.Y * 2f;
			projectile.damage = projectile.damage + 7;
			projectile.penetrate = projectile.penetrate + 3;
			}
			if (projectile.ai[0] >= 35)
			{
			projectile.ai[0] = 35;
			Vector2 dustPosition3 = projectile.Center + new Vector2(Main.rand.Next(-5, 5), Main.rand.Next(-5, 5));
			Dust dust3 = Dust.NewDustPerfect(dustPosition3, 264, null, 100, default(Color), 1.4f);
			dust3.velocity *= 0.2f;
			dust3.noGravity = true;
        	Vector2 dustPosition4 = projectile.Center + new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4));
			Dust dust4 = Dust.NewDustPerfect(dustPosition4, 264, null, 100, default(Color), 1.3f);
			dust4.velocity = projectile.velocity * 0.8f;
			dust4.noGravity = true;
			Lighting.AddLight(projectile.Center, 1.4f, 1.6f, 1.4f);
			}
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.Kill();
            return false;
        }   
	}
}