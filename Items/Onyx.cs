using Terraria.ID;
using Terraria.ModLoader;


namespace Singularity.Items {
	public class Onyx : ModItem {
		public override void SetDefaults() {
			Item.maxStack = 99;
			Item.rare = 1;
			Item.value = Singularity.ToCopper(0, 0, 30, 0);
		}
	}
}