﻿using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x02000089 RID: 137
	public class BlazingBullet : ModItem
	{
		// Token: 0x0600026A RID: 618 RVA: 0x00016353 File Offset: 0x00014553
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blazing bullet");
			Tooltip.SetDefault("The bullet burns foes\n5% chance to not consume ammo");
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00016378 File Offset: 0x00014578
		public override void SetDefaults()
		{
			item.damage = 9;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 2.5f;
			item.value = Item.buyPrice(0, 0, 5, 0);
			item.value = Item.sellPrice(0, 0, 1, 10);
			item.rare = 2;
			item.shoot = base.mod.ProjectileType("BlazingBulletShot");
			item.shootSpeed = 24f;
			item.ammo = AmmoID.Bullet;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00016453 File Offset: 0x00014653
		public override bool ConsumeAmmo(Player player)
		{
			return Utils.NextFloat(Main.rand) > 0.05f;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00016468 File Offset: 0x00014668
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(97, 150);
			modRecipe.AddIngredient(175, 1);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 150);
			modRecipe.AddRecipe();
		}
	}
}
