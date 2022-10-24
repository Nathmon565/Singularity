using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Legs)]
	public class FrozenLeggings : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("2% increased melee speed");
			ArmorIDs.Legs.Sets.HidesBottomSkin[Item.legSlot] = true;
		}
		public override void SetDefaults() {
			Item.rare = ItemRarityID.Blue;
			Item.value = Singularity.ToCopper(0, 0, 30, 0);
			Item.defense = 3;
		}
		//public override bool DrawLegs()/* tModPorter Note: Removed. In SetStaticDefaults, use ArmorIDs.Legs.Sets.HidesBottomSkin[Item.legSlot] = true if you returned false for an accessory of EquipType.Legs, and ArmorIDs.Shoe.Sets.OverridesLegs[Item.shoeSlot] = true if you returned false for an accessory of EquipType.Shoes */ {
			//return false;
		//}
		public override void UpdateEquip(Player player) {
			player.GetAttackSpeed(DamageClass.Melee) += 0.02f;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "GlacialBar", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}