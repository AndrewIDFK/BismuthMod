using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using BismuthMod;

namespace BismuthMod
{
	public class BismuthPlayer : ModPlayer //In this file we make most of the custom effects for acessories, armor and other equippables/consumables.
	{
		//MISC STUFF
		public int oldHeldItem;
		public bool shootsArrow; // check if shooting bang-bang arrows
		public bool shootsBullet; // check if shooting pew-pew bullets
		
		//MELEE SET
		public bool bismuthMeleeSet; //Doing this creates "bismuthMeleeSet" and makes it into a true/false statement.
		public int bismuthMeleeSetCD; //Doing this creates "bismuthMeleeSetCD" and makes it into a number pretty much. There's more to it but can't explain with quick sentence.
		
		//MAGIC SET
		public bool bismuthMagicSet;
		public bool bismuthMagicHorny;
		
		//RANGED SET
		public bool bismuthRangedSet;
		
		int timer;
		public override void ResetEffects()
		{
			bismuthMeleeSet = false; //Makes "bismuthMeleeSet" false when bismuthMeleeSet isn't being set to true. (Having a full melee set equipped makes "bismuthMeleeSet" true, having this here makes "bismuthMeleeSet" false once the full set isn't equipped anymore.)
			bismuthMagicSet = false;
			bismuthRangedSet = false;
		}
		
		
		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			//Stuff in this happens right before the player recieves damage from a hit by an enemy or projectile, this is where most of the Shield set-bonus code is gonna go.
			
			int realDamage = damage - (player.statDefense / 2); // Helps calculate the damage that enemies actually do when taking defense into account.
			if(realDamage <= 1) //This and the thing inside it makes realDamage's minimum number into 1, every time it goes to or below 1 it gets forced to be 1.
			{
				realDamage = 1;
			}
			if (player.whoAmI == Main.myPlayer) // Makes it so only you get the effects inside this thing, fixes multiplayer stuff.
			{
				if(bismuthMeleeSet) // This works exactly like "bismuthMeleeSet == true" but it's easier to type. Once again, stuff inside this happens when the melee set is equipped.
				{
					if(bismuthMeleeSetCD == 0) //Checks if the cooldown is at 0, if it's not then the effect won't happen.
					{
						if(realDamage >= 5 && realDamage <= 50) // If player gets hurt for 5 and more AND 50 and below, stuff inside this happens.
						{
							player.immune = true; //Everything inside this pretty much makes the player invincible for 80 ticks and if they have player.longInvince enabled, then the player is invincible for 110 ticks
							player.immuneTime = 80;
							if (player.longInvince)
							{
								player.immuneTime += 30;
							}
							for (int i = 0; i < player.hurtCooldowns.Length; i++)
							{
								player.hurtCooldowns[i] = player.immuneTime;
							}
							
							//Here we add a cooldown to the effect. Making it only work after a 10 second cooldown.
							bismuthMeleeSetCD = 600; //Code at the bottom of this file explains why it's 600 and how it decreases.
						
							//This is needed here, otherwise it doesn't work. Annoying stuff.
							return false;
						}
					}
				}
			}
			return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
		}
		
