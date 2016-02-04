using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter
{
    public class GameStateManager : StateManager
    {
        List<string> states = new List<string> { "menu", "options", "game" };

        public List<string> States {  get { return states; } }

        public GameStateManager(string state):base(state)
        {
           
        }
    }
}
