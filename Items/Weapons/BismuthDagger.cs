﻿using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BismuthMod.Items.Weapons
{

	public class BismuthDagger : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bismuth Dagger");
			Tooltip.SetDefault("Use at your own risk... Seriously!");
		}
		
		public override void SetDefaults()
		{
			item.damage = 0;
			item.width = 10;
			item.height = 32;
			item.maxStack = 1;
			item.consumable = true;
			item.useStyle = 1;
			item.rare = 9;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 50;
			item.useTime = 50;
			item.value = Item.buyPrice(0, 2, 50, 0);
			item.value = Item.sellPrice(0, 2, 50, 0);
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shoot = base.mod.ProjectileType("TheNukeExplosion");
			item.shootSpeed = 9f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(167, 60);
			modRecipe.AddIngredient(null, "BismuthBar", 10);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
