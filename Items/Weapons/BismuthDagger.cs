using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BismuthMod.Items.Weapons
{

	public class BismuthDagger : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bismuth Dagger");
			Tooltip.SetDefault("'A dagger able to pierce through the colors'");
		}
		
		public override void SetDefaults()
		{
			item.damage = 22;
			item.width = 10;
			item.height = 32;
			item.maxStack = 999;
			item.consumable = true; //When used, consumes 1 of this item, used for potions, most throwing weapons and other stuff that is consumed.
			item.useStyle = 1;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 18;
			item.useTime = 18;
			item.value = Item.buyPrice(0, 0, 5, 0);
			item.noUseGraphic = true; // Makes it invisible when you are using it. Yoyos, thrown weapons and others use this.
			item.noMelee = true; // Makes the item sprite not do any damage when it touches an enemy.
			item.shoot = mod.ProjectileType("BismuthDaggerProjectile");
			item.shootSpeed = 14.5f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(null, "BismuthBar", 1);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
