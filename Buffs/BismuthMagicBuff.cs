using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BismuthMod.Buffs
{
	public class BismuthMagicBuff : ModBuff
	{
		/*public override bool AutoLoad(ref string name, ref string texture)
		{
			texture = "BismuthMod/Buffs/BismuthMagicBuff";
			return base.AutoLoad(ref name, ref texture);
		}*/
		public override void SetDefaults ()
		{
			DisplayName.SetDefault ("Spiritual Energy");
			Description.SetDefault ("Increases magic fire rate");
		}
		public override void Update (Player player, ref int buffIndex)
		{
			
		}
	}
}