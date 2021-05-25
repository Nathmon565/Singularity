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
			projectile.penetrate = 40;
			projectile.timeLeft = 600;
			projectile.aiStyle = 29;
			projectile.alpha = 255;
			projectile.width = 16;
			projectile.height = 16;
		}
		
		public override void AI() {
			Lighting.AddLight(projectile.Center, 0.6f, 0.5f, 0.9f);
			projectile.ai[0] +=1f;
			Vector2 dustPosition = projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 57, null, 100, default(Color), 1.2f);
			dust.velocity *= 0.1f;
			dust.noGravity = true;
			Vector2 dustPosition2 = projectile.Center + new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4));
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 75, null, 100, default(Color), 1.6f);
			dust2.velocity = projectile.velocity * 0.9f;
			dust2.noGravity = true;
			if (projectile.ai[0] >= 30f && projectile.ai[0] < 45f) {
			projectile.velocity.X = projectile.velocity.X * 0.85f;
			projectile.velocity.Y = projectile.velocity.Y * 0.85f;
			Dust.NewDust(projectile.position, projectile.width, projectile.height, 106, (Main.rand.Next(-5, 5)), (Main.rand.Next(-5, 5)), 5, default(Color), 1);
			}
			if (projectile.ai[0] >= 60f && projectile.ai[0] < 75f) {
			projectile.velocity.X = projectile.velocity.X * 1.1764059f;
			projectile.velocity.Y = projectile.velocity.Y * 1.1764059f;
			Dust.NewDust(projectile.position, projectile.width, projectile.height, 106, (Main.rand.Next(-5, 5)), (Main.rand.Next(-5, 5)), 5, default(Color), 1);
			}
			if (projectile.ai[0] >= 75f) {
			projectile.ai[0] = 0;
			}
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.Kill();
            return false;
        }   
	}
}