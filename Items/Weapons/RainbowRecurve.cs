using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BismuthMod.Items.Weapons
{

	public class RainbowRecurve : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rainbow Recurve");
			Tooltip.SetDefault("Fires shattering arrows");
		}

		public override void SetDefaults()
		{
			item.damage = 28;
			item.noMelee = true;
			item.ranged = true;
			item.width = 48;
			item.height = 54;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.shoot = ProjectileID.Shuriken;
			item.useAmmo = AmmoID.Arrow;
			item.knockBack = 5;
			item.value = Item.buyPrice(0, 0, 60, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shootSpeed = 13;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(2f, 1f));
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = mod.ProjectileType("BismuthRecurveArrow");
			}
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("BismuthBar"), 12);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
