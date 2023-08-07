using System.Threading;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Weapons
{

	public class SaguaroStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}
        public override void SetDefaults()
		{
			Item.damage = 30;
            Item.sentry = true;
			Item.mana = 10; //How much mana this weapon takes to use.
			Item.width = 26; //Item width hitbox.
			Item.height = 28; //Item height hitbox.
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.DamageType = DamageClass.Summon;
			Item.noMelee = true; //Restricts this weapon dealing melee damage.
			Item.knockBack = 0;
			Item.value = Item.buyPrice(0, 0, 50, 0); //How much this item is sold for.
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item83;
            Item.shoot = ModContent.ProjectileType<SaguaroStaffSaguaro>();
		}
        
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            damage /= 6;
            position = Main.MouseWorld - new Vector2(0, 28);   //this make so the projectile will spawn at the mouse cursor position
            velocity.Y = 1000f;
            Projectile.NewProjectile(Item.GetSource_FromThis(), position, velocity, type, damage, knockback);

            return false;
        }
        /*public override bool AltFunctionUse(Player player)
        {
            return true;
        }*/
    }
    public class SaguaroStaffSaguaro : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
            Main.projFrames[Projectile.type] = 1;
            Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }
        public override void SetDefaults()
		{
			Projectile.width = 22;
			Projectile.height = 80;
			//projectile.scale = 1.0f;
			Projectile.friendly = true;
            //Projectile.usesLocalNPCImmunity = true;
			Projectile.DamageType = DamageClass.Summon;
			//Projectile.minion = true;
			Projectile.sentry = true; //Sets the weapon as a sentry for sentry accessories to properly work.
			Projectile.timeLeft = Projectile.SentryLifeTime;
			Projectile.ignoreWater = true; //If this is set to false, the projectile will be slowed in water.
			Projectile.tileCollide = true;
			Projectile.penetrate = -1;
		}
        public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
			//return new Color(255, 255, 255, 0) * (1f - Projectile.alpha / 255f);
		}
        bool spawned = false;
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (!spawned) {
				for (int k = 0; k < 25; k++)
				{
					int dust = Dust.NewDust(Projectile.position + Projectile.velocity + new Vector2(8, 40), 0, 0, 2, 0, 0);
					Main.dust[dust].noGravity = true; //Disable the dust gravity.
					Main.dust[dust].velocity *= 2.0f; //Dust velocity.
				}
				spawned = true;
            }
			return false;
		}
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            fallThrough = false;
            return base.TileCollideStyle(ref width, ref height, ref fallThrough, ref hitboxCenterFrac);
        }
        public override bool? CanCutTiles()
		{
			return false;
		}
        public override bool MinionContactDamage()
		{
			return true;
		}
        private int timer;
        public override void AI()
		{
			//This AI will function as a static sentry, and will not move. If you would like to know how to do more advanced minion AI, check out PurityWisp.cs.

			Projectile.velocity.Y = Projectile.velocity.Y + 0.1f; // 0.1f for arrow gravity, 0.4f for knife gravity
			if (Projectile.velocity.Y > 16f && Projectile.velocity.Y < 950f) // This check implements "terminal velocity". We don't want the projectile to keep getting faster and faster. Past 16f this projectile will travel through blocks, so this check is useful.
			{
				Projectile.velocity.Y = 16f;
			}

			int SentryRange = 70; //The sentry's range
			int Speed = 180; //How fast the sentry can shoot the projectile.
			float FireVelocity = 30f; //The velocity the sentry's shot projectile will travel. Slows down the closer the NPC is.
			Player player = Main.player[Projectile.owner];
            player.UpdateMaxTurrets(); //This makes the sentry be able to spawn more if your sentry cap is greater than one.
            timer++;

			Vector2 targetCenter = Projectile.position;
			bool foundTarget = false;

            if (timer > 120){
                if (Main.player[Projectile.owner].HasMinionAttackTargetNPC)
                {
                    NPC npc = Main.npc[Main.player[Projectile.owner].MinionAttackTargetNPC];
                    float between = Vector2.Distance(npc.Center, Projectile.Center);
                    bool lineOfSight = Collision.CanHitLine(Projectile.position - new Vector2(0, 20), Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
                    // Reasonable distance away so it doesn't target across multiple screens
                    if ((between < SentryRange * 16) && lineOfSight)
                    {
                        targetCenter = npc.Center;
                        foundTarget = true;
                        Projectile.ai[1] = npc.whoAmI;
                    }
                }
                if (!foundTarget)
                {
                    for (int t = 0; t < Main.maxNPCs; t++)
                    {
                        NPC npc = Main.npc[t];

                        float distance = Projectile.Distance(npc.Center); //Set the distance from the NPC and the sentry projectile.

                        //Convert distance to tile position
                        if (distance / 16 < SentryRange && Main.npc[t].active && !Main.npc[t].dontTakeDamage && !Main.npc[t].friendly && Main.npc[t].lifeMax > 5 && Main.npc[t].type != NPCID.TargetDummy && npc.CanBeChasedBy())
                        {
                            float between = Vector2.Distance(npc.Center, Projectile.Center);
                            bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
                            bool lineOfSight = Collision.CanHitLine(Projectile.position - new Vector2 (0, 20), Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
                            if ((closest || !foundTarget) && lineOfSight)
                            {
                                foundTarget = true;
                                targetCenter = npc.Center;
                                Projectile.ai[1] = npc.whoAmI;
                            }
                        }
                    }
                }
                
                Projectile.ai[0]++;
                
                int index = (int)Projectile.ai[1];
                if (index < 0 || index > Main.maxNPCs || !foundTarget)
                {
                    return; //We have not found a suitable NPC to shoot at, do not execute any further code (Make sure that any non-shoot related code is above this)
                }
                NPC target = Main.npc[index];
                if (Projectile.ai[0] % Speed == 5) {
                    Vector2 direction = target.Center + new Vector2 (0, 20f) - Projectile.Center; //The direction the projectile will fire.

                    direction.Normalize(); //Normalizes the direction vector.
                    direction.X *= FireVelocity; //Multiply direction by fireVelocity so the sentry can fire the projectile faster the farther the NPC is away.
                    direction.Y *= FireVelocity; //Same as above, but with Y velocity.

                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Item102, Projectile.Center); //Play a sound.
                    int damage = Projectile.damage * 6; //How much damage the projectile shot from the sentry will do.
                    int type = ProjectileID.PineNeedleFriendly; //The type of projectile the sentry will shoot. Use ModContent.ProjectileType<>() to fire a modded projectile.
                    if (Main.myPlayer == Projectile.owner) {
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position + new Vector2 (0, 20f), new Vector2(direction.X,direction.Y), type, damage, 3, Projectile.owner);
                    }
                }
            }
			//projectile.ai[1] = -1;
			//Animate the projectile.
			Projectile.frameCounter++;
			if (Projectile.frameCounter % 10 == 0)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
				if (Projectile.frame >= 4)
					Projectile.frame = 0;
			}
		}
    }
}