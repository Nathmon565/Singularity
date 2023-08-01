using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class BloodstoneBolt : ModProjectile {

		public override void SetDefaults() {
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 600;
			Projectile.aiStyle = 29;
			Projectile.alpha = 255;
			Projectile.width = 16;
			Projectile.height = 16;
		}
		
		public override void AI() {
			Lighting.AddLight(Projectile.position, 1.2f, 0.5f, 0.4f);
			Vector2 dustPosition = Projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 5, null, 100, default(Color), 1.2f);
			dust.velocity *= 0.1f;
			dust.noGravity = true;
			Vector2 dustPosition2 = Projectile.Center + new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4));
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 115, null, 100, default(Color), 1.6f);
			dust2.velocity = Projectile.velocity * 0.9f;
			dust2.noGravity = true;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			for (int i = 0; i < 4; i++) {
			float speedX = Projectile.velocity.X * Main.rand.NextFloat(1.1f, 1.3f) + Main.rand.NextFloat(-0.9f, 0.9f);
			float speedY = Projectile.velocity.Y * Main.rand.NextFloat(1.1f, 1.3f) + Main.rand.NextFloat(-0.9f, 0.9f);
	        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Projectile.velocity, Mod.Find<ModProjectile>("BloodstoneShard").Type, (int)(Projectile.damage * 0.2), 0f, Projectile.owner, 0f, 0f);
			}
			Projectile.Kill();
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
			for (int i = 0; i < 4; i++) {
            float speedX = Projectile.velocity.X;
			float speedY = Projectile.velocity.Y;
			if (Projectile.velocity.X != oldVelocity.X) {
			speedX = -oldVelocity.X;
			speedY = Projectile.velocity.Y + Main.rand.NextFloat(-0.5f, 0.5f);
			}
			if (Projectile.velocity.Y != oldVelocity.Y) {
			speedY = -oldVelocity.Y;
			speedX = Projectile.velocity.X + Main.rand.NextFloat(-0.5f, 0.5f);
			}
	        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Projectile.velocity, Mod.Find<ModProjectile>("BloodstoneShard").Type, (int)(Projectile.damage * 0.2), 0f, Projectile.owner, 0f, 0f);
			}
			Projectile.Kill();
            return false;
		}
	}
}