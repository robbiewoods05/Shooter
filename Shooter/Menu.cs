using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter
{
    public static class Menu 
    {
        static string _selected;

         static Dictionary<string, Texture2D> buttons = new Dictionary<string, Texture2D>();
         static int index = 0;

         static KeyboardState oldState = Keyboard.GetState();

        public static void LoadContent(Texture2D texture, string key)
        {
            if (buttons.Count == 0)
                _selected = key;

            buttons[key] = texture;
        }
              

        public static void HandleInput(ref GameStateManager state)
        {
            KeyboardState newState = Keyboard.GetState();


            if (newState.IsKeyDown(Keys.Down))
            {
                if (!oldState.IsKeyDown(Keys.Down))
                {
                    if (index != buttons.Count - 1)
                        index++;
                    else
                        index = 0;
                }           
            }
            else if (newState.IsKeyDown(Keys.Up))
            {
                if (!oldState.IsKeyDown(Keys.Up))
                {
                    if (index != 0)
                        index--;
                    else
                        index = buttons.Count - 1;
                }
            }
            else if (newState.IsKeyDown(Keys.Enter))
            {
                if (_selected == state.States[1])
                    state.Push(state.States[1]);
                else if (_selected == "play")
                    state.Set(state.States[2]);
            }


            _selected = buttons.Keys.ToList()[index];

            oldState = newState;
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            int x = 0, y = 0;

            float scale;

            spriteBatch.Begin();
            foreach (KeyValuePair<string, Texture2D> text in buttons)
            {
                scale = (_selected == text.Key) ? 1.5f : 1f;
                spriteBatch.Draw(text.Value, new Vector2(x, y), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

                y += 200;
            }
            spriteBatch.End();
        }
    }
}
