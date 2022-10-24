using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class OnyxBolt : ModProjectile {

		public override void SetDefaults() {
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 200;
			Projectile.aiStyle = 29;
			Projectile.alpha = 255;
			Projectile.width = 16;
			Projectile.height = 16;
		}
		
		public override void AI() {
			Lighting.AddLight(Projectile.Center, 0.6f, 0.5f, 0.9f);
        	Vector2 dustPosition = Projectile.Center + new Vector2(Main.rand.Next(-5, 5), Main.rand.Next(-5, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 27, null, 100, default(Color), 1f);
			dust.velocity *= 0.2f;
			dust.noGravity = true;
        	Vector2 dustPosition2 = Projectile.Center + new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4));
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 27, null, 100, default(Color), 1f);
			dust2.velocity = Projectile.velocity * 0.9f;
			dust2.noGravity = true;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
            Projectile.Kill();
            return false;
        }   
        public override void Kill(int timeLeft) {
	        for (int i = 0; i < 1; i++) {
			float speed = 10f;
			float spot = 3f;
			Projectile.NewProjectile(Projectile.Center.X + 0f * spot, Projectile.Center.Y + 20f * spot, speed * 0.309f, speed * -0.951f, Mod.Find<ModProjectile>("OnyxShard").Type, (int)(Projectile.damage*0.3f), 0f, Projectile.owner, 0f, 0f);
			Projectile.NewProjectile(Projectile.Center.X + 19.021f * spot, Projectile.Center.Y + 6.181f * spot, speed * -0.809f, speed * -0.588f, Mod.Find<ModProjectile>("OnyxShard").Type, (int)(Projectile.damage*0.3f), 0f, Projectile.owner, 0f, 0f);
			Projectile.NewProjectile(Projectile.Center.X - 19.021f * spot, Projectile.Center.Y + 6.181f * spot, speed, speed * 0, Mod.Find<ModProjectile>("OnyxShard").Type, (int)(Projectile.damage*0.3f), 0f, Projectile.owner, 0f, 0f);
			Projectile.NewProjectile(Projectile.Center.X - 11.756f * spot, Projectile.Center.Y - 16.180f * spot, speed * 0.309f, speed * 0.951f, Mod.Find<ModProjectile>("OnyxShard").Type, (int)(Projectile.damage*0.3f), 0f, Projectile.owner, 0f, 0f);
			Projectile.NewProjectile(Projectile.Center.X + 11.756f * spot, Projectile.Center.Y - 16.180f * spot, speed * -0.809f, speed* 0.588f, Mod.Find<ModProjectile>("OnyxShard").Type, (int)(Projectile.damage*0.3f), 0f, Projectile.owner, 0f, 0f);
			}
        }
	}
}