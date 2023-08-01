using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.UseItems
{
	// Magic Mirror is one of the only vanilla items that does its action somewhere other than the start of its animation, which is why we use code in UseStyle NOT UseItem.
	// It may prove a useful guide for ModItems with similar behaviors.
	public class MagicHourglass : ModItem
	{
				public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Flip the hourglass to return home");  //The (English) text shown below your weapon's name
		}
		public override void SetDefaults() {
			Item.scale = 0.5f;
            Item.useStyle = 5;
			Item.UseSound = SoundID.Item6;
			Item.rare = 1;

		}

		// UseStyle is called each frame that the item is being actively used.
		public override void UseStyle(Player player, Rectangle heldItemFrame) {
			// Each frame, make some dust
			if (Main.rand.NextBool()) {
				int dust = Dust.NewDust(player.position, player.width, player.height, 57, 0f, 0f, 0, default(Color), 1.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 3f;
                Main.dust[dust].scale += 0.6f;
			}
			// This sets up the itemTime correctly.
			if (player.itemTime == 0) {
				player.itemTime = (int)(Item.useTime / PlayerLoader.TotalUseTimeMultiplier(player, Item));
			}
			else if (player.itemTime == (int)(Item.useTime / PlayerLoader.TotalUseTimeMultiplier(player, Item)) / 2) {
				// This code runs once halfway through the useTime of the item. You'll notice with magic mirrors you are still holding the item for a little bit after you've teleported.

				// Make dust 70 times for a cool effect.
				for (int d = 0; d < 70; d++) {
					int dust2 = Dust.NewDust(player.position, player.width, player.height, 57, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 0, default(Color), 1.5f);
                    Main.dust[dust2].noGravity = true;
                    Main.dust[dust2].velocity *= 3f;
                    Main.dust[dust2].scale += 0.6f;
				}
				// This code releases all grappling hooks and kills them.
				player.grappling[0] = -1;
				player.grapCount = 0;
				for (int p = 0; p < 1000; p++) {
					if (Main.projectile[p].active && Main.projectile[p].owner == player.whoAmI && Main.projectile[p].aiStyle == 7) {
						Main.projectile[p].Kill();
					}
				}
				// The actual method that moves the player back to bed/spawn.
				player.Spawn();
				// Make dust 70 times for a cool effect. This dust is the dust at the destination.
				for (int d = 0; d < 70; d++) {
					int dust3 = Dust.NewDust(player.position, player.width, player.height, 57, 0f, 0f, 0, default(Color), 1.5f);
                    Main.dust[dust3].noGravity = true;
                    Main.dust[dust3].velocity *= 3f;
                    Main.dust[dust3].scale += 0.6f;
				}
			}
		}
	}
}