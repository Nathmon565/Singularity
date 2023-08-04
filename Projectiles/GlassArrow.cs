using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class GlassArrow : ModProjectile {

		
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Glass Arrow");     //The English name of the projectile
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;        //The recording mode
		}
		public override void SetDefaults() {
			Projectile.width = 16;               //The width of projectile hitbox
			Projectile.height = 16;              //The height of projectile hitbox
			Projectile.aiStyle = 1;             //The ai style of the projectile, please reference the source code of Terraria
			Projectile.friendly = true;         //Can the projectile deal damage to enemies?
			Projectile.hostile = false;         //Can the projectile deal damage to the player?
			Projectile.DamageType = DamageClass.Ranged;           //Is the projectile shoot by a ranged weapon?
			//projectile.penetrate = 5;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			//projectile.timeLeft = 600;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			//projectile.alpha = 255;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
			//projectile.light = 0.5f;            //How much light emit around the projectile
			Projectile.ignoreWater = false;          //Does the projectile's speed be influenced by water?
			Projectile.tileCollide = true;          //Can the projectile collide with tiles?
			Projectile.extraUpdates = 0;            //Set to above 0 if you want the projectile to update multiple time in a frame
			Projectile.arrow = true;
			AIType = ProjectileID.WoodenArrowFriendly;           //Act exactly like default Bullet
		}
		public override void Kill(int timeLeft){
			SoundEngine.PlaySound(SoundID.Shatter, Projectile.Center);
			for (int i = 0; i < 6; i++) {
				float posX = Projectile.Center.X * Main.rand.NextFloat(1f, 1f) + Main.rand.NextFloat(-2f, 2f);
				float posY = Projectile.Center.Y * Main.rand.NextFloat(1f, 1f) + Main.rand.NextFloat(-2f, 2f);
				float speedX = Projectile.velocity.X * 0.5f + Main.rand.NextFloat(-1.6f, 1.6f);
				float speedY = Projectile.velocity.Y * 0.5f + Main.rand.NextFloat(-0.6f, 2.6f); 
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), new Vector2(posX, posY), new Vector2(speedX, speedY), Mod.Find<ModProjectile>("GlassShard").Type, (int)(Projectile.damage * 0.1f), 0f, Projectile.owner, 0f, 0f);
				// Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Projectile.velocity, Mod.Find<ModProjectile>("GlassShard").Type, (int)(Projectile.damage * 0.1f), 0f, Projectile.owner, 0f, 0f);
			}
		}
	}
}