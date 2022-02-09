using Singularity.Projectiles.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Buffs
{

	public class PharmakonBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Pharmakon");
			Description.SetDefault("Gain great strength...");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = true;
		}

		public override void Update (Player player, ref int buffIndex)
		{
			if (player.buffTime[buffIndex] > 0){
				player.allDamage *= 1.40f;
				player.statDefense += player.statDefense/4;
				player.meleeSpeed += 0.25f;
				player.meleeCrit += 20;
				player.rangedCrit += 20;
				player.magicCrit += 20;
				player.thrownCrit += 20;
				player.minionKB += 0.20f;
				player.statLifeMax2 += 40;
				player.lifeRegen *= 3;
				player.statManaMax2 += 40;
				player.manaRegen *= 3;
				player.moveSpeed *= 1.25f;
			}
			if (player.buffTime[buffIndex] == 0){
				player.AddBuff(ModContent.BuffType<PharmakoffBuff>(), 3600);
			}
		}
	}
}