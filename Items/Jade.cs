using Terraria.ID;
using Terraria.ModLoader;


namespace Singularity.Items {
	public class Jade : ModItem {
		public override void SetDefaults() {
			item.maxStack = 99;
			item.value = Singularity.ToCopper(0, 0, 30, 0);
		}
	}
}