using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.RockSteele
{
	[AutoloadEquip(EquipType.Body)]
	public class RockSteeleChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("RockSteele Chestplate");
			Tooltip.SetDefault("5% increased melee damage and critical hit chance\nIncreases max life by 25");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 2, 80, 0);
			item.rare = 6;
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
			modRecipe.AddIngredient(mod.ItemType("RockSteeleBar"), 20);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
