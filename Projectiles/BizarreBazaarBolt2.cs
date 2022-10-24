using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class BizarreBazaarBolt2 : ModProjectile {

		public override void SetDefaults() {
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 600;
			projectile.aiStyle = 29;
			projectile.alpha = 100;
			projectile.scale *= 1;
			projectile.width = 20;
			projectile.height = 20;
			projectile.tileCollide = true;
		}
		
		public override void AI() {
			
		}
	}
}