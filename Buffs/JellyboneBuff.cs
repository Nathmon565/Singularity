﻿using Singularity.Projectiles.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Buffs
{

	public class JellyboneBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Jelly-Jammed");
			// Description.SetDefault("You must wait before you can become immune again");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.buffTime[buffIndex] > 1500)
			{
				player.GetDamage(DamageClass.Generic) += 0.005f;
			}
			if (player.buffTime[buffIndex] == 1500)
			{
				SoundEngine.PlaySound(SoundID.NPCDeath28);
			}
		}
	}

	public class JellyboneBuff2 : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Jelly-Jammed");
			// Description.SetDefault("You must wait longer before you can become more immune again");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.buffTime[buffIndex] > 2250)
			{
				player.GetDamage(DamageClass.Generic) += 0.075f;
			}
			if (player.buffTime[buffIndex] == 2250)
			{
				SoundEngine.PlaySound(SoundID.NPCDeath28);
			}
		}
	}
}