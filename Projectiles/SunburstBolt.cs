using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class SunburstBolt : ModProjectile {

		public override void SetDefaults() {
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 10;
			Projectile.timeLeft = 300;
			Projectile.aiStyle = 29;
			Projectile.alpha = 255;
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
		}
		
		public override void AI() {
			if (Projectile.wet){
				Projectile.timeLeft = 0;
			}
			Lighting.AddLight(Projectile.Center, 0.3f, 0.9f, 0.1f);
			Projectile.ai[0] +=1f;
			Vector2 dustPosition = Projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 158, null, 100, default(Color), 2f);
			dust.velocity *= 3f;
			dust.noGravity = true;
			if (Projectile.ai[0] >= 30f && Projectile.ai[0] < 60f) {
			Projectile.velocity.X = Projectile.velocity.X * 0.92f;
			Projectile.velocity.Y = Projectile.velocity.Y * 0.92f;
			}
			if (Projectile.ai[0] == 60f) {
			Projectile.velocity.X = Projectile.velocity.X * -1;
			Projectile.velocity.Y = Projectile.velocity.Y * -1;
			}
			if (Projectile.ai[0] >= 61f) {
			Projectile.velocity.X = Projectile.velocity.X * 1.0869565f;
			Projectile.velocity.Y = Projectile.velocity.Y * 1.0869565f;
			}
			if (Projectile.ai[0] == 107f) {
			Projectile.timeLeft = 0;
			}
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone){
			target.AddBuff(BuffID.OnFire, 180);
		}
	}
}