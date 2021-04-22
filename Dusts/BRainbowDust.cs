using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BismuthMod.Dusts
{
	public class BRainbowDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.noLight = true;
		}

		public override bool Update(Dust dust)
		{
			dust.rotation += dust.velocity.X * 0.05f;
			dust.position += dust.velocity;
			dust.scale -= 0.075f;
			float num = 0.003f;
			Lighting.AddLight(dust.position, Main.DiscoR * num, Main.DiscoG * num, Main.DiscoB * num);
			if (dust.scale < 0.30f)
			{
				dust.active = false;
			}
			return false;
		}
		
		public override Color? GetAlpha(Dust dust, Color lightColor)
		{

			return Main.DiscoColor * 0.95f;
		}
	}
}
