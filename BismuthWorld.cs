using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using BismuthMod.Tiles;
using System.Linq;

namespace BismuthMod
{
	public class BismuthWorld : ModWorld
	{
		private const int saveVersion = 0;

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int num = tasks.FindIndex((GenPass genpass) => genpass.Name.Equals("Final Cleanup"));
			if (num != -1)
			{
				tasks.Insert(num + 1, new PassLegacy("Generating The Evil", new WorldGenLegacyMethod(BismuthOreSpawning)));
			}
		}

		private void BismuthOreSpawning(GenerationProgress progress)
		{
			progress.Message = "Generating the Evil";
			for (int i = 0; i < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.000023); i++)
			{ 
				int num = WorldGen.genRand.Next(0, Main.maxTilesX);
				int num2 = WorldGen.genRand.Next((int)WorldGen.rockLayerLow + 450, Main.maxTilesY);
				Tile tileSafely = Framing.GetTileSafely(num, num2);
				if (tileSafely.active() && tileSafely.type == 1)
				{
					WorldGen.TileRunner(num, num2, (double)WorldGen.genRand.Next(5, 7), WorldGen.genRand.Next(6, 8), mod.TileType("BismuthOreTile"), true, 0f, 0f, false, true);
				}
			}
		}
	}
}
