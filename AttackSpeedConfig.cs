using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace AttackSpeedMod
{
    public class AttackSpeedConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        
        [DefaultValue(true)]
        [Label("Melee Speed Prefix Affects All Attack Speed")]
        public bool AttackSpeedPrefix{ get; set; }
        
        [DefaultValue(true)]
        [Label("Moon/Sun/Celestial Stone/Shell Affect All Attack Speed")]
        public bool Stones{ get; set; }
        
        [DefaultValue(true)]
        [Label("Werewolf Buff Affects All Attack Speed")]
        public bool Werewolf{ get; set; }
        
        [DefaultValue(true)]
        [Label("Shadow Armor Affects All Attack Speed")]
        public bool ShadowArmor{ get; set; }
        
        [DefaultValue(true)]
        [Label("Well Fed Buff Affects All Attack Speed")]
        public bool WellFed{ get; set; }
        
        [DefaultValue(true)]
        [Label("Magic Speed reduces enemy immune time (for piercing weapons)")]
        public bool MagicImmune{ get; set; }

        
        
        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            if (whoAmI == 0) {
                message = "Changes accepted!";
                return true;
            }
            message = "You had no right to do that.";
            return false;
        }
    }
    
    
}