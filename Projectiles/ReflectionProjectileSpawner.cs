using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Singularity.Projectiles {
	public class ReflectionProjectileSpawner : ModProjectile {
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			projectile.alpha = 255;
			projectile.timeLeft = 25;
			projectile.knockBack = 0f;
			projectile.tileCollide = false;
		}

		public override void AI(){
			//projectile.spriteDirection = projectile.direction;
			Lighting.AddLight(projectile.Center, 0.5f, 0.55f, 0.5f);
			float posX = projectile.Center.X;
			float posY = projectile.Center.Y;
			projectile.ai[0] += 1f;
			for (int timer=0;timer<22;timer++){
				if (projectile.ai[0] == 5){
					Projectile.NewProjectile(posX, posY, projectile.velocity.X * 0.01f, 0, mod.ProjectileType("ReflectionProjectile"), projectile.damage/3, projectile.knockBack * 0.3f, projectile.owner);
				}
				if (projectile.ai[0] == 10){
					Projectile.NewProjectile(posX, posY, projectile.velocity.X * 0.01f, 0, mod.ProjectileType("ReflectionProjectile"), projectile.damage/3, projectile.knockBack * 0.3f, projectile.owner);
				}
				if (projectile.ai[0] == 15){
					Projectile.NewProjectile(posX, posY, projectile.velocity.X * 0.01f, 0, mod.ProjectileType("ReflectionProjectile"), projectile.damage/2, projectile.knockBack * 0.3f, projectile.owner);
				}
				if (projectile.ai[0] == 20){
					Projectile.NewProjectile(posX, posY, projectile.velocity.X * 0.01f, 0, mod.ProjectileType("ReflectionProjectile"), projectile.damage, projectile.knockBack * 0.3f, projectile.owner);
				}
				if (projectile.ai[0] == 25){
					Projectile.NewProjectile(posX, posY, projectile.velocity.X * 0.01f, 0, mod.ProjectileType("ReflectionProjectile"), projectile.damage, projectile.knockBack * 0.3f, projectile.owner);
				}
			}			
		}
	}
}