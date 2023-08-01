using Terraria.ID;
using Terraria.ModLoader;


namespace Singularity.Items.UseItems {
	public class PharmakonBrew : ModItem {
		
		public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Improves your stats greatly... \nAt a cost.");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = 50000;
            Item.buffType = ModContent.BuffType<Buffs.PharmakonBuff>(); //Specify an existing buff to be applied when used.
            Item.buffTime = 7200; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
			//item.buyOnce = false;
        }
	}
}