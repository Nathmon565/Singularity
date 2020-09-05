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
			projectile.alpha = 60;
		}
		
		public override void AI() {
			Lighting.AddLight(projectile.Center, 0.6f, 0.5f, 0.7f);
            Dust.NewDust(projectile.position, projectile.width, projectile.height, 135, projectile.velocity.X * 0.7f, projectile.velocity.Y * 0.7f, 150, default(Color), 1);
        }
		
		public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.Kill();
            return false;
        }   
	}
}