using Singularity.Projectiles.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Buffs
{

	public class ShockedBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Shocked");
			Description.SetDefault("Shocking!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = true;
		}

		public override void Update (NPC npc, ref int buffIndex)
		{
			if (npc.buffTime[buffIndex] > 0){
				//npc.noGravity = true;
				npc.lifeRegen -= 48;
				npc.defense /= 2;
				if (npc.type != NPCID.TargetDummy) {
				npc.knockBackResist += (1 - npc.knockBackResist)*0.9f;
				}
				Vector2 dustPosition = npc.Center + new Vector2(Main.rand.Next(-10, 10), Main.rand.Next(-10, 10));
				//Dust dust = Dust.NewDustPerfect(dustPosition, 169, null, 100, default(Color), 1.2f);
				Dust dust2 = Dust.NewDustPerfect(dustPosition, 133, null, 100, default(Color), 1.2f);
				//dust.noGravity = true;
				dust2.noGravity = true;
			}
		}
	}
}