using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class OnyxShard : ModProjectile {

		public override void SetDefaults() {
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 12;
			Projectile.aiStyle = 29;
			Projectile.alpha = 255;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.tileCollide = false;
		}
		private const float TrailDensity = 100;
		public override void AI() {
			Vector2 dustPosition = Projectile.Center + new Vector2(Main.rand.Next(-3, 3), Main.rand.Next(-3, 3));
			Dust dust = Dust.NewDustPerfect(dustPosition, 27, null, 100, default(Color), 2f);
			dust.velocity *= 0.1f;
			dust.noGravity = true;
			Vector2 dustPosition2 = Projectile.Center + new Vector2(Main.rand.Next(-3, 3), Main.rand.Next(-3, 3));
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 6, null, 40, default(Color), 2f);
			dust2.velocity = Projectile.velocity * 0f;
			dust2.noGravity = true;
		}
	}
}