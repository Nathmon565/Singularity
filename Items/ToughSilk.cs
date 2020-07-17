using Terraria.ID;
using Terraria.ModLoader;


namespace Singularity.Items {
	public class ToughSilk : ModItem {
		public override void SetDefaults() {
			item.maxStack = 999;
			item.value = Singularity.ToCopper(0, 0, 3, 0);
		}
	}
}