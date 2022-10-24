using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Legs)]
	public class GlassLeggings : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("8% increased damge");
			ArmorIDs.Legs.Sets.HidesBottomSkin[Item.legSlot] = true;
		}
		public override void SetDefaults() {
			Item.rare = ItemRarityID.Blue;
			Item.value = Singularity.ToCopper(0, 0, 30, 0);
			Item.defense = 2;
		}
		//public override bool DrawLegs()/* tModPorter Note: Removed. In SetStaticDefaults, use ArmorIDs.Legs.Sets.HidesBottomSkin[Item.legSlot] = true if you returned false for an accessory of EquipType.Legs, and ArmorIDs.Shoe.Sets.OverridesLegs[Item.shoeSlot] = true if you returned false for an accessory of EquipType.Shoes */ {
			//return false;
		//}
		public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Generic) += 0.08f;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Glass, 25);
			recipe.AddIngredient(ItemID.FossilOre, 8);
			recipe.AddTile(TileID.GlassKiln);
			recipe.Register();
		}
	}
}