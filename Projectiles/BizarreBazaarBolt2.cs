using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class BizarreBazaarBolt2 : ModProjectile {

		public override void SetDefaults() {
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 600;
			Projectile.aiStyle = 29;
			Projectile.alpha = 100;
			Projectile.scale *= 1;
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.tileCollide = true;
=======
>>>>>>> Stashed changes
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 600;
			Projectile.aiStyle = 29;
			Projectile.alpha = 100;
			Projectile.scale *= 1;
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.tileCollide = true;
<<<<<<< Updated upstream
=======
>>>>>>> 1e6f01a5fa3e9140dbb48cf9cbc4101cd15fc073
>>>>>>> Stashed changes
		}
		
		public override void AI() {
			
		}
	}
}