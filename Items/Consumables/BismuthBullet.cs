using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BismuthMod.Items.Consumables
{

	public class BismuthBullet : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bismuth Bullet");
			Tooltip.SetDefault("The bullet burns foes\n5% chance to not consume ammo");
		}

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
			item.rare = 2;
			item.shoot = mod.ProjectileType("BlazingBulletShot");
			item.shootSpeed = 24f;
			item.ammo = AmmoID.Bullet;
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Utils.NextFloat(Main.rand) > 0.05f;
		}

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
