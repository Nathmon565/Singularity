using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.NPCs
{
	public class TheUndying : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("The Undying");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
		}

		public override void SetDefaults() {
			npc.width = 18;
			npc.height = 40;
			npc.damage = 40;
			npc.defense = 20;
			npc.lifeMax = 10000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			npc.scale = 2;
			npc.ai[3] = 1f;
			//aiType = NPCID.Zombie;
			animationType = NPCID.Zombie;
			banner = Item.NPCtoBanner(NPCID.Zombie);
			bannerItem = Item.BannerToItem(banner);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (spawnInfo.planteraDefeated){
				return SpawnCondition.HardmodeJungle.Chance * SpawnCondition.UndergroundJungle.Chance * 0.1f;
			}
			else
			{
				return 0;
			}
		}

		public override bool CheckDead(){
			if (npc.ai[3] != 4f) {
				npc.ai[3] += 1;
				npc.damage += npc.damage/2;
				npc.lifeMax /= 2;
				npc.life = npc.lifeMax;
				return false;
			}
			else
			{
				return true;
			}
		}

		public override void HitEffect(int hitDirection, double damage) {
			for (int i = 0; i < 10; i++) {
				int dustType = Main.rand.Next(139, 143);
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}
}