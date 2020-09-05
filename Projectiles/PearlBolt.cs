using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class PearlBolt : ModProjectile {

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
			Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, projectile.velocity.X * 0.7f, projectile.velocity.Y * 0.7f, 150, default(Color), 1);
			Lighting.AddLight(projectile.Center, 1f, 0.1f, 1f);
			}
			if (projectile.ai[0] >= 34f && projectile.ai[0] < 35f)
			{
			projectile.velocity.X = projectile.velocity.X * 2f;
			projectile.velocity.Y = projectile.velocity.Y * 2f;
			projectile.damage = projectile.damage + 3;
			}
			if (projectile.ai[0] >= 35)
			{
			projectile.ai[0] = 35;
			Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, projectile.velocity.X * 0.7f, projectile.velocity.Y * 0.7f, 150, default(Color), 1);
			Dust.NewDust(projectile.position, projectile.width, projectile.height, 16, projectile.velocity.X * -0.1f, projectile.velocity.Y * -0.1f, 150, default(Color), 1);
			Lighting.AddLight(projectile.Center, 0.9f, 0.7f, 0.9f);
			}
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.Kill();
            return false;
        }   
	}
}