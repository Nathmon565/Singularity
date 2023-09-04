using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class SeafoamBolt : ModProjectile {

		public override void SetDefaults() {
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 12;
			Projectile.timeLeft = 400;
			Projectile.aiStyle = 0;
			Projectile.alpha = 255;
			Projectile.width = 16;
			Projectile.height = 16;
		}
		private const float TrailDensity = 300;
		public override void AI() {
         Projectile.velocity.Y+=0.5f;
			Lighting.AddLight(Projectile.Center, 0.6f, 0.5f, 0.9f);
			Vector2 dustPosition = Projectile.Center + new Vector2(Main.rand.Next(-2, 2), Main.rand.Next(-2, 2));
			Dust dust = Dust.NewDustPerfect(dustPosition, 16, null, 100, default(Color), 1.2f);
         dust.velocity *= 0.4f;
			dust.noGravity = true;
         dust.scale *= 0.9f;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
      SoundEngine.PlaySound(SoundID.Item10, Projectile.Center);
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Projectile.velocity.X != oldVelocity.X) {
				Projectile.velocity.X = -oldVelocity.X;
			}
			if (Projectile.velocity.Y != oldVelocity.Y) {
				Projectile.velocity.Y = -oldVelocity.Y;
			}
			return false;
		}   
	}
}