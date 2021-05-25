using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class OnyxBolt : ModProjectile {

		public override void SetDefaults() {
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 200;
			projectile.aiStyle = 29;
			projectile.alpha = 255;
			projectile.width = 16;
			projectile.height = 16;
		}
		
		public override void AI() {
			Lighting.AddLight(projectile.Center, 0.6f, 0.5f, 0.9f);
        	Vector2 dustPosition = projectile.Center + new Vector2(Main.rand.Next(-5, 5), Main.rand.Next(-5, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 21, null, 100, default(Color), 1f);
			dust.velocity *= 0.2f;
			dust.noGravity = true;
        	Vector2 dustPosition2 = projectile.Center + new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4));
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 21, null, 100, default(Color), 1f);
			dust2.velocity = projectile.velocity * 0.9f;
			dust2.noGravity = true;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.Kill();
            return false;
        }   
        public override void Kill(int timeLeft) {
	        for (int i = 0; i < 1; i++) {
	            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("OnyxMarker"), (int)(projectile.damage * 1f), 0f, projectile.owner, 0f, 0f);
			}
        }
	}
}