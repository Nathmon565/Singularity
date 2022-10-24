using Singularity.Projectiles.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Buffs
{

	public class PharmakoffBuff : ModBuff
	{
		public override void SetStaticDefaults()
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
				player.GetDamage(DamageClass.Generic) /= 2.2f;
				player.statDefense -= player.statDefense/2;
				player.GetAttackSpeed(DamageClass.Melee) -= 0.50f;
				player.GetCritChance(DamageClass.Generic) -= 40;
				player.GetCritChance(DamageClass.Ranged) -= 40;
				player.GetCritChance(DamageClass.Magic) -= 40;
				player.GetCritChance(DamageClass.Throwing) -= 40;
				player.GetKnockback(DamageClass.Summon).Base -= 0.40f;
				player.statLifeMax2 -= 80;
				player.lifeRegen /= 6;
				player.statManaMax2 -= 80;
				player.manaRegen /= 6;
				player.moveSpeed /= 1.75f;
			}
		}
	}
}