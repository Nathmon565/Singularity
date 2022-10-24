using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Singularity.NPCs
{
	public class TheUndying : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("The Undying");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Wraith];
		}

		public override void SetDefaults() {
			NPC.width = 18;
			NPC.height = 40;
			NPC.damage = 60;
			NPC.defense = 20;
			NPC.lifeMax = 10000;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = 60f;
			NPC.knockBackResist = 0.05f;
			NPC.aiStyle = 22;
			NPC.scale = 2;
			//npc.ai[0] = 1f;
			AIType = NPCID.Wraith;
			AnimationType = NPCID.Wraith;
			Banner = Item.NPCtoBanner(NPCID.Wraith);
			BannerItem = Item.BannerToItem(Banner);
			NPC.noTileCollide = true;
			NPC.noGravity = true;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (spawnInfo.PlanteraDefeated){
				return SpawnCondition.HardmodeJungle.Chance * SpawnCondition.UndergroundJungle.Chance * 0.1f;
			}
			else
			{
				return 0;
			}
		}
		
		public override bool CheckDead(){
			if (NPC.lifeMax > 5000 & Main.expertMode) {
				//npc.ai[0] += 1;
				NPC.damage += NPC.damage/4;
				NPC.lifeMax /= 2;
				NPC.life = NPC.lifeMax;
				NPC.scale *= 0.75f;
				NPC.width -= 4;
				NPC.height -= 10;
				return false;
			}
			if (NPC.lifeMax > 2500 & !Main.expertMode) {
				//npc.ai[0] += 1;
				NPC.damage += NPC.damage/4;
				NPC.lifeMax /= 2;
				NPC.life = NPC.lifeMax;
				NPC.scale *= 0.75f;
				NPC.width -= 4;
				NPC.height -= 10;
				return false;
			}
			if (NPC.lifeMax <= 5000 && Main.expertMode)
			{
				return true;
			}
			if (NPC.lifeMax <= 2500 && !Main.expertMode)
			{
				return true;
			}
			return true;
		}

		public override void HitEffect(int hitDirection, double damage) {
			for (int i = 0; i < 10; i++) {
				int dustType = Main.rand.Next(139, 143);
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}
}