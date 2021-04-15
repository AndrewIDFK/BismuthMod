using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	public class SteeleEdge : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Steele Edge");
			Tooltip.SetDefault("Inflics Steele Poisoning upon enemies \nIgnores enemy immunity frames");
		}

		public override void SetDefaults()
		{
			item.damage = 69;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = 1;
			item.knockBack = 7f;
			item.value = Item.buyPrice(0, 1, 40, 0);
			item.value = Item.sellPrice(0, 1, 40, 0);
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1.2f;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Utils.NextBool(Main.rand, 3))
			{
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, base.mod.DustType("SteeleDust"), 0f, 0f, 0, default(Color), 1f);
				
			}
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.immune[item.owner] = 0;
			target.AddBuff(mod.BuffType("SteeleDebuff"), 280, false);
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0001B89C File Offset: 0x00019A9C
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("RockSteeleBar"), 18);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
