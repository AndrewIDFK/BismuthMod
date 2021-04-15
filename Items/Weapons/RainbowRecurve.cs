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
			Tooltip.SetDefault("Shoot 2 plasma infused Arrows");
		}

		public override void SetDefaults()
		{
			item.damage = 87;
			item.noMelee = true;
			item.ranged = true;
			item.width = 69;
			item.height = 40;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 5;
			//item.shoot = base.mod.ProjectileType("PlasmaArrowShot");
			item.useAmmo = AmmoID.Arrow;
			item.knockBack = 5;
			item.value = Item.buyPrice(0, 6, 75, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shootSpeed = 18;
		}
		
		/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 2; i++)
			{
				Vector2 vector = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(9f));
				Projectile.NewProjectile(position.X, position.Y, vector.X, vector.Y, base.mod.ProjectileType("PlasmaArrowShot"), damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return false;
		}*/

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("BismuthBar"), 12);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
