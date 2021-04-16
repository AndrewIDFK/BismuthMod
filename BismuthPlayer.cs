using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BismuthMod
{
	public class MyPlayer : ModPlayer //In this file we make most of the custom effects for acessories, armor and other equippables/consumables.
	{
		public bool bismuthMeleeSet; //Doing this creates "bismuthMeleeSet" and makes it into a true/false statement.
		
		public override void ResetEffects()
		{
			bismuthMeleeSet = false; //Makes "bismuthMeleeSet" false when bismuthMeleeSet isn't being set to true. (Having a full melee set equipped makes "bismuthMeleeSet" true, having this here makes "bismuthMeleeSet" false once the full set isn't equipped anymore.)
		}
		
		public override void OnHitByNPC(NPC target, int damage, bool crits)
		{
			//Stuff in this happens when the player is getting hit. Suprisingly has less uses than PostHurt although still useful.
		}
		
		public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			//Stuff in this happens after the player has been hit by and enemy or projectile, this is where most of the Shield set-bonus code is gonna go.
		}
		
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			//Stuff in this happens when player hits an enemy with an item, like Swords, Pickaxes, Axes and the like.
		}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			//Stuff in this happens when player hits an enemy with a projectile, like Sword Beams, Magic Bolts, Arrows, Bullets and the likes.
		}
	}
}
