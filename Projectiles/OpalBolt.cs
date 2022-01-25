using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class OpalBolt : ModProjectile {

		public override void SetDefaults() {
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 600;
			projectile.aiStyle = 29;
			projectile.alpha = 255;
			projectile.width = 16;
			projectile.height = 16;
		}

	private const float TrailDensity = 2;		
		public override void AI() {
        	Vector2 dustPosition = projectile.Center + new Vector2(Main.rand.Next(-5, 5), Main.rand.Next(-5, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 15, null, 100, default(Color), 1.5f);
			dust.velocity *= 0.2f;
			dust.noGravity = true;
        	Vector2 dustPosition2 = projectile.Center + new Vector2(Main.rand.Next(-4, 4), Main.rand.Next(-4, 4));
			Dust dust2 = Dust.NewDustPerfect(dustPosition2, 15, null, 100, default(Color), 1.6f);
			dust2.velocity = projectile.velocity * 0.9f;
			dust2.noGravity = true;
			Lighting.AddLight(projectile.Center, 0.7f, 0.5f, 1f);			
			projectile.ai[0] += 1f;
			if (projectile.ai[0] >= 9f && projectile.ai[0] < 10f  && projectile.owner == Main.myPlayer)
	        for (int i = 0; i < 1; i++)
	        {
	    	float speedX = Main.rand.NextFloat(-0.2f, 0.2f);
	    	float speedY = Main.rand.NextFloat(-2f, -1f); 
		    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, speedX, speedY, mod.ProjectileType("OpalShard"), (int)(projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
        	}
			if (projectile.ai[0] >= 10f)
			{
			projectile.ai[0] = 0;
			}
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.Kill();
            return false;
        }   
	}
}