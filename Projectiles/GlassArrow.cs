using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class GlassArrow : ModProjectile {

		
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Glass Arrow");     //The English name of the projectile
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
		}
		public override void SetDefaults() {
			projectile.width = 16;               //The width of projectile hitbox
			projectile.height = 16;              //The height of projectile hitbox
			projectile.aiStyle = 1;             //The ai style of the projectile, please reference the source code of Terraria
			projectile.friendly = true;         //Can the projectile deal damage to enemies?
			projectile.hostile = false;         //Can the projectile deal damage to the player?
			projectile.ranged = true;           //Is the projectile shoot by a ranged weapon?
			//projectile.penetrate = 5;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			//projectile.timeLeft = 600;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			//projectile.alpha = 255;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
			//projectile.light = 0.5f;            //How much light emit around the projectile
			projectile.ignoreWater = false;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = true;          //Can the projectile collide with tiles?
			//projectile.extraUpdates = 2;            //Set to above 0 if you want the projectile to update multiple time in a frame
			projectile.arrow = true;
			aiType = ProjectileID.WoodenArrowFriendly;           //Act exactly like default Bullet
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity) {
			return true;
		}
		
		public override void Kill(int timeLeft){
			float speedY = Main.rand.NextFloat(projectile.velocity.Y/2 -5f,projectile.velocity.Y/2 +5f);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X/2f, speedY, mod.ProjectileType("GlassShard"), (int)(projectile.damage), 0f, projectile.owner);
				speedY = Main.rand.NextFloat(projectile.velocity.Y/2 -5f,projectile.velocity.Y/2 +5f);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X/2f, speedY, mod.ProjectileType("GlassShard"), (int)(projectile.damage), 0f, projectile.owner);
				speedY = Main.rand.NextFloat(projectile.velocity.Y/2 -5f,projectile.velocity.Y/2 +5f);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X/2f, speedY, mod.ProjectileType("GlassShard"), (int)(projectile.damage), 0f, projectile.owner);
				speedY = Main.rand.NextFloat(projectile.velocity.Y/2 -5f,projectile.velocity.Y/2 +5f);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X/2f, speedY, mod.ProjectileType("GlassShard"), (int)(projectile.damage), 0f, projectile.owner);
		}
		
	}
}