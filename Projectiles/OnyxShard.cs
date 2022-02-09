using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class OnyxShard : ModProjectile {

		public override void SetDefaults() {
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 12;
			projectile.aiStyle = 29;
			projectile.alpha = 255;
			projectile.width = 16;
			projectile.height = 16;
			projectile.tileCollide = false;
		}
		private const float TrailDensity = 100;
		public override void AI() {
        	Vector2 dustPosition = projectile.Center + new Vector2(Main.rand.Next(-3, 3), Main.rand.Next(-3, 3));
			Dust dust = Dust.NewDustPerfect(dustPosition, 27, null, 100, default(Color), 1f);
			dust.velocity *= 0.1f;
			dust.noGravity = true;
        	Vector2 dustPosition2 = projectile.Center + new Vector2(Main.rand.Next(-3, 3), Main.rand.Next(-3, 3));
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 6, null, 40, default(Color), 1f);
			dust2.velocity = projectile.velocity * 0f;
			dust2.noGravity = true;
       }
	}
}