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
			projectile.penetrate = 2;
			projectile.timeLeft = 600;
			projectile.aiStyle = 29;
			projectile.alpha = 30;
		}
		
		public override void AI() {
			Lighting.AddLight(projectile.Center, 0.6f, 0.5f, 0.9f); // R G B values from 0 to 1f. This is the red from the Crimson Heart pet
			Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, projectile.velocity.X * 0.7f, projectile.velocity.Y * 0.7f, 150, default(Color), 1);
		}

		public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.Kill();
            return false;
        }   
	}
}