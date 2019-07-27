# GottaGoFast

To use GottaGoFast's Magic Speed, Ranged Speed, or Attack Speed values, we use Mod.Call()

```c#
Mod gottaGoFast = ModLoader.GetMod("GottaGoFast");
if(gottaGoFast != null)
{
    //First Argument is a string for the type; either "magicSpeed", "rangedSpeed" or "attackSpeed"
    //Second Argument is an int for the index of the player in question; You can get that using player.whoAmI
    //Third argument is a float for the value to add; e.g. .1f for 10% increase, -.05f for 5% decrease
    gottaGoFast.Call("attackSpeed", player.whoAmI, .15f);
} else {
    //If the player doesn't have the mod, just increase melee speed
    player.meleeSpeed += .15f;
}
```
