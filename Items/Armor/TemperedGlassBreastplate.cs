using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Body)]
	public class TemperedGlassBreastplate : ModItem {
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("6% increased damage");
			ArmorIDs.Body.Sets.HidesTopSkin[Item.bodySlot] = true;
		}
		public override void SetDefaults() {
			Item.rare = ItemRarityID.Blue;
			Item.value = Singularity.ToCopper(0, 4, 0, 0);
			Item.defense = 14;
		}

		//public override bool DrawBody()/* tModPorter Note: Removed. In SetStaticDefaults, use ArmorIDs.Body.Sets.HidesTopSkin[Item.bodySlot] = true if you returned false */ {
			//return false;
		//}

		public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Generic) += 0.06f;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "ReinforcedGlass", 20);
			recipe.AddIngredient(ItemID.FrostCore, 1);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.Register();
		}
	}
}