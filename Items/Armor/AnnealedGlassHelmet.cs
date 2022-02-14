using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Head)]
	public class AnnealedGlassHelmet : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("12% increased damage");
		}
		public override void SetDefaults() {
			item.rare = ItemRarityID.Blue;
			item.value = Singularity.ToCopper(0, 5, 0, 0);
			item.defense = 4;
		}

		public override bool DrawHead() {
			return false;
		}
		public override void UpdateEquip(Player player) {
			player.allDamage += 0.12f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("AnnealedGlassBreastplate") && legs.type == mod.ItemType("AnnealedGlassLeggings");
		}

		
		public override void UpdateArmorSet(Player player) {
			player.setBonus = "10% chance to gain 100% damage and -6 defense after being hit";
			player.GetModPlayer<CoolModPlayer>().AnnealedArmorSet = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ReinforcedGlass", 10);
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 1);
			recipe.AddIngredient(ItemID.SteampunkGoggles, 1);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}