using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class BizarreBazaarBolt1 : ModProjectile {

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
			Projectile.scale *= 2;
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.tileCollide = true;
=======
>>>>>>> Stashed changes
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 600;
			Projectile.aiStyle = 29;
			Projectile.alpha = 100;
			Projectile.scale *= 2;
			Projectile.width = 32;
			Projectile.height = 32;
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