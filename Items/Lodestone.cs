using Terraria.ID;
using Terraria.ModLoader;


namespace Singularity.Items {
	public class Lodestone : ModItem {
		public override void SetDefaults() {
			Item.maxStack = 99;
			Item.value = Singularity.ToCopper(0, 0, 30, 0);
		}
	}
}