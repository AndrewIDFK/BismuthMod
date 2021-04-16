using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BismuthMod.Items.Weapons
{

	public class ColorSpectrum : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Color Spectrum");
			Tooltip.SetDefault("Shoots beams of light in coil patterns");
		}

		public override void SetDefaults()
		{
			item.damage = 135;
			item.magic = true;
			item.width = 24;
			item.height = 28;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			//Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = Item.buyPrice(0, 0, 60, 0);
			item.rare = 3;
			item.mana = 6;
			item.UseSound = SoundID.Item8;
			item.autoReuse = true;
			//item.shoot = base.mod.ProjectileType("LunarFracturationShot");
			item.shootSpeed = 15;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("BismuthBar"), 10);
			modRecipe.AddIngredient(mod.ItemType("BismuthCrystal"), 4);
			modRecipe.AddTile(412);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
