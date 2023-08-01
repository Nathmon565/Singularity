﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Singularity.Projectiles;
using Terraria.ModLoader.Utilities;


namespace Singularity.NPCs
{
	public class LunaticDealer : ModNPC
	{
		//public override string Texture => "Terraria/NPC_" + NPCID.SkeletonMerchant;

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Lunatic Dealer");
			Main.npcFrameCount[NPC.type] = 25;
			NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
			NPCID.Sets.AttackFrameCount[NPC.type] = 4;
			NPCID.Sets.DangerDetectRange[NPC.type] = 700;
			NPCID.Sets.AttackType[NPC.type] = 0;
			NPCID.Sets.AttackTime[NPC.type] = 90;
			NPCID.Sets.AttackAverageChance[NPC.type] = 30;
		}
		public override void SetDefaults()
		{
			//npc.townNPC = true; // This will be changed once the NPC is spawned
			NPC.friendly = true;
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = 7;
			NPC.damage = 10;
			NPC.defense = 15;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;
			AnimationType = NPCID.SkeletonMerchant;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (spawnInfo.Granite || spawnInfo.Marble || spawnInfo.SpiderCave){
				if (Main.hardMode){
					return SpawnCondition.Cavern.Chance * 0.01f;
				}
				else{
					return 0;
				}
			}
			else
			{
				return 0;
			}
		}
		
		public override bool CanChat (){
			return true;
		}
		public int talk;
		public override string GetChat (){
			talk = Main.rand.Next(0,6);
			if (talk == 0){
				return "The best color is #ffffdd.";
			}
			if (talk == 1){
				return "Don't drink the pharmakons.";
			}
			if (talk == 2){
				return "Did you come back to get your fix?";
			}
			if (talk == 3){
				return "Did you hear they're putting bones in jellyfish nowadays?About time if you ask me.";
			}
			if (talk == 4){
				return "Mən bir kitab yedim.";
			}
			else{
				return "Why do they call it oven when you of in the cold food of out hot eat the food?";
			}
		}
		public override void SetChatButtons (ref string button, ref string button2){
			button = "Shop";
		}
		public override void OnChatButtonClicked (bool firstButton, ref string shopName){
			shop = true;
		}
		public override void ModifyActiveShop (string shopName, Item[] items){
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.UseItems.PharmakonBrew>());
				nextSlot++;
		}
        public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = ModContent.ProjectileType<SulfurBolt>();
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}