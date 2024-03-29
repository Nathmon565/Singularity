// using Microsoft.Xna.Framework;
// using Microsoft.Xna.Framework.Graphics;
// using System;
// using System.Collections.Generic;
// using System.IO;
// using Terraria.DataStructures;
// using Terraria.GameInput;
// using Terraria.ModLoader.IO;

// namespace Terraria.ModLoader
// {
//     public class ModPlayer
//     {
//         public Mod mod {
//             get;
//             internal set;
//         }

//         public string Name {
//             get;
//             internal set;
//         }

//         public Player player {
//             get;
//             internal set;
//         }

//         internal int index;

//         internal ModPlayer CreateFor(Player newPlayer) {
//             ModPlayer modPlayer = (ModPlayer)(CloneNewInstances ? MemberwiseClone() : Activator.CreateInstance(GetType()));
//             modPlayer.Name = Name;
//             modPlayer.mod = mod;
//             modPlayer.player = newPlayer;
//             modPlayer.index = index;
//             modPlayer.Initialize();
//             return modPlayer;
//         }

//         public bool TypeEquals(ModPlayer other) {
//             return mod == other.mod && Name == other.Name;
//         }

//         public virtual bool CloneNewInstances => true;

//         public virtual bool Autoload(ref string name) {
//             return mod.Properties.Autoload;
//         }

//         public virtual void Initialize() {
//         }

//         public virtual void ResetEffects() {
//         }

//         public virtual void UpdateDead() {
//         }

//         public virtual void PreSaveCustomData() {
//         }

//         public virtual TagCompound Save() {
//             return null;
//         }

//         public virtual void Load(TagCompound tag) {
//         }

//         public virtual void LoadLegacy(BinaryReader reader) {
//         }

//         public virtual void SetupStartInventory(IList<Item> items, bool mediumcoreDeath) {
//         }

//         // @todo: SetupStartInventory marked obsolete until v0.11
//         [method: Obsolete("SetupStartInventory now has an overload with a mediumcoreDeath bool argument, please use that.")]
//         public virtual void SetupStartInventory(IList<Item> items) {
//         }

//         public virtual void PreSavePlayer() {
//         }

//         public virtual void PostSavePlayer() {
//         }

//         public virtual void UpdateBiomes() {
//         }

//         public virtual bool CustomBiomesMatch(Player other) {
//             return true;
//         }

//         public virtual void CopyCustomBiomesTo(Player other) {
//         }

//         public virtual void SendCustomBiomes(BinaryWriter writer) {
//         }

//         public virtual void ReceiveCustomBiomes(BinaryReader reader) {
//         }

//         public virtual void UpdateBiomeVisuals() {
//         }

//         public virtual void clientClone(ModPlayer clientClone) {
//         }

//         public virtual void SyncPlayer(int toWho, int fromWho, bool newPlayer) {
//         }

//         public virtual void SendClientChanges(ModPlayer clientPlayer) {
//         }

//         public virtual Texture2D GetMapBackgroundImage() {
//             return null;
//         }

//         public virtual void UpdateBadLifeRegen() {
//         }

//         public virtual void UpdateLifeRegen() {
//         }

//         public virtual void NaturalLifeRegen(ref float regen) {
//         }

//         public virtual void UpdateAutopause() {
//         }

//         public virtual void PreUpdate() {
//         }

//         public virtual void ProcessTriggers(TriggersSet triggersSet) {
//         }

//         public virtual void SetControls() {
//         }

//         public virtual void PreUpdateBuffs() {
//         }

//         public virtual void PostUpdateBuffs() {
//         }

//         public virtual void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff) {
//         }

//         public virtual void PostUpdateEquips() {
//         }

//         public virtual void PostUpdateMiscEffects() {
//         }

//         public virtual void PostUpdateRunSpeeds() {
//         }

//         public virtual void PreUpdateMovement() {
//         }

//         public virtual void PostUpdate() {
//         }

//         public virtual void UpdateVanityAccessories() {
//         }

//         public virtual void FrameEffects() {
//         }

//         public virtual bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
//             ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {
//             return true;
//         }
        
//         public virtual void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
            
//         }

//         public virtual void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
//         }

//         public virtual bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore,
//             ref PlayerDeathReason damageSource) {
//             return true;
//         }

//         public virtual void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource) {
//         }

//         public virtual bool PreItemCheck() {
//             return true;
//         }

//         public virtual void PostItemCheck() {
//         }

//         public virtual float UseTimeMultiplier(Item item) {
//             return 1f;
//         }

//         public virtual float MeleeSpeedMultiplier(Item item) {
//             return 1f;
//         }

//         public virtual void GetHealLife(Item item, bool quickHeal, ref int healValue) {
//         }

//         public virtual void GetHealMana(Item item, bool quickHeal, ref int healValue) {
//         }

//         public virtual void ModifyManaCost(Item item, ref float reduce, ref float mult) {
//         }

