using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;

namespace Singularity {
	class Singularity : Mod {
		public static int ToCopper(int Platinum = 0, int Gold = 0, int Silver = 0, int Copper = 0) {
			Platinum *= 1000000;
			Gold *= 10000;
			Silver *= 100;
			return Platinum + Gold + Silver + Copper;
		}
	}
}
