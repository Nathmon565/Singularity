using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class OnyxMarker : ModProjectile {

		public override void SetDefaults() {
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 100;
			projectile.timeLeft = 77;
			projectile.aiStyle = 29;
			projectile.alpha = 255;
			projectile.width = 10;
			projectile.height = 10;
			projectile.tileCollide = false;
		}
		
		public override void AI() {
			projectile.ai[0] += 1f;
			if (projectile.ai[0] >= 1f && projectile.ai[0] < 2f) {
			float speed = 10f;
			float spot = 3f;
			Projectile.NewProjectile(projectile.position.X + 0f * spot, projectile.position.Y + 20f * spot, speed * 0.309f, speed * -0.951f, mod.ProjectileType("OnyxShard"), (int)(projectile.damage), 0f, projectile.owner, 0f, 0f);
			Projectile.NewProjectile(projectile.position.X + 19.021f * spot, projectile.position.Y + 6.181f * spot, speed * -0.809f, speed * -0.588f, mod.ProjectileType("OnyxShard"), (int)(projectile.damage), 0f, projectile.owner, 0f, 0f);
			Projectile.NewProjectile(projectile.position.X - 19.021f * spot, projectile.position.Y + 6.181f * spot, speed, speed * 0, mod.ProjectileType("OnyxShard"), (int)(projectile.damage), 0f, projectile.owner, 0f, 0f);
			Projectile.NewProjectile(projectile.position.X - 11.756f * spot, projectile.position.Y - 16.180f * spot, speed * 0.309f, speed * 0.951f, mod.ProjectileType("OnyxShard"), (int)(projectile.damage), 0f, projectile.owner, 0f, 0f);
			Projectile.NewProjectile(projectile.position.X + 11.756f * spot, projectile.position.Y - 16.180f * spot, speed * -0.809f, speed* 0.588f, mod.ProjectileType("OnyxShard"), (int)(projectile.damage), 0f, projectile.owner, 0f, 0f);
			}
			if (projectile.ai[0] >= 12f) {
			projectile.ai[0] = 0;
			}
         }
	}
}