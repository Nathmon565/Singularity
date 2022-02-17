using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class GlassShard : ModProjectile {

		public override void SetDefaults() {
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 20;
			projectile.aiStyle = 2;
			projectile.alpha = 0;
			projectile.width = 5;
			projectile.height = 5;
			projectile.scale *= 1f;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.Kill();
            return false;
        }
		public override void AI() {
            projectile.rotation += 0.4f * (float)projectile.direction;
		}		
	}
}