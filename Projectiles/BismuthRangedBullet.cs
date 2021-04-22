using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BismuthMod.Projectiles
{
	public class BismuthRangedBullet : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 4;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.hide = true;
		}
		
		public static Vector2 PolarVector(float radius, float theta)
        {
            return new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta)) * radius;
        }
		
		bool initiate = true;
		private float trigCounter = 0;
        private float startDir = 0;
        private float period = 50;
        private float amplitude = 10;
        private float oldI = 0;
        private Projectile partner = null;
		
		public override void AI()
		{
			if (initiate)
            {
                startDir = projectile.velocity.ToRotation();
                if (Main.netMode != 2 && projectile.owner == Main.myPlayer)
                {
                    if (projectile.ai[0] == 0)
                    {
                        projectile.velocity *= .7f;
                        partner = Main.projectile[Projectile.NewProjectile(projectile.Center, projectile.velocity, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, 1, projectile.whoAmI)];
                    }
                    else
                    {
                        partner = Main.projectile[(int)projectile.ai[1]];
                    }
                }
                initiate = false;
            }
            trigCounter += 2 * (float)Math.PI / period;
            float i = amplitude * (float)Math.Sin(trigCounter) * (projectile.ai[0] == 0 ? 1 : -1);
            Vector2 instaVel = PolarVector(i - oldI, startDir + (float)Math.PI / 2);
            projectile.position += instaVel;
            oldI = i;
            projectile.rotation = (projectile.velocity + instaVel).ToRotation() + (float)Math.PI / 2;
		
			for (int num163 = 0; num163 < 5; num163++)
			{
				float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num163;
				float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)num163;
				int num164 = Dust.NewDust(new Vector2(x2, y2), 1, 1, mod.DustType("BRainbowDust"));	
				Main.dust[num164].position.X = x2;
				Main.dust[num164].position.Y = y2;
				Main.dust[num164].velocity *= 0f;
				Main.dust[num164].noGravity = true;
			}
			
			
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, projectile.position);
			for (int i = 0; i < 10; i++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("BRainbowDust"), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
			}
		}
		
	}
}
