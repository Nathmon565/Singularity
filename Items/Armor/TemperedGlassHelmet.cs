using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Head)]
	public class TemperedGlassHelmet : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("6% increased damage");
		}
		public override void SetDefaults() {
			item.rare = ItemRarityID.Blue;
			item.value = Singularity.ToCopper(0, 5, 0, 0);
			item.defense = 7;
		}

		public override bool DrawHead() {
			return false;
		}

		public override void UpdateEquip(Player player) {
			player.allDamage += 0.06f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("TemperedGlassBreastplate") && legs.type == mod.ItemType("TemperedGlassLeggings");
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Reflect 500% of damage taken back onto enemies";
			player.GetModPlayer<CoolModPlayer>().TemperedArmorSet = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ReinforcedGlass", 10);
			recipe.AddIngredient(ItemID.FrostCore, 1);
			recipe.AddIngredient(ItemID.SteampunkGoggles, 1);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}