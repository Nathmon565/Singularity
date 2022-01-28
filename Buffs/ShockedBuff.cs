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
				npc.noGravity = true;
				npc.life -= 1;
			}
		}
	}
}