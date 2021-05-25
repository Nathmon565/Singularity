using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class OpalShard : ModProjectile {

		public override void SetDefaults() {
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 100;
			projectile.aiStyle = 2;
			projectile.alpha = 255;
			projectile.width = 10;
			projectile.height = 10;
		}
		
		public override void AI() {
			Lighting.AddLight(projectile.Center, 0.6f, 0.5f, 0.7f);
        	Vector2 dustPosition = projectile.Center + new Vector2(Main.rand.Next(-5, 5), Main.rand.Next(-5, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 135, null, 100, default(Color), 1f);
			dust.velocity *= 0.2f;
			dust.noGravity = true;
        	Vector2 dustPosition2 = projectile.Center + new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4));
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 135, null, 100, default(Color), 1f);
			dust2.velocity = projectile.velocity * 0.9f;
			dust2.noGravity = true;
			Lighting.AddLight(projectile.Center, 0.7f, 0.5f, 1f);	        }
		
		public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.Kill();
            return false;
        }   
	}
}