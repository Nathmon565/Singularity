using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class OpalBolt : ModProjectile {

		public override void SetDefaults() {
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 600;
			Projectile.aiStyle = 29;
			Projectile.alpha = 255;
			Projectile.width = 16;
			Projectile.height = 16;
		}
		public override void AI() {
			Vector2 dustPosition = Projectile.Center + new Vector2(Main.rand.Next(-2, 2), Main.rand.Next(-2, 2));
			Dust dust = Dust.NewDustPerfect(dustPosition, 92, null, 100, default(Color), 1.3f);
			dust.velocity = Projectile.velocity * new Vector2(Main.rand.Next(0, 1));
			dust.noGravity = true;
			int dust1 = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Shadowflame, 0f, 0f);
			int moredust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Shadowflame, 0f, 0f);
			int evenmoredust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Shadowflame, 0f, 0f);
			Lighting.AddLight(Projectile.Center, 0.7f, 0.5f, 1f);			
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] >= 39f && Projectile.ai[0] < 40f  && Projectile.owner == Main.myPlayer)
			for (int i = 0; i < 1; i++)
			{
            float speedX = Main.rand.NextFloat(-0.2f, 0.2f);
            float speedY = Main.rand.NextFloat(-2f, -1f); 
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position,  new Vector2(speedX, speedY), Mod.Find<ModProjectile>("OpalShard").Type, (int)(Projectile.damage * 0.5), 0f, Projectile.owner, 0f, 0f);
			}
			if (Projectile.ai[0] >= 40) {
            Projectile.ai[0] = (Main.rand.Next(20, 35));
			}
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
         Projectile.Kill();
         return false;
      }   
      public override void Kill(int timeLeft) {
         SoundEngine.PlaySound(SoundID.Item27, Projectile.Center);
      }
	}
}