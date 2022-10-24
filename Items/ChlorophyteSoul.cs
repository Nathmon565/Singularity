using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace Singularity.Items {
	public class ChlorophyteSoul : ModItem {
		public override void SetStaticDefaults(){
			DisplayName.SetDefault("Soul of Chlorophyte");
			Tooltip.SetDefault("'The essence of regenerative creatures'");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}
		public override void SetDefaults() {
			Item refItem = new Item();
			refItem.SetDefaults(ItemID.SoulofSight);
			Item.width = refItem.width;
			Item.height = refItem.height;
			Item.maxStack = 999;
			Item.value = Singularity.ToCopper(0, 0, 3, 0);
			Item.rare = ItemRarityID.Orange;
		}
		public override void GrabRange(Player player, ref int grabRange) {
			grabRange *= 3;
		}

		public override bool GrabStyle(Player player) {
			Vector2 vectorItemToPlayer = player.Center - Item.Center;
			Vector2 movement = -vectorItemToPlayer.SafeNormalize(default(Vector2)) * 0.1f;
			Item.velocity = Item.velocity + movement;
			Item.velocity = Collision.TileCollision(Item.position, Item.velocity, Item.width, Item.height);
			return true;
		}

		public override void PostUpdate() {
			Lighting.AddLight(Item.Center, Color.Green.ToVector3() * 0.55f * Main.essScale);
		}
	}
}