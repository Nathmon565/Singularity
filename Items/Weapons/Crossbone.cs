using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Singularity.Items.Weapons {
	public class Crossbone : ModItem {
		public override void SetStaticDefaults() {
		}
        public override void SetDefaults() {
			Item.damage = 36; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.crit = 16;
			Item.DamageType = DamageClass.Ranged; // sets the damage type to ranged
			Item.width = 40; // hitbox width of the item
			Item.height = 20; // hitbox height of the item
			Item.useTime = 1; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 1; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			//item.holdStyle = 1;
			Item.useStyle = ItemUseStyleID.Shoot; // how you use the item (swinging, holding out, etc)
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 4; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.value = 5000; // how much the item sells for (measured in copper)
			Item.rare = ItemRarityID.Green; // the color that the item's name will be in-game
			//item.UseSound = SoundID.Item5; // The sound that this item plays when used.
			Item.autoReuse = true; // if you can hold click to automatically use it again
			Item.shoot = 10; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 8f; // the speed of the projectile (measured in pixels per frame)
			Item.useAmmo = 21; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
			Item.channel = true;
		}
        public bool IsCrossbone;
		public int Crossbonetimer;
        public override bool CanConsumeAmmo (Item ammo, Player player){
			if (Crossbonetimer != 59){
			return false;
			}
			else{
			return true;
			}
		}
        public override void HoldItem (Player player){
			IsCrossbone = true;
			if (Crossbonetimer <= 57){
				Item.UseSound = null;
			}
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback){	
			if (Crossbonetimer == 0){
				Item.UseSound = null;
				Item.autoReuse = false;
			}
			Crossbonetimer ++;
			if (Crossbonetimer < 58){
				Item.autoReuse = true;
				Item.UseSound = null;
				//item.useAmmo = AmmoID.None;
			}
			if (Crossbonetimer == 58){
				Item.UseSound = SoundID.Item17;
			}
			if (Crossbonetimer == 59){
				Item.UseSound = SoundID.Item5;
				//item.useAmmo = AmmoID.Arrow;
				Item.autoReuse = false;
			}
			if (Crossbonetimer >= 60){
				Crossbonetimer = 0;
				Item.UseSound = null;
				type = ProjectileID.Bone;
                Projectile.NewProjectile(Item.GetSource_FromThis(),position.X, position.Y, Main.rand.NextFloat(velocity.X-2, velocity.X+2), Main.rand.NextFloat(velocity.Y-2, velocity.Y+2), type, damage, knockback);
				Projectile.NewProjectile(Item.GetSource_FromThis(),position.X, position.Y, Main.rand.NextFloat(velocity.X-2, velocity.X+2), Main.rand.NextFloat(velocity.Y-2, velocity.Y+2), type, damage, knockback);
				Projectile.NewProjectile(Item.GetSource_FromThis(),position.X, position.Y, Main.rand.NextFloat(velocity.X-2, velocity.X+2), Main.rand.NextFloat(velocity.Y-2, velocity.Y+2), type, damage, knockback);
				Projectile.NewProjectile(Item.GetSource_FromThis(),position.X, position.Y, Main.rand.NextFloat(velocity.X-2, velocity.X+2), Main.rand.NextFloat(velocity.Y-2, velocity.Y+2), type, damage, knockback);
                return false;
			}
			return false;
		}
    }
}