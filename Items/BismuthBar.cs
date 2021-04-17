using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BismuthMod.Items
{

	public class BismuthBar : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bismuth Bar");
			Tooltip.SetDefault("'Vibrant and sturdy'");
		}


		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.useTime = 15;
			item.useAnimation = 15;
			item.rare = 3;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 0, 35, 0);
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = mod.TileType("BismuthBarTile");
			item.maxStack = 99;
		}


		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(null, "BismuthOre", 4);
			modRecipe.AddTile(TileID.Furnaces);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
