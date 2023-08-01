using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Head)]
	public class AnnealedGlassHelmet : ModItem {
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("12% increased damage");
			ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
		}
		public override void SetDefaults() {
			Item.rare = ItemRarityID.Blue;
			Item.value = Singularity.ToCopper(0, 5, 0, 0);
			Item.defense = 4;
		}

		//public override bool DrawHead()/* tModPorter Note: Removed. In SetStaticDefaults, use ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false if you returned false */ {
			//return false;
		//}
		
		public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Generic) += 0.12f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == Mod.Find<ModItem>("AnnealedGlassBreastplate").Type && legs.type == Mod.Find<ModItem>("AnnealedGlassLeggings").Type;
		}

		
		public override void UpdateArmorSet(Player player) {
			player.setBonus = "10% chance to gain 100% damage and -6 defense after being hit";
			player.GetModPlayer<CoolModPlayer>().AnnealedArmorSet = true;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "ReinforcedGlass", 10);
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 1);
			recipe.AddIngredient(ItemID.SteampunkGoggles, 1);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.Register();
		}
	}
}