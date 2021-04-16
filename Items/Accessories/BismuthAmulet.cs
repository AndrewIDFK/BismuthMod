using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BismuthMod.Items.Accessories
{

	public class BismuthAmulet : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bismuth Amulet");
			Tooltip.SetDefault("'It irradiates spiritual energy' \nIncreases movement speed by 10% \nIncreases life regen by 2");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 16;
			item.value = Item.buyPrice(0, 0, 60, 0);
			item.rare = 3;
			item.accessory = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(null, "BismuthBar", 8);
			modRecipe.AddIngredient(mod.ItemType("Diamond"), 4);
			modRecipe.AddTile(133);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed += 0.10f;
			player.lifeRegen += 2;
		}
	}
}
