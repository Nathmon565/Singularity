using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Head)]
	public class GlassHelmet : ModItem {
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("8% increased damage");
			ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
		}
		public override void SetDefaults() {
			Item.rare = ItemRarityID.Blue;
			Item.value = Singularity.ToCopper(0, 0, 30, 0);
			Item.defense = 1;
		}

		//public override bool DrawHead()/* tModPorter Note: Removed. In SetStaticDefaults, use ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false if you returned false */ {
			//return false;
		//}

		public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Generic) += 0.08f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == Mod.Find<ModItem>("GlassBreastplate").Type && legs.type == Mod.Find<ModItem>("GlassLeggings").Type;
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "16% increased damage \n-2 defense";
			player.GetDamage(DamageClass.Generic) += 0.16f;
			player.statDefense -= 2;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Goggles, 1);
			recipe.AddIngredient(ItemID.Glass, 25);
			recipe.AddIngredient(ItemID.FossilOre, 12);
			recipe.AddTile(TileID.GlassKiln);
			recipe.Register();
		}
	}
}