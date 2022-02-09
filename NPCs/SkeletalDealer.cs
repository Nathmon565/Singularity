using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.NPCs
{
	public class SkeletalDealer : ModNPC
	{
		public override string Texture => "Terraria/NPC_" + NPCID.SkeletonMerchant;

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Skeletal Dealer");
			Main.npcFrameCount[npc.type] = 25;
		}
		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.SkeletonMerchant);
			animationType = NPCID.SkeletonMerchant;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (spawnInfo.granite || spawnInfo.marble || spawnInfo.spiderCave){
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
		public override void OnChatButtonClicked (bool firstButton, ref bool shop){
			shop = true;
		}
		public override void SetupShop (Chest shop, ref int nextSlot){
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.PharmakonBrew>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Accessories.CursedTome>());
				nextSlot++;
		}
	}
}