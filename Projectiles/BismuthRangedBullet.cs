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
			projectile.timeLeft = 600;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.hide = true;
		}
		
		//Tried to make this public static Vector2 helixVector inside the AI hook, but I needed new variables inside helixVector called radius and theta, which can't be done otherwise from what I know and I only know a tiny bit.
		public static Vector2 helixVector(float radius, float theta) // Hard to explain. We make a Vector2 called helixVector, which we use to calculate helixVelocity in the correct way.
        {
            return new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta)) * radius; // Vector2(Cos(theta), Sin(theta) * radius) only Sin(theta) is multiplied by radius here.
        }
		
		private float arcLength = 50; // Quite self-explanatory
        private float arcSize = 20; // Quite self-explanatory
		
		bool onceDone = true; // This helps you run specific code in the AI hook only once, since the AI hook does stuff once every tick, using this we can make AI do stuff inside the onceDone only once, then we turn onceDone to true so that stuff inside onceDone doesn't happen again to the projectile.
		private float counter = 0; // is a counter.
        private float spawnDirection = 0; // Gets the projectiles direction when it spawns, then we use that make the helix go the right way while also doing it's helix thing.
        private float previousI = 0; // is previous i, can't explain thing.
        private Projectile secondProjectile = null; // We can make a second projectile with it.
		
		//More readable Helix AI
		public override void AI()
		{
			if(onceDone) // All the stuff inside this happens once and then never again because we are turning onceDone to false inside it.
			{
				spawnDirection = projectile.velocity.ToRotation(); // Here we get the  Direction of the projectile and then use it to calculate helixVelocity so it goes the right way.
				if(Main.netMode != 2 && projectile.owner == Main.myPlayer) // Helps with spawning in the right place on the right player during the right mode
				{
					if(projectile.ai[0] == 0) // projectile.AI[0] and others that are similar work like States, ususally used for NPC AI to make them cycle through attacks.
					{
						projectile.velocity *= 0.85f; // We make the helix slower than original velocity, not needed but makes smoother, i guess?
						secondProjectile = Main.projectile[Projectile.NewProjectile(projectile.Center, projectile.velocity, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, 1, projectile.whoAmI)]; // Here we spawn an identical projectile to this one called secondProjectile.
					}
					/*else // The stuff in this /* comment don't seem to be necessary, but just in case I'm gonna leave it here. Ignore all the stuff inside these comments, might delete later.
					{					
						secondProjectile = Main.projectile[(int)projectile.ai[1]];  
					}*/
				}
				onceDone = false; // Turning onceDone to false so that everything inside if(onceDone) doesn't happen again.
				
			}
			counter += 2 * (float)Math.PI / arcLength; // Adding math to Counter every tick, here we change the helixes arc length.
            float i = arcSize * (float)Math.Sin(counter) * (projectile.ai[0] == 0 ? 1 : -1); // Calculating the size of the arcs of the helix
            Vector2 helixVelocity = helixVector(i - previousI, spawnDirection + (float)Math.PI / 2); // Calculating velocity, this is where most of the helix movement comes from.
			/*Vector2 helixVelocity is calculated like this:
				helixVelocity = helixVector(radius, theta);
				"i - previousI" calculates the radius and "spawnDirection + (float)Math.PI / 2" calculated the theta.
				so instead of Vector2(x, y) which is usually the default thing, helixVector is actually helixVector(radius, theta)
				Vectors are weird and explaining is hard cuz I've only used the basic ones.
			*/
            projectile.position += helixVelocity; // Changing projectiles position depending on helixVelocity.
            previousI = i; // Change previousI into i, because? I'm still experimenting with this and a few other lines that feel redundant.
            projectile.rotation = (projectile.velocity + helixVelocity).ToRotation() + (float)Math.PI / 2; // Changing rotation of projectile, also experimenting with this.
			
			
			
			for (int j = 0; j < 10; j++) // This is just a trail dust for the projectile, Chlorophyte bullet uses almost the exact same code for its trail. Everything inside this "for" happens 10 times a tick.
			{
				float x = projectile.position.X - projectile.velocity.X / 10f * (float)j; // Calculating fancy X position stuff
				float y = projectile.position.Y - projectile.velocity.Y / 10f * (float)j; // Calculating fancy Y position stuff
				int dust = Dust.NewDust(new Vector2(x, y), 1, 1, mod.DustType("BRainbowDust"));	// Basic way of spawning dust, but a bit shorter and we use a Vector2 instead of position.X and position.Y
				Main.dust[dust].position.X = x; // Change X position of the dust to x.
				Main.dust[dust].position.Y = y; // Change Y position of the dust to y.
				Main.dust[dust].velocity *= 0f; // Changing dusts velocity to 0, can do = 0; because velocity isn't a normal number.
				//Main.dust[dust].noGravity = true; // Makes the dust ignore gravity, so it doesn't fall down like some dust do, but since BRainbowDust already has no gravity, this is not needed for BrainbowDust.
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
