using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GottaGoFast
{
    public class GottaGoFastItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(item, tooltips);
            bool modifierTrue = false;
            bool itemTrue = false;
            if (GottaGoFast.GottaGoFastConfig.AttackSpeedPrefix)
            {
                if (item.prefix == PrefixID.Wild || item.prefix == PrefixID.Rash || 
                    item.prefix == PrefixID.Intrepid || item.prefix == PrefixID.Violent)
                {
                    modifierTrue = true;
                }
            }

            if (GottaGoFast.GottaGoFastConfig.Stones && item.type == ItemID.CelestialStone)
            {
                itemTrue = true;
            }

            if (GottaGoFast.GottaGoFastConfig.ShadowArmor)
            {
                if (item.type == ItemID.ShadowHelmet ||
                    item.type == ItemID.ShadowScalemail ||
                    item.type == ItemID.ShadowGreaves)
                {
                    itemTrue = true;
                }
            }

            if (modifierTrue)
            {
                foreach (var tooltipLine in tooltips)
                {
                    if (tooltipLine.isModifier && tooltipLine.text.Contains("melee speed"))
                    {
                        tooltipLine.text = tooltipLine.text.Replace("melee speed", "attack speed");
                    }
                }
            }

            if (itemTrue)
            {
                foreach (var tooltipLine in tooltips)
                {
                    if (!tooltipLine.isModifier && tooltipLine.text.Contains("melee speed"))
                    {
                        tooltipLine.text = tooltipLine.text.Replace("melee speed", "attack speed");
                    }
                }
            }
            
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (GottaGoFast.GottaGoFastConfig.AttackSpeedPrefix)
            {
                if (item.prefix == PrefixID.Wild)
                {
                    player.meleeSpeed -= .01f;
                    player.GetModPlayer<GottaGoFastPlayer>().attackSpeed += .01f;
                }

                if (item.prefix == PrefixID.Rash)
                {
                    player.meleeSpeed -= .02f;
                    player.GetModPlayer<GottaGoFastPlayer>().attackSpeed += .02f;
                }

                if (item.prefix == PrefixID.Intrepid)
                {
                    player.meleeSpeed -= .03f;
                    player.GetModPlayer<GottaGoFastPlayer>().attackSpeed += .03f;
                }

                if (item.prefix == PrefixID.Violent)
                {
                    player.meleeSpeed -= .04f;
                    player.GetModPlayer<GottaGoFastPlayer>().attackSpeed += .04f;
                }
            }

            if (GottaGoFast.GottaGoFastConfig.Stones)
            {
                if (item.type == ItemID.MoonStone && (!Main.dayTime || Main.eclipse) || 
                    item.type == ItemID.SunStone && Main.dayTime ||
                    item.type == ItemID.CelestialStone || item.type == ItemID.CelestialShell)
                {
                    player.meleeSpeed -= .1f;
                    player.GetModPlayer<GottaGoFastPlayer>().attackSpeed += .1f;
                }
            }

            if (GottaGoFast.GottaGoFastConfig.ShadowArmor)
            {
                if (item.type == ItemID.ShadowHelmet ||
                    item.type == ItemID.ShadowScalemail ||
                    item.type == ItemID.ShadowGreaves)
                {
                    player.meleeSpeed -= .07f;
                    player.GetModPlayer<GottaGoFastPlayer>().attackSpeed += .07f;
                }
            }

            base.UpdateEquip(item, player);
        }
    }
}