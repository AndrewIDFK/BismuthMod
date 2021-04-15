using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BismuthMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class BismuthLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Bismuth Leggings");
			Tooltip.SetDefault("25% increased movement speed\n4% increased melee damage and critical hit chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 2, 40, 0);
			item.rare = 3;
			item.defense = 13;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 8.25f;
			player.meleeDamage += 0.04f;
			player.meleeCrit += 4;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("BismuthBar"), 16);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
