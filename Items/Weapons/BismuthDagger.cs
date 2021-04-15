using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	// Token: 0x0200003E RID: 62
	public class TheNuke : ModItem
	{
		// Token: 0x060000FC RID: 252 RVA: 0x000075CE File Offset: 0x000057CE
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Nuke");
			Tooltip.SetDefault("Use at your own risk... Seriously!");
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000075F0 File Offset: 0x000057F0
		public override void SetDefaults()
		{
			item.damage = 0;
			item.width = 10;
			item.height = 32;
			item.maxStack = 1;
			item.consumable = true;
			item.useStyle = 1;
			item.rare = 9;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 50;
			item.useTime = 50;
			item.value = Item.buyPrice(0, 2, 50, 0);
			item.value = Item.sellPrice(0, 2, 50, 0);
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shoot = base.mod.ProjectileType("TheNukeExplosion");
			item.shootSpeed = 9f;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x000076EC File Offset: 0x000058EC
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(167, 60);
			modRecipe.AddIngredient(null, "VyssoniumBar", 10);
			modRecipe.AddIngredient(null, "ShadoniumBar", 10);
			modRecipe.AddIngredient(null, "RockSteeleBar", 10);
			modRecipe.AddIngredient(null, "ThaniteBar", 10);
			modRecipe.AddIngredient(null, "StroidBar", 10);
			modRecipe.AddIngredient(null, "PlasmiteBar", 10);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
