using Singularity.Projectiles.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Buffs
{

	public class PharmakoffBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Pharmakoff");
			Description.SetDefault("...and lose it all.");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = true;
		}
		public override void Update (Player player, ref int buffIndex)
		{
			if (player.buffTime[buffIndex] > 0){
				player.allDamage /= 2.2f;
				player.statDefense -= player.statDefense/2;
				player.meleeSpeed -= 0.50f;
				player.meleeCrit -= 40;
				player.rangedCrit -= 40;
				player.magicCrit -= 40;
				player.thrownCrit -= 40;
				player.minionKB -= 0.40f;
				player.statLifeMax2 -= 80;
				player.lifeRegen /= 6;
				player.statManaMax2 -= 80;
				player.manaRegen /= 6;
				player.moveSpeed /= 1.75f;
			}
		}
	}
}