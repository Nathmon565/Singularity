using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace Terraria.ModLoader
{
    public class ModGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        
        public override void SetDefaults(Projectile projectile)
        {
            if (projectile.type == 336){
                projectile.penetrate = 2;
            }
        }
    }
}