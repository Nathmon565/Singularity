using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Projectiles.Minions
{
	internal class SunburstStaffSunburst : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sunburst Sentry"); //The english name of the projectile
			Main.projFrames[projectile.type] = 1;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;

			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 28;
			projectile.height = 56;
			//projectile.scale = 1.0f;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.minion = false;
			projectile.sentry = true; //Sets the weapon as a sentry for sentry accessories to properly work.
			projectile.timeLeft = Projectile.SentryLifeTime;
			projectile.ignoreWater = false; //If this is set to false, the projectile will be slowed in water.
			projectile.tileCollide = true;
			projectile.penetrate = -1;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
			return new Color(255, 255, 255, 0) * (1f - projectile.alpha / 255f);
		}

		bool spawned = false;

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (!spawned) {
				for (int k = 0; k < 25; k++)
				{
					int dust = Dust.NewDust(projectile.position + projectile.velocity + new Vector2(7, 28), 0, 0, 132, 0, 0);
					Main.dust[dust].noGravity = true; //Disable the dust gravity.
					Main.dust[dust].velocity *= 0.8f; //Dust velocity.
				}
				spawned = true;
            }
			return true;
		}

		public override bool? CanCutTiles()
		{
			return false;
		}

		public override void AI()
		{
			//This AI will function as a static sentry, and will not move. If you would like to know how to do more advanced minion AI, check out PurityWisp.cs.

			//projectile.velocity.Y = projectile.velocity.Y + 0.1f; // 0.1f for arrow gravity, 0.4f for knife gravity
			if (projectile.velocity.Y > 16f && projectile.velocity.Y < 950f) // This check implements "terminal velocity". We don't want the projectile to keep getting faster and faster. Past 16f this projectile will travel through blocks, so this check is useful.
			{
				projectile.velocity.Y = 16f;
			}

			int SentryRange = 30; //The sentry's range
			int Speed = 150; //How fast the sentry can shoot the projectile.
			float FireVelocity = 8f; //The velocity the sentry's shot projectile will travel. Slows down the closer the NPC is.
			Main.player[projectile.owner].UpdateMaxTurrets(); //This makes the sentry be able to spawn more if your sentry cap is greater than one.

			Vector2 targetCenter = projectile.position;
			bool foundTarget = false;

			if (Main.player[projectile.owner].HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[Main.player[projectile.owner].MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, projectile.Center);
				bool lineOfSight = Collision.CanHitLine(projectile.position - new Vector2(0, 20), projectile.width, projectile.height-8, npc.position, npc.width, npc.height);
				// Reasonable distance away so it doesn't target across multiple screens
				if ((between < SentryRange * 16) && lineOfSight)
				{
					targetCenter = npc.Center;
					foundTarget = true;
					projectile.ai[1] = npc.whoAmI;
				}
			}
			if (!foundTarget)
			{
				for (int t = 0; t < Main.maxNPCs; t++)
				{
					NPC npc = Main.npc[t];

					float distance = projectile.Distance(npc.Center); //Set the distance from the NPC and the sentry projectile.

					//Convert distance to tile position
					if (distance / 16 < SentryRange && Main.npc[t].active && !Main.npc[t].dontTakeDamage && !Main.npc[t].friendly && Main.npc[t].lifeMax > 5 && Main.npc[t].type != NPCID.TargetDummy && npc.CanBeChasedBy())
					{
						float between = Vector2.Distance(npc.Center, projectile.Center);
						bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
						bool lineOfSight = Collision.CanHitLine(projectile.position - new Vector2 (0, 20), projectile.width, projectile.height, npc.position, npc.width, npc.height);
						if ((closest || !foundTarget) && lineOfSight)
						{
							foundTarget = true;
							targetCenter = npc.Center;
							projectile.ai[1] = npc.whoAmI;
						}
					}
				}
			}
			
			projectile.ai[0]++;
			
			int index = (int)projectile.ai[1];
			if (index < 0 || index > Main.maxNPCs || !foundTarget)
			{
				return; //We have not found a suitable NPC to shoot at, do not execute any further code (Make sure that any non-shoot related code is above this)
			}
			NPC target = Main.npc[index];
			if (projectile.ai[0] % Speed == 5) {
				Vector2 direction = target.Center + new Vector2 (0, 20f) - projectile.Center; //The direction the projectile will fire.

				direction.Normalize(); //Normalizes the direction vector.
				//direction.X *= FireVelocity; //Multiply direction by fireVelocity so the sentry can fire the projectile faster the farther the NPC is away.
				//direction.Y *= FireVelocity; //Same as above, but with Y velocity.

				Main.PlaySound(SoundID.Item102, projectile.Center); //Play a sound.
				int damage = projectile.damage; //How much damage the projectile shot from the sentry will do.
				int type = mod.ProjectileType("SunburstBolt"); //The type of projectile the sentry will shoot. Use ModContent.ProjectileType<>() to fire a modded projectile.
				if (Main.myPlayer == projectile.owner) {
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, 0, FireVelocity, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * 0.966f, FireVelocity * 0.259f, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * 0.866f, FireVelocity * 0.5f, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * 0.707f, FireVelocity * 0.707f, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * 0.5f, FireVelocity * 0.866f, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * 0.259f, FireVelocity * 0.966f, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity, 0, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * 0.966f, FireVelocity * -0.259f, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * 0.866f, FireVelocity * -0.5f, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * 0.707f, FireVelocity * -0.707f, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * 0.5f, FireVelocity * -0.866f, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * 0.259f, FireVelocity * -0.966f, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, 0, -FireVelocity, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * -0.966f, FireVelocity * -0.259f, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * -0.866f, FireVelocity * -0.5f, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * -0.707f, FireVelocity * -0.707f, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * -0.5f, FireVelocity * -0.866f, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * -0.259f, FireVelocity * -0.966f, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, -FireVelocity, 0, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * -0.966f, FireVelocity * 0.259f, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * -0.866f, FireVelocity * 0.5f, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * -0.707f, FireVelocity * 0.707f, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * -0.5f, FireVelocity * 0.866f, type, damage, 3, projectile.owner);
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, FireVelocity * -0.259f, FireVelocity * 0.966f, type, damage, 3, projectile.owner);
					
				}
			}
			//projectile.ai[1] = -1;
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