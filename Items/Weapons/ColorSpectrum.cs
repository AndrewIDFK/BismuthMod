using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BismuthMod.Items.Weapons
{

	public class ColorSpectrum : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Color Spectrum");
			Tooltip.SetDefault("Shoots beams of light in coil patterns");
		}

		public override void SetDefaults()
		{
			item.damage = 135;
			item.magic = true;
			item.width = 24;
			item.height = 28;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = Item.buyPrice(0, 13, 45, 0);
			item.rare = 3;
			item.mana = 6;
			item.UseSound = SoundID.Item8;
			item.autoReuse = true;
			//item.shoot = base.mod.ProjectileType("LunarFracturationShot");
			item.shootSpeed = 15;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 8; i++)
			{
				float num = Utils.NextFloat(Main.rand) * 18.849556f;
				Vector2 vector = position + Utils.ToRotationVector2(num) * MathHelper.Lerp(60f, 90f, Utils.NextFloat(Main.rand));
				Vector2 value = Main.MouseWorld - vector;
				value.Normalize();
				Projectile.NewProjectile(vector, value * 15f, type, damage, knockBack, Main.myPlayer, 0f, 0f);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("BismuthBar"), 10);
			modRecipe.AddIngredient(mod.ItemType("BismuthCrystal"), 4);
			modRecipe.AddTile(412);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
