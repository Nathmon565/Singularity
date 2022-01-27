using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Singularity.Buffs;
using Terraria.DataStructures;

namespace Singularity {
	class Singularity : Mod {
		public static int ToCopper(int Platinum = 0, int Gold = 0, int Silver = 0, int Copper = 0) {
			Platinum *= 1000000;
			Gold *= 10000;
			Silver *= 100;
			return Platinum + Gold + Silver + Copper;
		}
	}

	public class CoolModPlayer : ModPlayer {
		public bool Jellybone;

		public override void ResetEffects() {
			Jellybone = false;
		}

		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
			ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {
			if(Jellybone) {
				if (!player.HasBuff(ModContent.BuffType<JellyboneBuff>()))
				{
					playSound = false;
					player.immune = true;
					//player.immuneAlpha = 0;
					player.immuneTime = 300;
					player.AddBuff(ModContent.BuffType<JellyboneBuff>(), 1800);
					Main.PlaySound(SoundID.NPCHit25);
					return false;
				}
			}    
			return true;
			}
	}

	namespace Items.Accessories {
		internal class Jellybone : ModItem
			{
				public override void SetStaticDefaults()
				{
					DisplayName.SetDefault("Jellybone");
					Tooltip.SetDefault("Become immune for one hit \n\nTakes 30 seconds to recharge");
				}

				public override void SetDefaults()
				{
					item.width = 24; 
					item.height = 28;
					item.value = Singularity.ToCopper(0, 0, 30, 0);
					item.rare = 2;
					item.accessory = true;
				}

				public override void UpdateAccessory(Player player, bool hideVisual)
				{
					player.GetModPlayer<CoolModPlayer>().Jellybone = true;
				}


				public override void AddRecipes()
				{
					ModRecipe recipe = new ModRecipe(mod);
					recipe.AddIngredient(ItemID.BlueJellyfish, 1);
					recipe.AddIngredient(ItemID.Bone, 50);
					recipe.AddTile(TileID.Anvils);
					recipe.SetResult(this);
					recipe.AddRecipe();
					recipe.AddIngredient(ItemID.PinkJellyfish, 1);
					recipe.AddIngredient(ItemID.Bone, 50);
					recipe.AddTile(TileID.Anvils);
					recipe.SetResult(this);
					recipe.AddRecipe();
					recipe.AddIngredient(ItemID.GreenJellyfish, 1);
					recipe.AddIngredient(ItemID.Bone, 50);
					recipe.AddTile(TileID.Anvils);
					recipe.SetResult(this);
					recipe.AddRecipe();	
				}
			}
	}
}
