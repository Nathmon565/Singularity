using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class GlassShard : ModProjectile {

		public override void SetDefaults() {
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 20;
			Projectile.aiStyle = 2;
			Projectile.alpha = 0;
			Projectile.width = 5;
			Projectile.height = 5;
			Projectile.scale *= 1f;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
            Projectile.Kill();
            return false;
        }
		public override void AI() {
            Projectile.rotation += 0.4f * (float)Projectile.direction;
		}		
	}
}