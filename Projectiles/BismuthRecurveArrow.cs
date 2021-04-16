using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BismuthMod.Projectiles
{
	public class BismuthRecurveArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blindspot");
		}
		
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			projectile.width = 6;
			projectile.height = 16;
			projectile.penetrate = 1;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			float distance = Math.Max(target.width, target.height) / 1.5f;
			int type = mod.ProjectileType("BismuthRecurveOrbit");
			int random = Main.rand.Next(-8, 8);
			Projectile.NewProjectile(target.Center.X + distance + 20 - random, target.Center.Y - distance - 20 - random, 0, 0, type, damage / 4, knockback / 2, Main.myPlayer, 0f, 0f); // top right

			Projectile.NewProjectile(target.Center.X + distance + 20 - random, target.Center.Y + distance + 20 + random, 0, 0, type, damage / 4, knockback / 2, Main.myPlayer, 0f, 0f); // bottom right

			Projectile.NewProjectile(target.Center.X - distance - 10 + random, target.Center.Y + distance + 20 + random, 0, 0, type, damage / 4, knockback / 2, Main.myPlayer, 0f, 0f); // bottom left

			Projectile.NewProjectile(target.Center.X - distance - 10 + random, target.Center.Y - distance - 20 - random, 0, 0, type, damage / 4, knockback / 2, Main.myPlayer, 0f, 0f); // top left
		}


		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
			for (int i = 0; i < 4; i++)
			{
				int dust1 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 228, projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 0, default(Color), 1f);
				Main.dust[dust1].scale = 1.05f;
			}
		}
	}
}
