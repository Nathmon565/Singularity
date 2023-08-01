using Singularity.Projectiles.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Buffs
{

	public class PharmakonBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Pharmakon");
			// Description.SetDefault("Gain great strength...");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = true;
		}

		public override void Update (Player player, ref int buffIndex)
		{
			if (player.buffTime[buffIndex] > 0){
				player.GetDamage(DamageClass.Generic) *= 1.40f;
				player.statDefense += player.statDefense/4;
				player.GetAttackSpeed(DamageClass.Melee) += 0.25f;
				player.GetCritChance(DamageClass.Generic) += 20;
				player.GetCritChance(DamageClass.Ranged) += 20;
				player.GetCritChance(DamageClass.Magic) += 20;
				player.GetCritChance(DamageClass.Throwing) += 20;
				player.GetKnockback(DamageClass.Summon).Base += 0.20f;
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