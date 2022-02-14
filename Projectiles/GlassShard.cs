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
			projectile.penetrate = 3;
			projectile.timeLeft = 20;
			projectile.aiStyle = 0;
			projectile.alpha = 0;
			projectile.width = 3;
			projectile.height = 3;
			projectile.scale *= 0.5f;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.Kill();
            return false;
        }		
	}
}