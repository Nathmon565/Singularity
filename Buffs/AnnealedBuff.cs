using Singularity.Projectiles.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Buffs
{

	public class AnnealedBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shattering Fury");
			Description.SetDefault("50% increased damage");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = false;
		}

		public override void Update (Player player, ref int buffIndex)
		{
			if (player.buffTime[buffIndex] > 0){
				player.GetDamage(DamageClass.Generic) *= 2.0f;
				player.statDefense -= 6;
			}
		}
	}
}