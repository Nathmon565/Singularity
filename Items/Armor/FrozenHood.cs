using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Head)]
	public class FrozenHood : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("2% increased melee speed");
		}
		public override void SetDefaults() {
			item.rare = ItemRarityID.Blue;
			item.value = Singularity.ToCopper(0, 0, 30, 0);
			item.defense = 3;
		}

		public override bool DrawHead() {
			return false;
		}

		public override void UpdateEquip(Player player) {
			player.meleeSpeed += 12f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("FrozenBreastplate") && legs.type == mod.ItemType("FrozenLeggings");
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "+2 defense";
			player.statDefense += 2;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "IceCubes", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}