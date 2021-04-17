using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BismuthMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class BismuthHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Bismuth Helmet");
			Tooltip.SetDefault("6% increased melee damage and critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 0, 60, 0);
			item.rare = 3;
			item.defense = 8;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.06f;
			player.meleeCrit += 6;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("BismuthChestplate") && legs.type == mod.ItemType("BismuthLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			//Surrounds player in a bubble, shields you from attacks below 50 damage  Shield wont be broken if below 5 damage? 10 second cooldown (bubble looks like an actual bubble uwu)
			player.setBonus = "Encases the player in a Bismuth Shield which protects the player\nOnly protects from attacks that are stronger than 5 and weaker than 50";
			player.GetModPlayer<BismuthPlayer>().bismuthMeleeSet = true; // There are reasons why it's not just "bismuthMeleeSet" so I'm just gonna tell ya a small bit. "bismuthMeleeSet" doesn't exist in this file, we gotta add "player.GetModPlayer<BismuthPlayer>()" infront of it so that tModLoader knows in what file it is. This way only works when "bismuthMeleeSet" is in modPlayer A.K.A BismuthPlayer.
			//Now when armor set is equipped, "bismuthMeleeSet" is set to true. It doesn't automatically turn false when you take the set off though, so you gotta make it false in BismuthPlayer inside "ResetEffects".
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("BismuthBar"), 17);
			modRecipe.AddTile(TileID.Anvils); // What you gotta be near to in order to craft.
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
		
		

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = false; // We'll go through these on Discord together, it's just asthetic choices for armor set shadows.
			player.armorEffectDrawShadowSubtle = false;
			player.armorEffectDrawOutlines = false;
			player.armorEffectDrawShadowLokis = true;
			player.armorEffectDrawShadowBasilisk = false;
			player.armorEffectDrawOutlinesForbidden = false;
			player.armorEffectDrawShadowEOCShield = true;
		}
	}
}
