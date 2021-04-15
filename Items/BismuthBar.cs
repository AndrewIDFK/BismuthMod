using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Bars
{
	// Token: 0x02000011 RID: 17
	public class PlasmiteBar : ModItem
	{
		// Token: 0x06000061 RID: 97 RVA: 0x000049D0 File Offset: 0x00002BD0
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plasmite Bar");
			Tooltip.SetDefault("Pure heat in solid form\nThis bar and items made wioth this bar are not available for now, we are working on re-making Plasmite stuff entirely");
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000049F4 File Offset: 0x00002BF4
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.useTime = 15;
			item.useAnimation = 15;
			item.rare = 7;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 1, 45, 0);
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = base.mod.TileType("PlasmiteBarTile");
			item.maxStack = 99;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00004AC8 File Offset: 0x00002CC8
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(null, "PlasmiteOre", 5);
			modRecipe.AddTile(133);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
