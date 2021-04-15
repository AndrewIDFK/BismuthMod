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
			Tooltip.SetDefault("Used by the Cultists to overtake the Dungeon\n25% increased ranged damage\n20% increased bow Speed\nGreatly increases arrow velocity");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 16;
			item.value = Item.buyPrice(0, 7, 35, 0);
			item.rare = 3;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magicQuiver = true;
			player.archery = true;
			player.rangedDamage += 0.25f;
		}
	}
}