//         public virtual void OnMissingMana(Item item, int neededMana) {
//         }

//         public virtual void OnConsumeMana(Item item, int manaConsumed) {
//         }

//         [Obsolete("Use ModifyWeaponDamage", true)]
//         public virtual void GetWeaponDamage(Item item, ref int damage) {
//         }

//         [Obsolete("Use ModifyWeaponDamage overload with the additional flat parameter")]
//         public virtual void ModifyWeaponDamage(Item item, ref float add, ref float mult) {
//         }

//         public virtual void ModifyWeaponDamage(Item item, ref float add, ref float mult, ref float flat) {
//         }

//         public virtual void GetWeaponKnockback(Item item, ref float knockback) {
//         }

//         public virtual void GetWeaponCrit(Item item, ref int crit) {
//         }

//         public virtual bool ConsumeAmmo(Item weapon, Item ammo) {
//             return true;
//         }

//         public virtual void OnConsumeAmmo(Item weapon, Item ammo) {
//         }

//         public virtual bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
//             return true;
//         }

//         public virtual void MeleeEffects(Item item, Rectangle hitbox) {
//         }

//         public virtual void OnHitAnything(float x, float y, Entity victim) {
//         }

//         public virtual bool? CanHitNPC(Item item, NPC target) {
//             return null;
//         }

//         public virtual void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit) {
//         }

//         public virtual void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit) {
//         }

//         public virtual bool? CanHitNPCWithProj(Projectile proj, NPC target) {
//             return null;
//         }

//         public virtual void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
//         }

//         public virtual void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit) {
//         }

//         public virtual bool CanHitPvp(Item item, Player target) {
//             return true;
//         }

//         public virtual void ModifyHitPvp(Item item, Player target, ref int damage, ref bool crit) {
//         }

//         public virtual void OnHitPvp(Item item, Player target, int damage, bool crit) {
//         }

//         public virtual bool CanHitPvpWithProj(Projectile proj, Player target) {
//             return true;
//         }

//         public virtual void ModifyHitPvpWithProj(Projectile proj, Player target, ref int damage, ref bool crit) {
//         }

//         public virtual void OnHitPvpWithProj(Projectile proj, Player target, int damage, bool crit) {
//         }

//         public virtual bool CanBeHitByNPC(NPC npc, ref int cooldownSlot) {
//             return true;
//         }

//         public virtual void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit) {
//         }

//         public virtual void OnHitByNPC(NPC npc, int damage, bool crit) {
//         }

//         public virtual bool CanBeHitByProjectile(Projectile proj) {
//             return true;
//         }

//         public virtual void ModifyHitByProjectile(Projectile proj, ref int damage, ref bool crit) {
//         }

//         public virtual void OnHitByProjectile(Projectile proj, int damage, bool crit) {
//         }

//         public virtual void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk) {
//         }

//         public virtual void GetFishingLevel(Item fishingRod, Item bait, ref int fishingLevel) {
//         }

//         public virtual void AnglerQuestReward(float rareMultiplier, List<Item> rewardItems) {
//         }

//         public virtual void GetDyeTraderReward(List<int> rewardPool) {
//         }

//         public virtual void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright) {
//         }

//         public virtual void ModifyDrawInfo(ref PlayerDrawInfo drawInfo) {
//         }

//         public virtual void ModifyDrawLayers(List<PlayerLayer> layers) {
//         }

//         public virtual void ModifyDrawHeadLayers(List<PlayerHeadLayer> layers) {
//         }

//         public virtual void ModifyScreenPosition() {
//         }

//         public virtual void ModifyZoom(ref float zoom) {
//         }

//         public virtual void PlayerConnect(Player player) {
//         }

//         public virtual void PlayerDisconnect(Player player) {
//         }

//         public virtual void OnEnterWorld(Player player) {
//         }

//         public virtual void OnRespawn(Player player) {
//         }

//         public virtual bool ShiftClickSlot(Item[] inventory, int context, int slot) {
//             return false;
//         }

//         public virtual void PostSellItem(NPC vendor, Item[] shopInventory, Item item) {
//         }

//         public virtual bool CanSellItem(NPC vendor, Item[] shopInventory, Item item) {
//             return true;
//         }

//         public virtual void PostBuyItem(NPC vendor, Item[] shopInventory, Item item) {
//         }

//         public virtual bool CanBuyItem(NPC vendor, Item[] shopInventory, Item item) {
//             return true;
//         }

//         public virtual bool ModifyNurseHeal(NPC nurse, ref int health, ref bool removeDebuffs, ref string chatText) {
//             return true;
//         }

//         public virtual void ModifyNursePrice(NPC nurse, int health, bool removeDebuffs, ref int price) {
//         }

//         public virtual void PostNurseHeal(NPC nurse, int health, bool removeDebuffs, int price) {
//         }
//     }
// }
