using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BismuthMod
{
	public class BismuthGlobalProjectile : GlobalProjectile // This is a really weird class, a lot of custom stuff doesn't work in this because MAYBE it changes some of the Terraria source, since it's global, you can change almost every projectile, vanilla or modded in this Class.
	{
		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit) 
		{
			if (projectile.owner == Main.myPlayer) //This is used to fix massive problems in multiplayer. Makes it so that only you get the effects that happen inside this "if" hook, not your friends.
			{			
				if (projectile.minion || ProjectileID.Sets.MinionShot[projectile.type]) //Stuff in this happens only when a minion OR a Minion's projectile hits an NPC.
				{
					//Add random chance for minions to do a special thing when they hit enemy while bismuth mask set is equipped.
				}	
			}	
		}
	}
}