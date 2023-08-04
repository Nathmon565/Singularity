using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class BloodstoneShard : ModProjectile {

		public override void SetDefaults() {
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 4;
			Projectile.timeLeft = 100;
			Projectile.aiStyle = 2;
			Projectile.alpha = 255;
			Projectile.width = 10;
			Projectile.height = 10;
		}
		
		public override void AI() {
            Vector2 dustPosition = Projectile.Center + new Vector2(Main.rand.Next(-5, 5), Main.rand.Next(-5, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 5, null, 100, default(Color), 1f);
			dust.velocity *= 0.2f;
			dust.noGravity = true;
            Vector2 dustPosition2 = Projectile.Center + new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4));
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 115, null, 100, default(Color), 1f);
			dust2.velocity = Projectile.velocity * 0.9f;
			dust2.noGravity = true;
			Lighting.AddLight(Projectile.Center, 0.7f, 0.2f, 0.2f);
        }
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            if(Main.rand.NextFloat() < 0.5f){
            target.AddBuff(31, 60);
		}
        }
		public override bool OnTileCollide(Vector2 oldVelocity) {
            Projectile.Kill();
            return false;
        }   
	}
}