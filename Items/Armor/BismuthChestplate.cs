using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BismuthMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class BismuthChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Bismuth Chesplate");
			Tooltip.SetDefault("5% increased melee damage and critical hit chance\nIncreases max life by 25");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 2, 80, 0);
			item.rare = 3;
			item.defense = 18;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.05f;
			player.meleeCrit += 5;
			player.statLifeMax2 += 25;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("BismuthBar"), 20);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
