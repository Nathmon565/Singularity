using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class BlueJellyImmunity : ModProjectile {

		public override void SetDefaults() {
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 600;
			projectile.aiStyle = 29;
			projectile.alpha = 60;
			projectile.width = 16;
			projectile.height = 16;
		}
		
		public override void AI(Player player) {
			Lighting.AddLight(projectile.Center, 0.6f, 0.5f, 0.9f);
            projectile.rotation = 0;
			Vector2 dustPosition = projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition, 58, null, 100, default(Color), 1.2f);
			dust.velocity *= 0.1f;
			dust.noGravity = true;
		}
	}
}