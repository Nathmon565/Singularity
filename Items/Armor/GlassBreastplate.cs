using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Body)]
	public class GlassBreastplate : ModItem {
		public override void SetStaticDefaults() {
            // Tooltip.SetDefault("8% increased damage");
		}
		public override void SetDefaults() {
            Item.rare = ItemRarityID.Blue;
			Item.value = Singularity.ToCopper(0, 0, 30, 0);
			Item.defense = 3;
		}
		public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Generic) += 0.08f;
		}
    }
}