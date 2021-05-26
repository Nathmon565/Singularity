using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Projectiles.Minions
{
	internal class SnowmanStaffSnowman : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snowman"); //The english name of the projectile
			Main.projFrames[projectile.type] = 1;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;

			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 38;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.sentry = true; //Sets the weapon as a sentry for sentry accessories to properly work.
			projectile.timeLeft = Projectile.SentryLifeTime;
			projectile.ignoreWater = false; //If this is set to false, the projectile will be slowed in water.
			projectile.tileCollide = false;
			projectile.penetrate = -1;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
			return new Color(255, 255, 255, 0) * (1f - projectile.alpha / 255f);
		}

		public override void AI()
		{
			//This AI will function as a static sentry, and will not move. If you would like to know how to do more advanced minion AI, check out PurityWisp.cs.

			for (int k = 0; k < 1; k++) {
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 132, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
				Main.dust[dust].noGravity = true; //Disable the dust gravity.
				Main.dust[dust].velocity *= 0.8f; //Dust velocity.
			}

			int SentryRange = 40; //The sentry's range
			int Speed = 60; //How fast the sentry can shoot the projectile.
			float FireVelocity = 15f; //The velocity the sentry's shot projectile will travel. Slows down the closer the NPC is.
			
			
			Main.player[projectile.owner].UpdateMaxTurrets(); //This makes the sentry be able to spawn more if your sentry cap is greater than one.
			for (int t = 0; t < Main.maxNPCs; t++)
			{
				NPC npc = Main.npc[t];
				//if (!npc.active || !npc.CanBeChasedBy()) {
					//return; //Do not check NPCs that don't exist or can't/shouldn't be damaged
				//}

				float distance = projectile.Distance(npc.Center); //Set the distance from the NPC and the sentry projectile.
				
				//Convert distance to tile position
				if (distance / 16 < SentryRange) {
					projectile.ai[1] = npc.whoAmI;
				}
			}
			projectile.ai[0]++;
			int index = (int)projectile.ai[1];
			if (index < 0 || index > Main.maxNPCs)
			{
				return; //We have not found a suitable NPC to shoot at, do not execute any further code (Make sure that any non-shoot related code is above this)
			}
			NPC target = Main.npc[index];
			if (projectile.ai[0] % Speed == 5) {
				Vector2 direction = target.Center - projectile.Center; //The direction the projectile will fire.

				direction.Normalize(); //Normalizes the direction vector.
				direction.X *= FireVelocity; //Multiply direction by fireVelocity so the sentry can fire the projectile faster the farther the NPC is away.
				direction.Y *= FireVelocity; //Same as above, but with Y velocity.

				Main.PlaySound(SoundID.Item102, projectile.Center); //Play a sound.
				int damage = 18; //How much damage the projectile shot from the sentry will do.
				int type = ProjectileID.SnowBallFriendly; //The type of projectile the sentry will shoot. Use ModContent.ProjectileType<>() to fire a modded projectile.
				if (Main.myPlayer == projectile.owner) {
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, direction.X, direction.Y, type, damage, 3, projectile.owner);
				}
			}
			//Animate the projectile.
			projectile.frameCounter++;
			if (projectile.frameCounter % 10 == 0)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
				if (projectile.frame >= 4)
					projectile.frame = 0;
			}
		}
	}
}