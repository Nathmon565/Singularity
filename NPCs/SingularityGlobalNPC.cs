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

		if(npc.type == NPCID.Crab) { //temp - oyster enemy eventually
			if (Main.rand.NextFloat() < 0.1f) { Item.NewItem(npc.getRect(), mod.ItemType("Pearl")); }
		}

		if(npc.type == NPCID.Antlion) {
			if (Main.rand.NextFloat() < 0.05f) { Item.NewItem(npc.getRect(), ItemID.Amber); }
		}

		if(npc.type == NPCID.IceSlime) {
			if (Main.rand.NextFloat() < 0.04f) { Item.NewItem(npc.getRect(), mod.ItemType("Opal")); }
		}

		if(npc.type == NPCID.Snatcher || npc.type == NPCID.ManEater) {
			if (Main.rand.NextFloat() < 0.07f) { Item.NewItem(npc.getRect(), mod.ItemType("Jade")); }
		}

		if(npc.type == NPCID.Demon) {
			if (Main.rand.NextFloat() < 0.09f) { Item.NewItem(npc.getRect(), mod.ItemType("Onyx")); }
		}
		if(npc.type == NPCID.Hellbat) {
			if (Main.rand.NextFloat() < 0.09f) { Item.NewItem(npc.getRect(), mod.ItemType("Onyx")); }
		}

		
	}
}