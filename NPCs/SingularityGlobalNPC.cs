using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

class SingularityGlobalNPC : GlobalNPC {
	public override void NPCLoot(NPC npc) {

		if(npc.type == NPCID.BloodCrawler || npc.type == NPCID.BloodCrawlerWall) {
			if (Main.rand.NextFloat() < 0.07f) { Item.NewItem(npc.getRect(), mod.ItemType("Bloodstone")); }
		}

		if(npc.type == NPCID.EaterofSouls) {
			if (Main.rand.NextFloat() < 0.07f) { Item.NewItem(npc.getRect(), mod.ItemType("Sulfur")); }
		}

		if(npc.type == NPCID.Crab) { //temp, using 1.4 pearl when released
			if (Main.rand.NextFloat() < 0.11f) { Item.NewItem(npc.getRect(), mod.ItemType("Pearl")); }
		}
		if(npc.type == NPCID.Crab) { 
			if (Main.rand.NextFloat() < 0.17f) { Item.NewItem(npc.getRect(), mod.ItemType("Nacre")); }
		}

		if(npc.type == NPCID.Antlion) {
			if (Main.rand.NextFloat() < 0.07f) { Item.NewItem(npc.getRect(), ItemID.Amber); }
		}

		if(npc.type == NPCID.IceSlime) {
			if (Main.rand.NextFloat() < 0.09f) { Item.NewItem(npc.getRect(), mod.ItemType("Opal")); }
		}

		if(npc.type == NPCID.Snatcher || npc.type == NPCID.ManEater) {
			if (Main.rand.NextFloat() < 0.07f) { Item.NewItem(npc.getRect(), mod.ItemType("Jade")); }
		}

		if(npc.type == NPCID.Demon) {
			if (Main.rand.NextFloat() < 0.11f) { Item.NewItem(npc.getRect(), mod.ItemType("Onyx")); }
			if (Main.rand.NextFloat() < 0.11f) { Item.NewItem(npc.getRect(), mod.ItemType("DemonBlood"),Main.rand.Next(1,6)); }
		}
		if(npc.type == NPCID.Hellbat) {
			if (Main.rand.NextFloat() < 0.09f) { Item.NewItem(npc.getRect(), mod.ItemType("Onyx")); }
		}

		if(npc.type == NPCID.Harpy) {
			if (Main.rand.NextFloat() < 0.09f) { Item.NewItem(npc.getRect(), mod.ItemType("Lodestone")); }
		}

		if(npc.type == NPCID.WallCreeper) {
			if (Main.rand.NextFloat() < 0.5f) { Item.NewItem(npc.getRect(), mod.ItemType("ToughSilk")); }
		}
		if(npc.type == NPCID.WallCreeperWall) {
			if (Main.rand.NextFloat() < 0.5f) { Item.NewItem(npc.getRect(), mod.ItemType("ToughSilk")); }
		}
		if(npc.type == NPCID.Demon) {
			if (Main.rand.NextFloat() < 0.5f) { Item.NewItem(npc.getRect(), mod.ItemType("DemonBlood")); }
		}
		if(npc.type == NPCID.CursedSkull) {
			if (Main.rand.NextFloat() < 0.0153f) { Item.NewItem(npc.getRect(), mod.ItemType("CursedTome")); }
		}
	}
}