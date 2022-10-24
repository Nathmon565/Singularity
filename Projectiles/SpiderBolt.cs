using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class SpiderBolt : ModProjectile {

		public override void SetDefaults() {
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 60;
			Projectile.aiStyle = 29;
			Projectile.alpha = 255;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.scale = 0.7f;
		}
		
		public override void AI() {
			Lighting.AddLight(Projectile.Center, 0.7f, 0.6f, 0.7f);
			Vector2 dustPosition = Projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 1, null, 100, default(Color), 1.2f);
			dust.velocity *= 0.1f;
			dust.noGravity = true;
			Vector2 dustPosition2 = Projectile.Center + new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4));
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 1, null, 100, default(Color), 1.6f);
			dust2.velocity = Projectile.velocity * 0.9f;
			dust2.noGravity = true;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
				Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
				if (Projectile.velocity.X != oldVelocity.X) {
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y) {
					Projectile.velocity.Y = -oldVelocity.Y;
			}
			return false;
		}
        public override void Kill(int timeLeft) {
            for (int i = 0; i < 1; i++) {
	            Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, 3.8f, 9.2f, Mod.Find<ModProjectile>("SpiderShard").Type, (int)(Projectile.damage), 0, Projectile.owner, 0, 0f);
	            Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, -3.8f, 9.2f, Mod.Find<ModProjectile>("SpiderShard").Type, (int)(Projectile.damage), 0, Projectile.owner, 0, 0f);
	            Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, 3.8f, -9.2f, Mod.Find<ModProjectile>("SpiderShard").Type, (int)(Projectile.damage), 0, Projectile.owner, 0, 0f);
	            Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, -3.8f, -9.2f, Mod.Find<ModProjectile>("SpiderShard").Type, (int)(Projectile.damage), 0, Projectile.owner, 0, 0f);
	            Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, 9.2f, 3.8f, Mod.Find<ModProjectile>("SpiderShard").Type, (int)(Projectile.damage), 0, Projectile.owner, 0, 0f);
	            Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, -9.2f, 3.8f, Mod.Find<ModProjectile>("SpiderShard").Type, (int)(Projectile.damage), 0, Projectile.owner, 0, 0f);
	            Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, 9.2f, -3.8f, Mod.Find<ModProjectile>("SpiderShard").Type, (int)(Projectile.damage), 0, Projectile.owner, 0, 0f);
	            Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, -9.2f, -3.8f, Mod.Find<ModProjectile>("SpiderShard").Type, (int)(Projectile.damage), 0, Projectile.owner, 0, 0f);

	        }
        }
	}
}