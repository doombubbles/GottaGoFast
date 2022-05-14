using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AttackSpeedMod.Items
{
    internal class TheSecondAmendment : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Second Amendment");
            Tooltip.SetDefault("17.76% increased ranged firing rate");
        }

        public override void SetDefaults()
        {
            Item.value = 100000;
            Item.width = 30;
            Item.height = 30;
            Item.rare = ItemRarityID.Lime;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetAttackSpeed(DamageClass.Ranged) += .1776f;
        }

        public override void AddRecipes()
        {
            var recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddIngredient(ItemID.Feather);
            recipe.AddIngredient(ItemID.BlackInk);
            recipe.AddIngredient(ItemID.MusketBall, 1776);
            recipe.AddTile(TileID.LihzahrdAltar);
            recipe.Register();
        }
    }
}
