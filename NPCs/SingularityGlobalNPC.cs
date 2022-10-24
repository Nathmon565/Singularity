using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

class SingularityGlobalNPC : GlobalNPC {
	public override void OnKill(NPC npc) {

		if(npc.type == NPCID.BloodCrawler || npc.type == NPCID.BloodCrawlerWall) {
			if (Main.rand.NextFloat() < 0.07f) { Item.NewItem(Terraria.DataStructures.IEntitySource source, Mod.Find<ModItem>("Bloodstone").Type); }
		}

		if(npc.type == NPCID.EaterofSouls) {
			if (Main.rand.NextFloat() < 0.07f) { Item.NewItem(npc.getRect(), Mod.Find<ModItem>("Sulfur").Type); }
		}

		if(npc.type == NPCID.Crab) { //temp, using 1.4 pearl when released
			if (Main.rand.NextFloat() < 0.11f) { Item.NewItem(npc.getRect(), Mod.Find<ModItem>("Pearl").Type); }
		}
		if(npc.type == NPCID.Crab) { 
			if (Main.rand.NextFloat() < 0.17f) { Item.NewItem(npc.getRect(), Mod.Find<ModItem>("Nacre").Type); }
		}

		if(npc.type == NPCID.Antlion) {
			if (Main.rand.NextFloat() < 0.07f) { Item.NewItem(npc.getRect(), ItemID.Amber); }
		}

		if(npc.type == NPCID.IceSlime) {
			if (Main.rand.NextFloat() < 0.09f) { Item.NewItem(npc.getRect(), Mod.Find<ModItem>("Opal").Type); }
		}

		if(npc.type == NPCID.Snatcher || npc.type == NPCID.ManEater) {
			if (Main.rand.NextFloat() < 0.07f) { Item.NewItem(npc.getRect(), Mod.Find<ModItem>("Jade").Type); }
		}

		if(npc.type == NPCID.Demon) {
			if (Main.rand.NextFloat() < 0.11f) { Item.NewItem(npc.getRect(), Mod.Find<ModItem>("Onyx").Type); }
			if (Main.rand.NextFloat() < 0.11f) { Item.NewItem(npc.getRect(), Mod.Find<ModItem>("DemonBlood").Type,Main.rand.Next(1,6)); }
		}
		if(npc.type == NPCID.Hellbat) {
			if (Main.rand.NextFloat() < 0.09f) { Item.NewItem(npc.getRect(), Mod.Find<ModItem>("Onyx").Type); }
		}

		if(npc.type == NPCID.Harpy) {
			if (Main.rand.NextFloat() < 0.09f) { Item.NewItem(npc.getRect(), Mod.Find<ModItem>("Lodestone").Type); }
		}

		if(npc.type == NPCID.WallCreeper) {
			if (Main.rand.NextFloat() < 0.5f) { Item.NewItem(npc.getRect(), Mod.Find<ModItem>("ToughSilk").Type); }
		}
		if(npc.type == NPCID.WallCreeperWall) {
			if (Main.rand.NextFloat() < 0.5f) { Item.NewItem(npc.getRect(), Mod.Find<ModItem>("ToughSilk").Type); }
		}
		if(npc.type == NPCID.Demon) {
			if (Main.rand.NextFloat() < 0.5f) { Item.NewItem(npc.getRect(), Mod.Find<ModItem>("DemonBlood").Type); }
		}
		if(npc.type == NPCID.CursedSkull) {
			if (Main.rand.NextFloat() < 0.0153f) { Item.NewItem(npc.getRect(), Mod.Find<ModItem>("CursedTome").Type); }
		}
		if(npc.type == NPCID.Frankenstein) {
			if (Main.rand.NextFloat() < 0.02f) { Item.NewItem(npc.getRect(), Mod.Find<ModItem>("VialofLightning").Type); }
		}
		if(npc.type == Mod.Find<ModNPC>("TheUndying").Type) {
			if (Main.rand.NextFloat() < 0.5f) { Item.NewItem(npc.getRect(), Mod.Find<ModItem>("ChlorophyteSoul").Type); }
		}
	}
}