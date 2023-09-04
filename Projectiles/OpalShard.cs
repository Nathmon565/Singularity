using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class OpalShard : ModProjectile {

		public override void SetDefaults() {
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 100;
			Projectile.aiStyle = 2;
			Projectile.alpha = 255;
			Projectile.width = 10;
			Projectile.height = 10;
		}
		
		public override void AI() {
			Lighting.AddLight(Projectile.Center, 0.6f, 0.5f, 0.7f);
			Vector2 dustPosition = Projectile.Center + new Vector2(Main.rand.Next(-2, 2), Main.rand.Next(-2, 2));
			Dust dust = Dust.NewDustPerfect(dustPosition, 92, null, 100, default(Color), 1f);
			dust.velocity = Projectile.velocity * 0.9f;
			dust.noGravity = true;
			Lighting.AddLight(Projectile.Center, 0.7f, 0.5f, 1f);
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
				Projectile.Kill();
				return false;
		}
		public override void Kill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Item50, Projectile.Center);
		}
	}
}