using Singularity.Projectiles.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Buffs
{

	public class JellyboneBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Shocked");
			Description.SetDefault("You must wait before you can become immune again");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.buffTime[buffIndex] == 1500)
			{
				Main.PlaySound(SoundID.NPCDeath28);
			}
		}
	}
}