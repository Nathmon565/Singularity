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
			projectile.timeLeft = 15;
			projectile.aiStyle = 0;
			projectile.alpha = 0;
			projectile.width = 6;
			projectile.height = 6;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.Kill();
            return false;
        }		
	}
}