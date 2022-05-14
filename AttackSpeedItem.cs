using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AttackSpeedMod
{
    public class AttackSpeedItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(item, tooltips);
            var modifierTrue = false;
            var itemTrue = false;
            if (ModContent.GetInstance<AttackSpeedConfig>().AttackSpeedPrefix)
            {
                if (item.prefix == PrefixID.Wild || item.prefix == PrefixID.Rash || 
                    item.prefix == PrefixID.Intrepid || item.prefix == PrefixID.Violent)
                {
                    modifierTrue = true;
                }
            }

            if (ModContent.GetInstance<AttackSpeedConfig>().Stones && item.type == ItemID.CelestialStone)
            {
                itemTrue = true;
            }

            if (ModContent.GetInstance<AttackSpeedConfig>().ShadowArmor)
            {
                if (item.type is ItemID.ShadowHelmet or ItemID.ShadowScalemail or ItemID.ShadowGreaves)
                {
                    itemTrue = true;
                }
            }

            if (modifierTrue)
            {
                foreach (var tooltipLine in tooltips.Where(tooltipLine => tooltipLine.IsModifier && tooltipLine.Text.Contains("melee speed")))
                {
                    tooltipLine.Text = tooltipLine.Text.Replace("melee speed", "attack speed");
                }
            }

            if (itemTrue)
            {
                foreach (var tooltipLine in tooltips.Where(tooltipLine => !tooltipLine.IsModifier && tooltipLine.Text.Contains("melee speed")))
                {
                    tooltipLine.Text = tooltipLine.Text.Replace("melee speed", "attack speed");
                }
            }
            
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (ModContent.GetInstance<AttackSpeedConfig>().AttackSpeedPrefix)
            {
                switch (item.prefix)
                {
                    case PrefixID.Wild:
                        player.GetAttackSpeed(DamageClass.Melee) -= .01f;
                        player.GetAttackSpeed(DamageClass.Generic) += .01f;
                        break;
                    case PrefixID.Rash:
                        player.GetAttackSpeed(DamageClass.Melee) -= .02f;
                        player.GetAttackSpeed(DamageClass.Generic) += .02f;
                        break;
                    case PrefixID.Intrepid:
                        player.GetAttackSpeed(DamageClass.Melee) -= .03f;
                        player.GetAttackSpeed(DamageClass.Generic) += .03f;
                        break;
                    case PrefixID.Violent:
                        player.GetAttackSpeed(DamageClass.Melee) -= .04f;
                        player.GetAttackSpeed(DamageClass.Generic) += .04f;
                        break;
                }
            }

            if (ModContent.GetInstance<AttackSpeedConfig>().Stones)
            {
                if (item.type == ItemID.MoonStone && (!Main.dayTime || Main.eclipse) || 
                    item.type == ItemID.SunStone && Main.dayTime ||
                    item.type is ItemID.CelestialStone or ItemID.CelestialShell)
                {
                    player.GetAttackSpeed(DamageClass.Melee) -= .1f;
                    player.GetAttackSpeed(DamageClass.Generic) += .1f;
                }
            }

            if (ModContent.GetInstance<AttackSpeedConfig>().ShadowArmor)
            {
                if (item.type is ItemID.ShadowHelmet or ItemID.ShadowScalemail or ItemID.ShadowGreaves)
                {
                    player.GetAttackSpeed(DamageClass.Melee) -= .07f;
                    player.GetAttackSpeed(DamageClass.Generic) += .07f;
                }
            }

            base.UpdateEquip(item, player);
        }
    }
}