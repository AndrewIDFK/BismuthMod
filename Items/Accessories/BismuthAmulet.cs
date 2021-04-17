using System;
using Terraria;
using Terraria.ID;
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
			modRecipe.AddIngredient(null, "BismuthBar", 8); // the other way to add a modded ingredient is modRecipe.AddIngredient(mod.ItemType("BismuthBar"), 8);. There is also a third way and a fourth way, but those are dates versions eventhough some people still use them.
			modRecipe.AddIngredient(ItemID.Diamond, 4);
			modRecipe.AddTile(TileID.Anvils); //Need to be near an Anvil to craft it.
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
