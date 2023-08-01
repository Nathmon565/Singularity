using Terraria.Audio;
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
		public bool Crossbone;
		public int Crossbonetimer;

		public bool AnnealedArmorSet;
		public bool TemperedArmorSet;

		public override void ResetEffects() {
			Jellybone = false;
			SkellyJellyNecklace = false;
			VialofLightning = false;
			ChlorophyteHeart = false;
			Ukulele = false;
			Crossbow = false;
			Crossbone = false;
			AnnealedArmorSet = false;
			TemperedArmorSet = false;
		}

		public override void PostItemCheck (){
			if (Crossbow == false){
				Crossbowtimer = 0;
			}
			if (Crossbone == false){
				Crossbonetimer = 0;
			}
		}
		public override void OnHitByNPC(NPC npc, Player.HurtInfo hurtInfo){
			if (AnnealedArmorSet){
				float damageBonusChance = Main.rand.NextFloat(0,99);
				if (damageBonusChance >= 90){
					SoundEngine.PlaySound(new Terraria.Audio.LegacySoundStyle(13, 0));
					Player.AddBuff(ModContent.BuffType<AnnealedBuff>(), 300);
				}
			}
			if (TemperedArmorSet){
				if (Main.expertMode){
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, Mod.Find<ModProjectile>("TemperedThorn").Type, 5*(damage + (3*Player.statDefense)/4), 4, Player.whoAmI);
				}
				else{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, Mod.Find<ModProjectile>("TemperedThorn").Type, 5*(damage + (Player.statDefense)/2), 4, Player.whoAmI);
				}
			}
		}

		public override void ModifyHurt(ref Player.HurtModifiers modifiers)/* tModPorter Override ImmuneTo, FreeDodge or ConsumableDodge instead to prevent taking damage */ {
			if(Jellybone && SkellyJellyNecklace) {
				if (!Player.HasBuff(ModContent.BuffType<JellyboneBuff>()) && !Player.HasBuff(ModContent.BuffType<JellyboneBuff2>()))
				{
					playSound = false;
					Player.immune = true;
					//player.immuneAlpha = 0;
					Player.immuneTime = 450;
					Player.AddBuff(ModContent.BuffType<JellyboneBuff2>(), 2700);
					SoundEngine.PlaySound(SoundID.NPCHit25);
					return false;
				}
			}
			else if(Jellybone || SkellyJellyNecklace) {
				if (!Player.HasBuff(ModContent.BuffType<JellyboneBuff>()) && !Player.HasBuff(ModContent.BuffType<JellyboneBuff2>()))
				{
					playSound = false;
					Player.immune = true;
					//player.immuneAlpha = 0;
					Player.immuneTime = 300;
					Player.AddBuff(ModContent.BuffType<JellyboneBuff>(), 1800);
					SoundEngine.PlaySound(SoundID.NPCHit25);
					return false;
				}
			}  
			return true;
			}

		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore,
            ref PlayerDeathReason damageSource) {
            if (Player.statLife == 0 && ChlorophyteHeart && ChlorophyteHeartActive){
				ChlorophyteHeartActive = false;
				Player.statLife = Player.statLifeMax;
				playSound = false;
				return false;
			}
			playSound = true;
			return true;
			}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)/* tModPorter If you don't need the Projectile, consider using OnHitNPC instead */ {
			if(VialofLightning)
			{
				target.AddBuff(ModContent.BuffType<ShockedBuff>(), 300);
			}
			if(Ukulele)
			{
				target.AddBuff(ModContent.BuffType<ShockedBuff>(), 300);
				if (Main.rand.Next(6) == 0){
					float posX = target.Center.X;
					float posY = target.Center.Y;
					Projectile.NewProjectile(posX, posY, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-14f, -14f), Mod.Find<ModProjectile>("UkuleleBolt").Type, 30, 1f, Player.whoAmI, 0f, 0f);
				}
			}
		}
		public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)/* tModPorter If you don't need the Item, consider using OnHitNPC instead */ {
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
					Projectile.NewProjectile(posX, posY, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-14f, -14f), Mod.Find<ModProjectile>("UkuleleBolt").Type, 30, 1f, Player.whoAmI, 0f, 0f);
				}
			}
		}
	}

	namespace Items.Accessories {
		internal class Jellybone : ModItem
			{
				public override void SetStaticDefaults()
				{
					// DisplayName.SetDefault("Jellybone");
					// Tooltip.SetDefault("Become immune for one hit \n\nTakes 30 seconds to recharge");
				}

				public override void SetDefaults()
				{
					Item.width = 24; 
					Item.height = 28;
					Item.value = Singularity.ToCopper(0, 0, 30, 0);
					Item.rare = 2;
					Item.accessory = true;
				}

				public override void UpdateAccessory(Player player, bool hideVisual)
				{
					player.GetModPlayer<CoolModPlayer>().Jellybone = true;
				}


				public override void AddRecipes()
				{
					Recipe recipe = CreateRecipe(this.Type, this.Type);
					recipe.AddIngredient(ItemID.BlueJellyfish, 1);
					recipe.AddIngredient(ItemID.Bone, 40);
					recipe.AddTile(TileID.Anvils);
					recipe.Register();
					recipe.AddIngredient(ItemID.PinkJellyfish, 1);
					recipe.AddIngredient(ItemID.Bone, 40);
					recipe.AddTile(TileID.Anvils);
					recipe.Register();
					recipe.AddIngredient(ItemID.GreenJellyfish, 1);
					recipe.AddIngredient(ItemID.Bone, 40);
					recipe.AddTile(TileID.Anvils);
					recipe.Register();	
				}
			}
		
		internal class SkellyJellyNecklace : ModItem
			{
				public override void SetStaticDefaults()
				{
					// DisplayName.SetDefault("Skelly-Jelly Necklace");
					// Tooltip.SetDefault("Generates a very subtle glow which becomes more vibrant underwater \n\nIncreases armor penetration by 5 \n\nBecome immune for one hit \n\nTakes 30 seconds to recharge");
				}

				public override void SetDefaults()
				{
					Item.width = 24; 
					Item.height = 28;
					Item.value = Singularity.ToCopper(0, 1, 30, 0);
					Item.rare = 2;
					Item.accessory = true;
				}

				public override void UpdateAccessory(Player player, bool hideVisual)
				{
					player.GetModPlayer<CoolModPlayer>().SkellyJellyNecklace = true;
					player.GetArmorPenetration(DamageClass.Generic) += 5;
					Lighting.AddLight(player.position, 0.3f, 0.1f, 0.1f);
					if (player.wet) {
					Lighting.AddLight(player.position, 1.2f, 0.8f, 0.8f);
					}
				}


				public override void AddRecipes()
				{
					Recipe recipe = CreateRecipe();
					recipe.AddIngredient(ItemID.SharkToothNecklace, 1);
					recipe.AddIngredient(ItemID.JellyfishNecklace, 1);
					recipe.AddIngredient(null, "Jellybone", 1);
					recipe.AddTile(TileID.TinkerersWorkbench);
					recipe.Register();
				}
			}
		internal class VialofLightning : ModItem
			{
				public override void SetStaticDefaults()
				{
					// DisplayName.SetDefault("Vial of Lightning");
					// Tooltip.SetDefault("Inflicts Shocked on hit");
				}

				public override void SetDefaults()
				{
					Item.width = 24; 
					Item.height = 28;
					Item.value = Singularity.ToCopper(0, 2, 0, 0);
					Item.rare = 8;
					Item.accessory = true;
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
					// DisplayName.SetDefault("Ukulele");
					// Tooltip.SetDefault("...and his music was electric.");
				}

				public override void SetDefaults()
				{
					Item.width = 24; 
					Item.height = 28;
					Item.value = Singularity.ToCopper(0, 2, 0, 0);
					Item.rare = 8;
					Item.accessory = true;
				}
				public override void UpdateAccessory(Player player, bool hideVisual)
				{
					player.GetModPlayer<CoolModPlayer>().Ukulele = true;
				}
				public override void AddRecipes()
				{
					Recipe recipe = CreateRecipe();
					recipe.AddIngredient(null, "LivingLute", 1);
					recipe.AddIngredient(null, "VialofLightning", 1);
					recipe.AddTile(TileID.MythrilAnvil);
					recipe.Register();
				}
			}
		
		internal class ChlorophyteHeart : ModItem
			{
				public override void SetStaticDefaults()
				{
					// DisplayName.SetDefault("Chlorophyte Heart");
					// Tooltip.SetDefault("Heals you back to full upon death. Once.");
				}

				public override void SetDefaults()
				{
					Item.width = 24; 
					Item.height = 28;
					Item.value = Singularity.ToCopper(0, 1, 0, 0);
					Item.rare = 8;
					Item.accessory = true;
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
					Recipe recipe = CreateRecipe();
					recipe.AddIngredient(ItemID.LifeFruit, 1);
					recipe.AddIngredient(null, "ChlorophyteSoul", 1);
					recipe.AddTile(TileID.LihzahrdAltar);
					recipe.Register();
				}
			}
	}
	namespace Items.Weapons {
		internal class Crossbow : ModItem
		{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("This might take a second.");
		}

		public override void SetDefaults() {
			Item.damage = 24; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.crit = 16;
			Item.DamageType = DamageClass.Ranged; // sets the damage type to ranged
			Item.width = 40; // hitbox width of the item
			Item.height = 20; // hitbox height of the item
			Item.useTime = 1; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 1; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			//item.holdStyle = 1;
			Item.useStyle = ItemUseStyleID.Shoot; // how you use the item (swinging, holding out, etc)
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 4; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.value = 50; // how much the item sells for (measured in copper)
			Item.rare = ItemRarityID.White; // the color that the item's name will be in-game
			//item.UseSound = SoundID.Item5; // The sound that this item plays when used.
			Item.autoReuse = true; // if you can hold click to automatically use it again
			Item.shoot = 10; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 16f; // the speed of the projectile (measured in pixels per frame)
			Item.useAmmo = AmmoID.Arrow; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
			Item.channel = true;
		}
        
		public override bool CanConsumeAmmo (Item ammo, Player player){
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
				Item.UseSound = null;
			}
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback){	
			if (player.GetModPlayer<CoolModPlayer>().Crossbowtimer == 0){
				Item.UseSound = null;
				Item.autoReuse = false;
			}
			player.GetModPlayer<CoolModPlayer>().Crossbowtimer ++;
			if (player.GetModPlayer<CoolModPlayer>().Crossbowtimer < 58){
				Item.autoReuse = true;
				Item.UseSound = null;
				//item.useAmmo = AmmoID.None;
			}
			if (player.GetModPlayer<CoolModPlayer>().Crossbowtimer == 58){
				Item.UseSound = SoundID.Item17;
			}
			if (player.GetModPlayer<CoolModPlayer>().Crossbowtimer == 59){
				Item.UseSound = SoundID.Item5;
				//item.useAmmo = AmmoID.Arrow;
				Item.autoReuse = false;
			}
			if (player.GetModPlayer<CoolModPlayer>().Crossbowtimer >= 60){
				player.GetModPlayer<CoolModPlayer>().Crossbowtimer = 0;
				Item.UseSound = null;
				return true;
			}
			return false;
		}
		public override void AddRecipes()
				{
					Recipe recipe = CreateRecipe();
					recipe.AddIngredient(ItemID.Wood, 12);
					recipe.AddIngredient(ItemID.WhiteString, 1);
					recipe.AddTile(TileID.WorkBenches);
					recipe.Register();
				}
		}
		internal class Crossbone : ModItem
		{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Cross my heart and hope to perish.");
		}

		public override void SetDefaults() {
			Item.damage = 36; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.crit = 16;
			Item.DamageType = DamageClass.Ranged; // sets the damage type to ranged
			Item.width = 40; // hitbox width of the item
			Item.height = 20; // hitbox height of the item
			Item.useTime = 1; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 1; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			//item.holdStyle = 1;
			Item.useStyle = ItemUseStyleID.Shoot; // how you use the item (swinging, holding out, etc)
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 4; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.value = 5000; // how much the item sells for (measured in copper)
			Item.rare = ItemRarityID.Green; // the color that the item's name will be in-game
			//item.UseSound = SoundID.Item5; // The sound that this item plays when used.
			Item.autoReuse = true; // if you can hold click to automatically use it again
			Item.shoot = 10; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 8f; // the speed of the projectile (measured in pixels per frame)
			Item.useAmmo = ItemID.Bone; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
			Item.channel = true;
		}
        
		public override bool CanConsumeAmmo (Item ammo, Player player){
			if (player.GetModPlayer<CoolModPlayer>().Crossbonetimer != 59){
			return false;
			}
			else{
			return true;
			}
		}

		public override void HoldItem (Player player){
			player.GetModPlayer<CoolModPlayer>().Crossbone = true;
			if (player.GetModPlayer<CoolModPlayer>().Crossbonetimer <= 57){
				Item.UseSound = null;
			}
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback){	
			if (player.GetModPlayer<CoolModPlayer>().Crossbonetimer == 0){
				Item.UseSound = null;
				Item.autoReuse = false;
			}
			player.GetModPlayer<CoolModPlayer>().Crossbonetimer ++;
			if (player.GetModPlayer<CoolModPlayer>().Crossbonetimer < 58){
				Item.autoReuse = true;
				Item.UseSound = null;
				//item.useAmmo = AmmoID.None;
			}
			if (player.GetModPlayer<CoolModPlayer>().Crossbonetimer == 58){
				Item.UseSound = SoundID.Item17;
			}
			if (player.GetModPlayer<CoolModPlayer>().Crossbonetimer == 59){
				Item.UseSound = SoundID.Item5;
				//item.useAmmo = AmmoID.Arrow;
				Item.autoReuse = false;
			}
			if (player.GetModPlayer<CoolModPlayer>().Crossbonetimer >= 60){
				player.GetModPlayer<CoolModPlayer>().Crossbonetimer = 0;
				Item.UseSound = null;
				Projectile.NewProjectile(position.X, position.Y, Main.rand.NextFloat(speedX-2, speedX+2), Main.rand.NextFloat(speedY-2, speedY+2), type, damage, knockBack, Item.playerIndexTheItemIsReservedFor);
				Projectile.NewProjectile(position.X, position.Y, Main.rand.NextFloat(speedX-2, speedX+2), Main.rand.NextFloat(speedY-2, speedY+2), type, damage, knockBack, Item.playerIndexTheItemIsReservedFor);
				Projectile.NewProjectile(position.X, position.Y, Main.rand.NextFloat(speedX-2, speedX+2), Main.rand.NextFloat(speedY-2, speedY+2), type, damage, knockBack, Item.playerIndexTheItemIsReservedFor);
				Projectile.NewProjectile(position.X, position.Y, Main.rand.NextFloat(speedX-2, speedX+2), Main.rand.NextFloat(speedY-2, speedY+2), type, damage, knockBack, Item.playerIndexTheItemIsReservedFor);
				return true;
			}
			return false;
		}
		public override void AddRecipes()
				{
					Recipe recipe = CreateRecipe();
					recipe.AddIngredient(ItemID.Bone, 35);
					recipe.AddIngredient(ItemID.WhiteString, 1);
					recipe.AddTile(TileID.Anvils);
					recipe.Register();
				}
		}
	}
}
