using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
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
		
		
		
	}
}


