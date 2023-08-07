using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class OpalBolt : ModProjectile {

		public override void SetDefaults() {
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 600;
			Projectile.aiStyle = 29;
			Projectile.alpha = 255;
			Projectile.width = 16;
			Projectile.height = 16;
		}

	private const float TrailDensity = 2;		
		public override void AI() {
			Vector2 dustPosition = Projectile.Center + new Vector2(Main.rand.Next(-5, 5), Main.rand.Next(-5, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 15, null, 100, default(Color), 1.5f);
			dust.velocity *= 0.2f;
			dust.noGravity = true;
			Vector2 dustPosition2 = Projectile.Center + new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4));
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 15, null, 100, default(Color), 1.6f);
			dust2.velocity = Projectile.velocity * 0.9f;
			dust2.noGravity = true;
			Lighting.AddLight(Projectile.Center, 0.7f, 0.5f, 1f);			
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] >= 19f && Projectile.ai[0] < 20f  && Projectile.owner == Main.myPlayer)
			for (int i = 0; i < 1; i++)
			{
			float speedX = Main.rand.NextFloat(-0.2f, 0.2f);
			float speedY = Main.rand.NextFloat(-2f, -1f); 
		    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Projectile.velocity, Mod.Find<ModProjectile>("OpalShard").Type, (int)(Projectile.damage * 0.5), 0f, Projectile.owner, 0f, 0f);
			}
			if (Projectile.ai[0] >= 20f)
			{
			Projectile.ai[0] = (Main.rand.Next(0, 19));
			}
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
            Projectile.Kill();
            return false;
        }   
	}
}