		public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			//Stuff in this happens after the player has been hit by an enemy or projectile.
		}
		
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			//Stuff in this happens when player hits an enemy with an item, like Swords, Pickaxes, Axes and the likes.
		}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			//Stuff in this happens when player hits an enemy with a projectile, like Sword Beams, Magic Bolts, Arrows, Bullets and the likes.
		}
		
		public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) 
		{
			if(item.ranged && bismuthRangedSet)
			{
				if(item.useAmmo == AmmoID.Arrow)
				{
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BismuthRangedArrow"), damage / 2, knockBack / 4, player.whoAmI, 0f, 0f);
				}
				if(item.useAmmo == AmmoID.Bullet)
				{
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BismuthRangedBullet"), damage / 2, knockBack / 4, player.whoAmI, 0f, 0f);
				}
			}
			return true;
		}
		
		public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
		{
			if (bismuthMeleeSet && bismuthMeleeSetCD == 600) 
			{
				for (int i = 0; i < 14; i++)
				{
					int num4 = Dust.NewDust(player.Center, player.width, player.height, 235, 0f, 0f, 100, Main.DiscoColor, 0.5f);
					Main.dust[num4].scale = 0.54f + (float)Main.rand.Next(5) * 0.05f;
					Main.dust[num4].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
					Main.dust[num4].noGravity = false;
					Main.dust[num4].velocity *= 5;
					Main.dust[num4].position = player.Center + new Vector2(0f, -(float)player.height / 2f).RotatedBy((double)player.direction, default(Vector2)) * 1.1f;
					num4 = Dust.NewDust(player.Center, player.width, player.height, 235, 0f, 0f, 100, Main.DiscoColor, 0.5f);
					Main.dust[num4].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
					Main.dust[num4].noGravity = false;
					Main.dust[num4].velocity *= 5;
					Main.dust[num4].position = player.Center + new Vector2(0f, -(float)player.height / 2f - 6f).RotatedBy((double)player.direction, default(Vector2)) * 1.1f;
				}
			}
		}
		
		public static readonly PlayerLayer DrawStuff = new PlayerLayer("BismuthMod", "DrawStuff", PlayerLayer.MiscEffectsBack, delegate (PlayerDrawInfo drawInfo) 
		{
            //In here we draw a layer in the "background", this is where we actually make the shield sprite spawn ontop of the player.
            if (drawInfo.shadow != 0f) 
			{
				return;
			}
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("BismuthMod");
            BismuthPlayer mPlayer = drawPlayer.GetModPlayer<BismuthPlayer>();
            
			if(mPlayer.bismuthMeleeSet && mPlayer.bismuthMeleeSetCD == 0)
			{
				Texture2D shieldTexture = mod.GetTexture("Textures/BismuthMeleeShield");
				int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X);
				int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f - Main.screenPosition.Y);
				DrawData data = new DrawData(shieldTexture, new Vector2(drawX, drawY), new Rectangle(0, 0, shieldTexture.Width, shieldTexture.Height), Main.DiscoColor * 0.2f, 0f, new Vector2(shieldTexture.Width / 2f, shieldTexture.Height / 2f), 1f, SpriteEffects.None, 0);
				Main.playerDrawData.Add(data);
			}
        });
		
		public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            layers.Insert(0, DrawStuff);
            layers.Add(DrawStuff);
            DrawStuff.visible = true;
        }
		int lockNR = 0;
		public override void OnConsumeMana (Item item, int manaConsumed)
		{
			if(item.magic)
			{
				if (bismuthMagicHorny == true)
				{
					if(lockNR == 0)
					{
						item.useTime = item.useTime - ((item.useTime * 2) / 10);
						item.useAnimation = item.useAnimation - ((item.useAnimation * 2) / 10);
						lockNR = 1;
						Main.NewText(item.useTime + " Fire-rate buff active useTime number");
					}
				}
				else
				{
					if(lockNR == 1)
					{
						item.useTime = item.useTime + ((item.useTime * 2) / 10);
						item.useAnimation = item.useAnimation + ((item.useAnimation * 2) / 10);
						lockNR = 0;
						Main.NewText(item.useTime + " Fire-rate buff deactive useTime number");
					}
				}
			}	
		}

		int magicSetTimer = 0;
		public override void PostUpdateMiscEffects()
		{
			//Everything in here happens once every tick. 1 second = 60 ticks. Usually used to enable some effects or make cooldowns. Used for all bunch of stuff though.
			if(bismuthMeleeSetCD >= 1) //Everything inside this happens when "bismuthMeleeSetCD" is equal or higher than 1. In this we make "bismuthMeleeSetCD" count down to 0, by decreasing its number by 1 every tick.
			{
				bismuthMeleeSetCD--; //Decreases "bismuthMeleeSetCD"'s number by 1 every tick.
			}
			//Now the cooldown decreasing thingy has been made, but we don't know if it'll work perfectly. It's totally fine to only have that short code above this comment, but we can make it safer by forcing "bismuthMeleeSetCD"  to 0 when it's lower than 0.
			if(bismuthMeleeSetCD < 0) //Everything inside this happens when "bismuthMeleeSetCD" is less than 0, so basically all the negative numbers. In this we force "bismuthMeleeSetCD" to 0 if it's less than 0. Just a safter function that most of the time isn't needed.
			{
				bismuthMeleeSetCD = 0;
			}
			
			if(bismuthMagicHorny == true)
			{
				magicSetTimer++;
			}
			if(magicSetTimer >= Main.rand.Next(110, 170))
			{
				Main.NewText("Fire-rate Stop");
				bismuthMagicHorny = false;
				magicSetTimer = 0;
			}
			
			if (player.HeldItem.type != oldHeldItem)
			{
				bismuthMagicHorny = false;
				magicSetTimer = 0;
				lockNR = 0;
			}
			oldHeldItem = player.HeldItem.type;
		}	
	}
}
