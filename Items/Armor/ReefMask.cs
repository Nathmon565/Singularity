using Terraria;
using Terraria.ModLoader;
using Terraria.ID;


namespace Singularity.Items.Armor {
	[AutoloadEquip(EquipType.Head)]
	public class ReefMask : ModItem {
		private int bonusBreath = 0;
		private int bonusBreathInterval = 3;
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Reduces damage taken by 2%");
		}
		public override void SetDefaults() {
			item.rare = ItemRarityID.Blue;
			item.value = Singularity.ToCopper(0, 0, 30, 0);
			item.defense = 4;
		}

		public override bool DrawHead() {
			return false;
		}
        public override void UpdateEquip(Player player) {
			player.allDamage -= 0.01f;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("ReefVest") && legs.type == mod.ItemType("ReefPants");
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = ("+8% magic critical strike chance"
			+ "\nLets you move swiftly in liquids"
			+ "\nGreatly extends underwater breathing");
			player.magicCrit += 8;
            if (player.wet) {
                player.moveSpeed +=1.7f;
            }
			if(player.breath < player.breathMax) {
				bonusBreath++;
			} else {
				bonusBreath = 0;
			}
			if(bonusBreath >= bonusBreathInterval && player.breath >0) {
				player.breathCD--;
				bonusBreath = 0;
			}
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Nacre", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}