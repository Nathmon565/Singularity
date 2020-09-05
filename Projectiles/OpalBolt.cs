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
			projectile.alpha = 60;
		}
		
		public override void AI() {
			Lighting.AddLight(projectile.Center, 0.6f, 0.5f, 0.9f);
			projectile.ai[0] += 1f;
			if (projectile.ai[0] < 34f)
			{
			Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, projectile.velocity.X * 0.7f, projectile.velocity.Y * 0.7f, 150, default(Color), 1);
			Lighting.AddLight(projectile.Center, 0.7f, 0.5f, 1f);
			}
			if (projectile.ai[0] >= 9f && projectile.ai[0] < 10f  && projectile.owner == Main.myPlayer)
	        for (int i = 0; i < 1; i++)
	        {
	    	float speedX = Main.rand.NextFloat(-1.2f, 1.2f);
	    	float speedY = Main.rand.NextFloat(-2f, -1f); 
		    Projectile.NewProjectile(projectile.position.X + speedX, projectile.position.Y + speedY, speedX, speedY, mod.ProjectileType("OpalShard"), (int)(projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
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