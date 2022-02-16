using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class SunburstBolt : ModProjectile {

		public override void SetDefaults() {
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 10;
			projectile.timeLeft = 300;
			projectile.aiStyle = 29;
			projectile.alpha = 255;
			projectile.width = 32;
			projectile.height = 32;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
		}
		
		public override void AI() {
			if (projectile.wet){
				projectile.timeLeft = 0;
			}
			Lighting.AddLight(projectile.Center, 0.3f, 0.9f, 0.1f);
			projectile.ai[0] +=1f;
			Vector2 dustPosition = projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 158, null, 100, default(Color), 2f);
			dust.velocity *= 3f;
			dust.noGravity = true;
			if (projectile.ai[0] >= 30f && projectile.ai[0] < 60f) {
			projectile.velocity.X = projectile.velocity.X * 0.92f;
			projectile.velocity.Y = projectile.velocity.Y * 0.92f;
			}
			if (projectile.ai[0] == 60f) {
			projectile.velocity.X = projectile.velocity.X * -1;
			projectile.velocity.Y = projectile.velocity.Y * -1;
			}
			if (projectile.ai[0] >= 61f) {
			projectile.velocity.X = projectile.velocity.X * 1.0869565f;
			projectile.velocity.Y = projectile.velocity.Y * 1.0869565f;
			}
			if (projectile.ai[0] == 107f) {
			projectile.timeLeft = 0;
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit){
			target.AddBuff(BuffID.OnFire, 180);
		}
	}
}