using Terraria.ID;
using Terraria.ModLoader;


namespace Singularity.Items {
	public class ChlorophyteSoul : ModItem {
		public override void SetStaticDefaults(){
			DisplayName.SetDefault("Chlorophyte Soul");
		}
		public override void SetDefaults() {
			item.maxStack = 1;
			item.value = Singularity.ToCopper(0, 0, 50, 0);
		}
	}
}