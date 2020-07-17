using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Singularity.Projectiles {
	public class PearlBolt : ModProjectile {
		public override void SetDefaults() {
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 2;
			projectile.timeLeft = 600;
			projectile.aiStyle = 0;
		}

		public override void AI() {
			Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 56, projectile.velocity.X * 0.01f, projectile.velocity.Y * 0.01f, 0, default(Color), 1);
		}

		public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.Kill();
            return false;
        }   

		public override void Kill(int timeLeft) {
			for (int k = 0; k < 15; k++) {
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 56, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, default(Color), 1);
			}
			Main.PlaySound(SoundID.Item25, projectile.position);
		}
	}
}