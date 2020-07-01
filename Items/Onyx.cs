using Terraria.ID;
using Terraria.ModLoader;


namespace Singularity.Items {
	public class Onyx : ModItem {
		public override void SetDefaults() {
			item.maxStack = 99;
			item.rare = 1;
			item.value = Singularity.ToCopper(0, 0, 30, 0);
		}
	}
}