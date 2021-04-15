using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BismuthMod.Items
{

	public class BismuthOre : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bismuth Ore");
			Tooltip.SetDefault("Sparkling with color");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.useTime = 10;
			item.useAnimation = 15;
			item.rare = 3;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 0, 40, 0);
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = mod.TileType("BismuthOreTile");
			item.maxStack = 999;
			item.UseSound = SoundID.Item1;
		}
	}
}
