using Singularity;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Singularity.Projectiles;
using Microsoft.CodeAnalysis;

namespace Singularity.Items.Weapons
{
	public class GlassRepeater : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Don't drop it!");
		}

		public override void SetDefaults() {
			Item.damage = 18; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.DamageType = DamageClass.Ranged; // sets the damage type to ranged
			Item.width = 40; // hitbox width of the item
			Item.height = 20; // hitbox height of the item
			Item.useTime = 24; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 24; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			Item.useStyle = ItemUseStyleID.Shoot; // how you use the item (swinging, holding out, etc)
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = -1; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.value = 5000; // how much the item sells for (measured in copper)
			Item.rare = ItemRarityID.Green; // the color that the item's name will be in-game
			Item.UseSound = SoundID.Item5; // The sound that this item plays when used.
			Item.autoReuse = true; // if you can hold click to automatically use it again
			Item.shoot = 10; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 12f; // the speed of the projectile (measured in pixels per frame)
			Item.useAmmo = AmmoID.Arrow; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}
		// Help, my gun isn't being held at the handle! Adjust these 2 numbers until it looks right.
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 0);
		}

		/*public virtual void ModifyShootStats(Player player, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            type = Mod.Find<ModProjectile>("GlassArrow").Type;
        }*/
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = Mod.Find<ModProjectile>("GlassArrow").Type;
				Projectile.NewProjectile(Item.GetSource_FromThis(), position, velocity, type, damage, knockback);
				return false;
            }
            else{
				return true;
				} // return true to allow tmodloader to call Projectile.NewProjectile as normal
        }
    }
}