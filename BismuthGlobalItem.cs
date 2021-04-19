using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace BismuthMod
{
	public class BismuthGlobalItem : GlobalItem
	{
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
		public override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }
		
		
		/*public override void SetDefaults(Item item)
		{
			if (item.magic)
			{
				item.useTime = item.useTime - (item.UseTime / 2);
				item.useAnimation = item.useAnimation - (item.useAnimation / 2);
			}
		}*/
		
		/*int timer;
		public virtual void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[item.owner];
			if (item.owner == Main.myPlayer)
			{
				if(item.magic && player.GetModPlayer<BismuthPlayer>().bismuthMagicHorny == true)
				{
					item.useTime -= item.useTime - (item.useTime / 2);
					item.useAnimation -= item.useAnimation - (item.useAnimation / 2);
					timer++;
				}
				if(timer >= Main.rand.Next(110, 140))
				{
					player.GetModPlayer<BismuthPlayer>().bismuthMagicHorny = false;
					timer = 0;
				}
			}
		}*/
	}
}


