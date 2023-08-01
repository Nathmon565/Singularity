using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Head)]
	public class TemperedGlassHelmet : ModItem {
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("6% increased damage");
			ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
		}
		public override void SetDefaults() {
			Item.rare = ItemRarityID.Blue;
			Item.value = Singularity.ToCopper(0, 5, 0, 0);
			Item.defense = 7;
		}

		//public override bool DrawHead()/* tModPorter Note: Removed. In SetStaticDefaults, use ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false if you returned false */ {
			//return false;
		//}

		public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Generic) += 0.06f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == Mod.Find<ModItem>("TemperedGlassBreastplate").Type && legs.type == Mod.Find<ModItem>("TemperedGlassLeggings").Type;
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Reflect 500% of damage taken back onto enemies";
			player.GetModPlayer<CoolModPlayer>().TemperedArmorSet = true;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "ReinforcedGlass", 10);
			recipe.AddIngredient(ItemID.FrostCore, 1);
			recipe.AddIngredient(ItemID.SteampunkGoggles, 1);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.Register();
		}
	}
}