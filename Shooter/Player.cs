using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    public class Player
    {
        public int Score { get { return score; } }

        public int Health {  get { return health; } }

        private int x, y, speed, score, health;
        private bool isAlive, canShoot;
        private double canShootTimer, canShootTimerMax;

        public Texture2D PlayerSprite { get; set; }

        public SoundEffectInstance FireSound;

        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;

            isAlive = true;
            canShoot = true;

            health = 200;
            score = 0;
            speed = 500;
        }

        private void Move(string direction, GameTime dt)
        {
            if (direction == "up")
                y -= (speed * dt.ElapsedGameTime.Milliseconds) / 1000;
            else if (direction == "down")
                y += (speed * dt.ElapsedGameTime.Milliseconds) / 1000;
            else if (direction == "left")
                x -= (speed * dt.ElapsedGameTime.Milliseconds) / 1000;
            else if (direction == "right")
                x += (speed * dt.ElapsedGameTime.Milliseconds) / 1000; 
        }

        private void Fire()
        {
            //TODO: Add firing code
            if (FireSound.State == SoundState.Stopped)
                FireSound.Play();
        }

        public void Die()
        {
            isAlive = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //TODO: Add drawing code

            spriteBatch.Begin();
            spriteBatch.Draw(PlayerSprite, new Vector2(x, y), Color.White);
            spriteBatch.End();
        }
        
        public void HandleInput(KeyboardState state, GameTime gameTime)
        {
            if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W))
                Move("up", gameTime);
            else if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S))
                Move("down", gameTime);
            else if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A))
                Move("left", gameTime);
            else if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
               Move("right", gameTime);
            else if (state.IsKeyDown(Keys.Space))
                Fire();
        }
    }
}
