using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GottaGoFast
{
    public class GottaGoFastPlayer : ModPlayer
    {
        public float magicSpeed = 1f;
        public float rangedSpeed = 1f;
        public float attackSpeed = 1f;


        public override void ResetEffects()
        {
            magicSpeed = 1f;
            rangedSpeed = 1f;
            attackSpeed = 1f;
        }

        public override void PostUpdateBuffs()
        {
            if (player.HasBuff(BuffID.Werewolf) && GottaGoFast.GottaGoFastConfig.Werewolf)
            {
                player.meleeSpeed -= .051f;
                player.GetModPlayer<GottaGoFastPlayer>().attackSpeed += .051f;
            }
        }

        public override float UseTimeMultiplier(Item item)
        {
            float speed = base.UseTimeMultiplier(item);
            speed *= attackSpeed;
            if (item.magic)
            {
                speed *= magicSpeed;
            }

            if (item.ranged)
            {
                speed *= rangedSpeed;
            }

            return speed;
        }

        public override float MeleeSpeedMultiplier(Item item)
        {
            float speed = base.MeleeSpeedMultiplier(item);
            speed *= attackSpeed;
            if (item.magic)
            {
                speed *= magicSpeed;
            }

            if (item.ranged)
            {
                speed *= rangedSpeed;
            }

            return speed;
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPCWithProj(proj, target, damage, knockback, crit);
            if (proj.magic && GottaGoFast.GottaGoFastConfig.MagicImmune)
            {
                GottaGoFastPlayer modPlayer = Main.player[proj.owner].GetModPlayer<GottaGoFastPlayer>();
                float factor = modPlayer.magicSpeed * modPlayer.attackSpeed;
                if (proj.usesLocalNPCImmunity)
                {
                    proj.localNPCImmunity[target.whoAmI] = (int)(proj.localNPCImmunity[target.whoAmI] / factor);
                }
                else if (proj.usesIDStaticNPCImmunity)
                {
                    Projectile.perIDStaticNPCImmunity[proj.type][target.whoAmI] = (uint)(Projectile.perIDStaticNPCImmunity[proj.type][target.whoAmI] / factor);
                }
                else if (proj.penetrate != 1)
                {
                    target.immune[proj.owner] = (int) (target.immune[proj.owner] / factor);
                }
            }
        }
    }
}