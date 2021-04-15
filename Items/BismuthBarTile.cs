using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace BismuthMod.Items
{

	public class BismuthBarTile : ModTile
	{

		public override void SetDefaults()
		{
			Main.tileSolid[(int)Type] = true;
			Main.tileFrameImportant[(int)Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			this.drop = mod.ItemType("BismuthBar");
			this.minPick = 70;
			AddMapEntry(new Color(250, 255, 74));
		}
	}
}
