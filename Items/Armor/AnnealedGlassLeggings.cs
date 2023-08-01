using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Legs)]
	public class AnnealedGlassLeggings : ModItem {
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("12% increased damge");
			ArmorIDs.Legs.Sets.HidesBottomSkin[Item.legSlot] = true;
		}
		public override void SetDefaults() {
			Item.rare = ItemRarityID.Blue;
			Item.value = Singularity.ToCopper(0, 3, 0, 0);
			Item.defense = 5;
		}
		//public override bool DrawLegs()/* tModPorter Note: Removed. In SetStaticDefaults, use ArmorIDs.Legs.Sets.HidesBottomSkin[Item.legSlot] = true if you returned false for an accessory of EquipType.Legs, and ArmorIDs.Shoe.Sets.OverridesLegs[Item.shoeSlot] = true if you returned false for an accessory of EquipType.Shoes */ {
			//return false;
		//}
		public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Generic) += 0.12f;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "ReinforcedGlass", 16);
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 1);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.Register();
		}
	}
}