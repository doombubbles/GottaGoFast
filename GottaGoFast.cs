using System;
using Terraria;
using Terraria.ModLoader;

namespace GottaGoFast
{
	public class GottaGoFast : Mod
	{
		internal static GottaGoFastConfig GottaGoFastConfig;
		
		public GottaGoFast()
		{
			
		}
		
		public override void Unload()
		{
			GottaGoFastConfig = null;
		}

		public override object Call(params object[] args)
		{
			try
			{
				string message = args[0] as string;
				if (message == "magicSpeed")
				{
					int whoAmI = Convert.ToInt32(args[1]);
					float value = Convert.ToSingle(args[2]);
					Main.player[whoAmI].GetModPlayer<GottaGoFastPlayer>().magicSpeed += value;
				} else if (message == "rangedSpeed")
				{
					int whoAmI = Convert.ToInt32(args[1]);
					float value = Convert.ToSingle(args[2]);
					Main.player[whoAmI].GetModPlayer<GottaGoFastPlayer>().rangedSpeed += value;
				}
				else if (message == "attackSpeed") {
					int whoAmI = Convert.ToInt32(args[1]);
					float value = Convert.ToSingle(args[2]);
					Main.player[whoAmI].GetModPlayer<GottaGoFastPlayer>().attackSpeed += value;
				}
				return "Success";
			}
			catch (Exception e)
			{
				Logger.ErrorFormat("GottaGoFast Call Error: " + e.StackTrace + e.Message);
			}	
			return "Failure";
		}
	}
}