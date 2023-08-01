using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Head)]
	public class FrozenHood : ModItem {
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("2% increased melee speed");
			ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
		}
		public override void SetDefaults() {
			Item.rare = ItemRarityID.Blue;
			Item.value = Singularity.ToCopper(0, 0, 30, 0);
			Item.defense = 3;
		}

		//public override bool DrawHead()/* tModPorter Note: Removed. In SetStaticDefaults, use ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false if you returned false */ {
			//return false;
		//}

		public override void UpdateEquip(Player player) {
			player.GetAttackSpeed(DamageClass.Melee) += 0.02f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == Mod.Find<ModItem>("FrozenBreastplate").Type && legs.type == Mod.Find<ModItem>("FrozenLeggings").Type;
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "+2 defense";
			player.statDefense += 2;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "GlacialBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}