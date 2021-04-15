using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.RockSteele
{
	[AutoloadEquip(EquipType.Head)]
	public class RockSteeleHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("RockSteele Helmet");
			Tooltip.SetDefault("You see better in the dark\n8% increased melee damage and critical hit chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 2, 60, 0);
			item.rare = 6;
			item.defense = 20;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.08f;
			player.meleeCrit += 8;
			player.nightVision = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == base.mod.ItemType("RockSteeleChestplate") && legs.type == base.mod.ItemType("RockSteeleLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "You start glowing, increased life regeneration. 10% increased melee damage critical hit chance";
			player.meleeDamage += 0.1f;
			player.lifeRegen += 5;
			player.meleeCrit += 10;
			Lighting.AddLight((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f), 0.465f, 0.905f, 1.065f);
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("RockSteeleBar"), 17);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = false;
			player.armorEffectDrawShadowSubtle = false;
			player.armorEffectDrawOutlines = false;
			player.armorEffectDrawShadowLokis = true;
			player.armorEffectDrawShadowBasilisk = false;
			player.armorEffectDrawOutlinesForbidden = false;
			player.armorEffectDrawShadowEOCShield = true;
		}
	}
}
