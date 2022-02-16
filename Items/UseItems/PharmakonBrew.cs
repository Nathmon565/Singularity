using Terraria.ID;
using Terraria.ModLoader;


namespace Singularity.Items.UseItems {
	public class PharmakonBrew : ModItem {
		
		public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Improves your stats greatly... \nAt a cost.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Orange;
            item.value = 50000;
            item.buffType = ModContent.BuffType<Buffs.PharmakonBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 7200; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
			//item.buyOnce = false;
        }
	}
}