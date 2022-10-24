using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Singularity.Projectiles {
	public class ReflectionProjectileSpawner : ModProjectile {
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			Projectile.alpha = 255;
			Projectile.timeLeft = 25;
			Projectile.knockBack = 0f;
			Projectile.tileCollide = false;
		}

		public override void AI(){
			//projectile.spriteDirection = projectile.direction;
			Lighting.AddLight(Projectile.Center, 0.5f, 0.55f, 0.5f);
			float posX = Projectile.Center.X;
			float posY = Projectile.Center.Y;
			Projectile.ai[0] += 1f;
			for (int timer=0;timer<22;timer++){
				if (Projectile.ai[0] == 5){
					Projectile.NewProjectile(posX, posY, Projectile.velocity.X * 0.01f, 0, Mod.Find<ModProjectile>("ReflectionProjectile").Type, Projectile.damage/3, Projectile.knockBack * 0.3f, Projectile.owner);
				}
				if (Projectile.ai[0] == 10){
					Projectile.NewProjectile(posX, posY, Projectile.velocity.X * 0.01f, 0, Mod.Find<ModProjectile>("ReflectionProjectile").Type, Projectile.damage/3, Projectile.knockBack * 0.3f, Projectile.owner);
				}
				if (Projectile.ai[0] == 15){
					Projectile.NewProjectile(posX, posY, Projectile.velocity.X * 0.01f, 0, Mod.Find<ModProjectile>("ReflectionProjectile").Type, Projectile.damage/2, Projectile.knockBack * 0.3f, Projectile.owner);
				}
				if (Projectile.ai[0] == 20){
					Projectile.NewProjectile(posX, posY, Projectile.velocity.X * 0.01f, 0, Mod.Find<ModProjectile>("ReflectionProjectile").Type, Projectile.damage, Projectile.knockBack * 0.3f, Projectile.owner);
				}
				if (Projectile.ai[0] == 25){
					Projectile.NewProjectile(posX, posY, Projectile.velocity.X * 0.01f, 0, Mod.Find<ModProjectile>("ReflectionProjectile").Type, Projectile.damage, Projectile.knockBack * 0.3f, Projectile.owner);
				}
			}			
		}
	}
}