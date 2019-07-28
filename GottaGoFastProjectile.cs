using Terraria;
using Terraria.ModLoader;

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
        }
    }
}