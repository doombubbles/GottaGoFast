using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AttackSpeedMod
{
    internal class AttackSpeedPlayer : ModPlayer
    {
        public override void PostUpdateBuffs()
        {
            if (Player.HasBuff(BuffID.Werewolf) && ModContent.GetInstance<AttackSpeedConfig>().Werewolf)
            {
                Player.GetAttackSpeed(DamageClass.Melee) -= .051f;
                Player.GetAttackSpeed(DamageClass.Generic) += .051f;
            }

            if (Player.HasBuff(BuffID.WellFed) && ModContent.GetInstance<AttackSpeedConfig>().WellFed)
            {
                Player.GetAttackSpeed(DamageClass.Melee) -= .05f;
                Player.GetAttackSpeed(DamageClass.Generic) += .05f;
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPCWithProj(proj, target, damage, knockback, crit);
            if (proj.DamageType == DamageClass.Magic && ModContent.GetInstance<AttackSpeedConfig>().MagicImmune)
            {
                var player = Main.player[proj.owner];
                var factor = player.GetAttackSpeed(DamageClass.Magic) * player.GetAttackSpeed(DamageClass.Generic);
                if (proj.usesLocalNPCImmunity && proj.localNPCImmunity[target.whoAmI] != -1)
                {
                    Mod.Logger.Debug($"This one {factor} {proj.localNPCImmunity[target.whoAmI]}");
                    proj.localNPCImmunity[target.whoAmI] = (int)(proj.localNPCImmunity[target.whoAmI] / factor);
                }
                else if (proj.usesIDStaticNPCImmunity &&
                         Projectile.perIDStaticNPCImmunity[proj.type][target.whoAmI] != 0)
                {
                    Mod.Logger.Debug("No this one");
                    Projectile.perIDStaticNPCImmunity[proj.type][target.whoAmI] =
                        (uint)(Projectile.perIDStaticNPCImmunity[proj.type][target.whoAmI] / factor);
                }
                else if (proj.penetrate != 1)
                {
                    Mod.Logger.Debug("Actually this one");
                    target.immune[proj.owner] = (int)(target.immune[proj.owner] / factor);
                }
            }
        }
    }
}