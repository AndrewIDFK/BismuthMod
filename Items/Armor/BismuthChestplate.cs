using System;
using Terraria;
using Terraria.ID;
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
			DisplayName.SetDefault("Bismuth Chestplate");
			Tooltip.SetDefault("4% increased critical strike chance \nSlightly increased life regen");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 0, 60, 0);
			item.rare = 3;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			player.lifeRegen += 1;
			player.rangedCrit += 4;
			player.meleeCrit += 4;
			player.magicCrit += 4;
			player.thrownCrit += 4;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("BismuthBar"), 20);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
