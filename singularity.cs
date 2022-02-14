using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Singularity.Buffs;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Singularity.Items.Armor;

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
		public bool ChlorophyteHeart;
		public bool ChlorophyteHeartActive;
		public bool Ukulele;
		public bool Crossbow;
		public int Crossbowtimer;
		public bool AnnealedArmorSet;
		public bool TemperedArmorSet;

		public override void ResetEffects() {
			Jellybone = false;
			SkellyJellyNecklace = false;
			VialofLightning = false;
			ChlorophyteHeart = false;
			Ukulele = false;
			Crossbow = false;
			AnnealedArmorSet = false;
			TemperedArmorSet = false;
		}

		public override void PostItemCheck (){
			if (Crossbow == false){
				Crossbowtimer = 0;
			}
		}
		public override void OnHitByNPC(NPC npc, int damage, bool crit){
			if (AnnealedArmorSet){
				float damageBonusChance = Main.rand.NextFloat(0,99);
				if (damageBonusChance >= 90){
					Main.PlaySound(new Terraria.Audio.LegacySoundStyle(13, 0));
					player.AddBuff(ModContent.BuffType<AnnealedBuff>(), 300);
				}
			}
			if (TemperedArmorSet){
				if (Main.expertMode){
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("TemperedThorn"), 5*(damage + (3*player.statDefense)/4), 4, player.whoAmI);
				}
				else{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("TemperedThorn"), 5*(damage + (player.statDefense)/2), 4, player.whoAmI);
				}
			}
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
            if (player.statLife == 0 && ChlorophyteHeart && ChlorophyteHeartActive){
				ChlorophyteHeartActive = false;
				player.statLife = player.statLifeMax;
				playSound = false;
				return false;
			}
			playSound = true;
			return true;
			}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit) {
			if(VialofLightning)
			{
				target.AddBuff(ModContent.BuffType<ShockedBuff>(), 60);
			}
			if(Ukulele)
			{
				target.AddBuff(ModContent.BuffType<ShockedBuff>(), 60);
				if (Main.rand.Next(6) == 0){
					float posX = target.Center.X;
					float posY = target.Center.Y;
					Projectile.NewProjectile(posX, posY, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-14f, -14f), mod.ProjectileType("UkuleleBolt"), 30, 1f, player.whoAmI, 0f, 0f);
				}
			}
		}
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit) {
			if(VialofLightning)
			{
				target.AddBuff(ModContent.BuffType<ShockedBuff>(), 120);
			}
			if(Ukulele)
			{
				target.AddBuff(ModContent.BuffType<ShockedBuff>(), 120);
				if (Main.rand.Next(3) == 0){
					float posX = target.Center.X;
					float posY = target.Center.Y;
					Projectile.NewProjectile(posX, posY, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-14f, -14f), mod.ProjectileType("UkuleleBolt"), 30, 1f, player.whoAmI, 0f, 0f);
				}
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
					recipe.AddIngredient(ItemID.Bone, 40);
					recipe.AddTile(TileID.Anvils);
					recipe.SetResult(this);
					recipe.AddRecipe();
					recipe.AddIngredient(ItemID.PinkJellyfish, 1);
					recipe.AddIngredient(ItemID.Bone, 40);
					recipe.AddTile(TileID.Anvils);
					recipe.SetResult(this);
					recipe.AddRecipe();
					recipe.AddIngredient(ItemID.GreenJellyfish, 1);
					recipe.AddIngredient(ItemID.Bone, 40);
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
		internal class Ukulele : ModItem
			{
				public override void SetStaticDefaults()
				{
					DisplayName.SetDefault("Ukulele");
					Tooltip.SetDefault("...and his music was electric.");
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
					player.GetModPlayer<CoolModPlayer>().Ukulele = true;
				}
			}
		
		internal class ChlorophyteHeart : ModItem
			{
				public override void SetStaticDefaults()
				{
					DisplayName.SetDefault("Chlorophyte Heart");
					Tooltip.SetDefault("Heals you back to full upon death. Once.");
				}

				public override void SetDefaults()
				{
					item.width = 24; 
					item.height = 28;
					item.value = Singularity.ToCopper(0, 1, 0, 0);
					item.rare = 8;
					item.accessory = true;
				}
				
				public int nomber = 10;
				public override void UpdateAccessory(Player player, bool hideVisual)
				{
					player.GetModPlayer<CoolModPlayer>().ChlorophyteHeart = true;
					if (nomber == 10){
						player.GetModPlayer<CoolModPlayer>().ChlorophyteHeartActive = true;
						nomber = 1;
					}
					if (player.GetModPlayer<CoolModPlayer>().ChlorophyteHeartActive == false){
						for (int i=3; i < 10; i++){
							if (player.armor[i].Name == "Chlorophyte Heart")
							{
								player.armor[i].TurnToAir();
								break;
							}
						}
					}	
				}
				public override void UpdateEquip (Player player){
					/*if (player.GetModPlayer<CoolModPlayer>().ChlorophyteHeartActive == false){
						for (int i=3; i < 10; i++){
							if (!player.armor[i].IsAir)
							{
								player.armor[i].TurnToAir();
								break;
							}
						}
					}*/	
				}
				public override void AddRecipes()
				{
					ModRecipe recipe = new ModRecipe(mod);
					recipe.AddIngredient(ItemID.LifeFruit, 1);
					recipe.AddIngredient(null, "ChlorophyteSoul", 1);
					recipe.AddTile(TileID.LihzahrdAltar);
					recipe.SetResult(this);
					recipe.AddRecipe();
				}
			}
	}
	namespace Items.Weapons {
		internal class Crossbow : ModItem
		{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("This might take a second.");
		}

		public override void SetDefaults() {
			item.damage = 24; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.crit = 16;
			item.ranged = true; // sets the damage type to ranged
			item.width = 40; // hitbox width of the item
			item.height = 20; // hitbox height of the item
			item.useTime = 1; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 1; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			//item.holdStyle = 1;
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = 50; // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.White; // the color that the item's name will be in-game
			//item.UseSound = SoundID.Item5; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 16f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.Arrow; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
			item.channel = true;
		}
        
		public override bool ConsumeAmmo (Player player){
			if (player.GetModPlayer<CoolModPlayer>().Crossbowtimer != 59){
			return false;
			}
			else{
			return true;
			}
		}

		public override void HoldItem (Player player){
			player.GetModPlayer<CoolModPlayer>().Crossbow = true;
			if (player.GetModPlayer<CoolModPlayer>().Crossbowtimer <= 57){
				item.UseSound = null;
			}
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack){	
			if (player.GetModPlayer<CoolModPlayer>().Crossbowtimer == 0){
				item.UseSound = null;
				item.autoReuse = false;
			}
			player.GetModPlayer<CoolModPlayer>().Crossbowtimer ++;
			if (player.GetModPlayer<CoolModPlayer>().Crossbowtimer < 58){
				item.autoReuse = true;
				item.UseSound = null;
				//item.useAmmo = AmmoID.None;
			}
			if (player.GetModPlayer<CoolModPlayer>().Crossbowtimer == 58){
				item.UseSound = SoundID.Item17;
			}
			if (player.GetModPlayer<CoolModPlayer>().Crossbowtimer == 59){
				item.UseSound = SoundID.Item5;
				//item.useAmmo = AmmoID.Arrow;
				item.autoReuse = false;
			}
			if (player.GetModPlayer<CoolModPlayer>().Crossbowtimer >= 60){
				player.GetModPlayer<CoolModPlayer>().Crossbowtimer = 0;
				item.UseSound = null;
				return true;
			}
			return false;
		}
		public override void AddRecipes()
				{
					ModRecipe recipe = new ModRecipe(mod);
					recipe.AddIngredient(ItemID.Wood, 12);
					recipe.AddIngredient(ItemID.WhiteString, 1);
					recipe.AddTile(TileID.WorkBenches);
					recipe.SetResult(this);
					recipe.AddRecipe();
				}
		}
	}
}
