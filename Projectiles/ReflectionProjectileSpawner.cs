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
			projectile.timeLeft = 21;
			projectile.knockBack = 0f;
		}

		public override void AI(){
			float posX = projectile.position.X;
			float posY = projectile.position.Y - 16f;
			projectile.ai[0] += 1f;
			for (int timer=0;timer<22;timer++){
				if (projectile.ai[0] == 1){
					Projectile.NewProjectile(posX, posY, 0, 0, mod.ProjectileType("ReflectionProjectile0"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
				}
				if (projectile.ai[0] == 6){
					Projectile.NewProjectile(posX + 32, posY, 0, 0, mod.ProjectileType("ReflectionProjectile1"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
					Projectile.NewProjectile(posX - 32, posY, 0, 0, mod.ProjectileType("ReflectionProjectile1"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
				}
				if (projectile.ai[0] == 11){
					Projectile.NewProjectile(posX + 64, posY, 0, 0, mod.ProjectileType("ReflectionProjectile2"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
					Projectile.NewProjectile(posX - 64, posY, 0, 0, mod.ProjectileType("ReflectionProjectile2"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
				}
				if (projectile.ai[0] == 16){
					Projectile.NewProjectile(posX + 96, posY, 0, 0, mod.ProjectileType("ReflectionProjectile3"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
					Projectile.NewProjectile(posX - 96, posY, 0, 0, mod.ProjectileType("ReflectionProjectile3"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
				}
				if (projectile.ai[0] == 21){
					Projectile.NewProjectile(posX + 128, posY, 0, 0, mod.ProjectileType("ReflectionProjectile4"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
					Projectile.NewProjectile(posX - 128, posY, 0, 0, mod.ProjectileType("ReflectionProjectile4"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
				}
			}
			
			
	}
}
}