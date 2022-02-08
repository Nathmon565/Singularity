using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Head)]
	public class GlassHelmet : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("8% increased damage");
		}
		public override void SetDefaults() {
			item.rare = ItemRarityID.Blue;
			item.value = Singularity.ToCopper(0, 0, 30, 0);
			item.defense = 1;
		}

		public override bool DrawHead() {
			return false;
		}

		public override void UpdateEquip(Player player) {
			player.allDamage += 0.08f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("GlassBreastplate") && legs.type == mod.ItemType("GlassLeggings");
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "16% increased damage \n-2 defense";
			player.allDamage += 0.16f;
			player.statDefense -= 2;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Goggles, 1);
			recipe.AddIngredient(ItemID.Glass, 25);
			recipe.AddIngredient(ItemID.FossilOre, 12);
			recipe.AddTile(TileID.GlassKiln);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}