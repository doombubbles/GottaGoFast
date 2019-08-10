using On.Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using ProjectileID = Terraria.ID.ProjectileID;

namespace GottaGoFast
{
    public class GottaGoFastProjectile : GlobalProjectile
    {
        public override void PostAI(Projectile projectile)
        {
            if (projectile.type == 439)
            {
                Player player = Main.player[projectile.owner];
                Item item = player.inventory[player.selectedItem];
                int time = (int)((float)item.useTime / PlayerHooks.TotalUseTimeMultiplier(player, item));
                projectile.ai[0] += 20f / time - 1;
                projectile.ai[1] += 20f / time - 1;
            }

            if (projectile.type == ProjectileID.VortexBeater)
            {
                Player player = Main.player[projectile.owner];
                Item item = player.inventory[player.selectedItem];
                int time = (int)((float)item.useTime / PlayerHooks.TotalUseTimeMultiplier(player, item));
                projectile.ai[0] += 20f / time - 1;
                projectile.ai[1] -= 20f / time - 1;
                
                if (projectile.ai[0] >= 40f)
                {
                    projectile.ai[1] -= .1f;
                    if (Main.rand.Next(1, 10) == 1)
                    {
                        projectile.soundDelay--;
                    }
                }
                if (projectile.ai[0] >= 80f)
                {
                    projectile.ai[1] -= .2f;
                    
                    if (Main.rand.Next(1, 10) <= 2)
                    {
                        projectile.soundDelay--;
                    }
                }
                if (projectile.ai[0] >= 120f)
                {
                    projectile.ai[1] -= .3f;
                    if (Main.rand.Next(1, 10) <= 3)
                    {
                        projectile.soundDelay--;
                    }
                }
            }
        }
    }
}