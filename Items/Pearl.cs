using Terraria.ID;
using Terraria.ModLoader;


namespace Singularity.Items {
	public class Pearl : ModItem {
		public override void SetDefaults() {
			Item.maxStack = 99;
			Item.value = Singularity.ToCopper(0, 0, 15, 0);
		}
	}
}