using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace BismuthMod.Tiles
{

	public class BismuthOreTile : ModTile
	{

		public override void SetDefaults()
		{
			Main.tileSolid[(int)Type] = true;
			Main.tileMergeDirt[(int)Type] = true;
			Main.tileLighted[(int)Type] = true;
			Main.tileBlockLight[(int)Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			this.drop = mod.ItemType("BismuthOre");
			ModTranslation modTranslation = CreateMapEntryName(null);
			modTranslation.SetDefault("Bismuth Ore");
			AddMapEntry(new Color(250, 225, 74), modTranslation);
			this.minPick = 70;
			this.mineResist = 6;
			this.dustType = 19;
			this.soundType = 21;
			Main.tileSpelunker[(int)Type] = true;
		}

		public override bool CanExplode(int i, int j)
		{
			return false;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.250f;
			g = 0.225f;
			b = 0.074f;
		}
	}
}
