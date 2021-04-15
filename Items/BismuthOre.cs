using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	// Token: 0x02000037 RID: 55
	public class PlasmiteOre : ModItem
	{
		// Token: 0x060000E2 RID: 226 RVA: 0x00006D86 File Offset: 0x00004F86
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plasmite Ore");
			Tooltip.SetDefault("The heat is melting your insides");
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00006DA8 File Offset: 0x00004FA8
		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.useTime = 10;
			item.useAnimation = 15;
			item.rare = 8;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 0, 40, 0);
			item.value = Item.sellPrice(0, 0, 40, 0);
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = base.mod.TileType("PlasmiteTile");
			item.maxStack = 999;
			item.UseSound = SoundID.Item1;
		}
	}
}
