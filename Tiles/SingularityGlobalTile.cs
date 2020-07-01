using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

public class SingularityGlobalTile : GlobalTile {
    public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem) {

        if(type == TileID.BreakableIce) {
            if (Main.rand.NextFloat() < 0.15f) {
                Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("IceCubes"));
            }
        }
    }
}