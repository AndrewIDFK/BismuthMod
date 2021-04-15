using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BismuthMod.Items
{

	public class BismuthCrystal : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bismuth Crystal");
			Tooltip.SetDefault("Concentrated form of Bismuth");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.useTime = 15;
			item.useAnimation = 15;
			item.rare = 3;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 1, 45, 0);
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.consumable = true;
			item.maxStack = 99;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(null, "BismuthOre", 10);
			modRecipe.AddTile(133);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
