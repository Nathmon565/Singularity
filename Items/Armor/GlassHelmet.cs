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
			Item.defense = 2;
		}

		//public override bool DrawHead()/* tModPorter Note: Removed. In SetStaticDefaults, use ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false if you returned false */ {
			//return false;
		//}

		public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Generic) += 0.04f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == Mod.Find<ModItem>("GlassBreastplate").Type && legs.type == Mod.Find<ModItem>("GlassLeggings").Type;
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "8% increased damage \n-2 defense";
			player.GetDamage(DamageClass.Generic) += 0.16f;
			player.statDefense -= 2;
		}
    }
}