using Terraria.ID;
using Terraria.ModLoader;


namespace Singularity.Items {
	public class ToughSilk : ModItem {
		public override void SetDefaults() {
			Item.maxStack = 999;
			Item.value = Singularity.ToCopper(0, 0, 3, 0);
		}
	}
}