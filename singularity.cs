using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Singularity.Buffs;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

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
		public bool SkellyJellyNecklace;
		public bool VialofLightning;

		public override void ResetEffects() {
			Jellybone = false;
			SkellyJellyNecklace = false;
			VialofLightning = false;
		}

		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
			ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {
			if(Jellybone && SkellyJellyNecklace) {
				if (!player.HasBuff(ModContent.BuffType<JellyboneBuff>()) && !player.HasBuff(ModContent.BuffType<JellyboneBuff2>()))
				{
					playSound = false;
					player.immune = true;
					//player.immuneAlpha = 0;
					player.immuneTime = 450;
					player.AddBuff(ModContent.BuffType<JellyboneBuff2>(), 2700);
					Main.PlaySound(SoundID.NPCHit25);
					return false;
				}
			}
			else if(Jellybone || SkellyJellyNecklace) {
				if (!player.HasBuff(ModContent.BuffType<JellyboneBuff>()) && !player.HasBuff(ModContent.BuffType<JellyboneBuff2>()))
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

		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore,
            ref PlayerDeathReason damageSource) {
            
			return true;
			}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit) {
			if(VialofLightning)
			{
				target.AddBuff(ModContent.BuffType<ShockedBuff>(), 120);
			}
		}
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit) {
			if(VialofLightning)
			{
				target.AddBuff(ModContent.BuffType<ShockedBuff>(), 120);
			}
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
		
		internal class SkellyJellyNecklace : ModItem
			{
				public override void SetStaticDefaults()
				{
					DisplayName.SetDefault("Skelly-Jelly Necklace");
					Tooltip.SetDefault("Generates a very subtle glow which becomes more vibrant underwater \n\nIncreases armor penetration by 5 \n\nBecome immune for one hit \n\nTakes 30 seconds to recharge");
				}

				public override void SetDefaults()
				{
					item.width = 24; 
					item.height = 28;
					item.value = Singularity.ToCopper(0, 1, 30, 0);
					item.rare = 2;
					item.accessory = true;
				}

				public override void UpdateAccessory(Player player, bool hideVisual)
				{
					player.GetModPlayer<CoolModPlayer>().SkellyJellyNecklace = true;
					player.armorPenetration += 5;
					Lighting.AddLight(player.position, 0.3f, 0.1f, 0.1f);
					if (player.wet) {
					Lighting.AddLight(player.position, 1.2f, 0.8f, 0.8f);
					}
				}


				public override void AddRecipes()
				{
					ModRecipe recipe = new ModRecipe(mod);
					recipe.AddIngredient(ItemID.SharkToothNecklace, 1);
					recipe.AddIngredient(ItemID.JellyfishNecklace, 1);
					recipe.AddIngredient(null, "Jellybone", 1);
					recipe.AddTile(TileID.TinkerersWorkbench);
					recipe.SetResult(this);
					recipe.AddRecipe();
				}
			}
		internal class VialofLightning : ModItem
			{
				public override void SetStaticDefaults()
				{
					DisplayName.SetDefault("Vial of Lightning");
					Tooltip.SetDefault("Inflicts Shocked on hit");
				}

				public override void SetDefaults()
				{
					item.width = 24; 
					item.height = 28;
					item.value = Singularity.ToCopper(0, 2, 0, 0);
					item.rare = 8;
					item.accessory = true;
				}
				public override void UpdateAccessory(Player player, bool hideVisual)
				{
					player.GetModPlayer<CoolModPlayer>().VialofLightning = true;
				}
			}
	}
}
