using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Src.Engine.UI
{
    internal class ButtonFunctions
    {
        public void Play(object sender, EventArgs e)
        {

        }

        public void Quit(object sender, EventArgs e)
        {
            Game1.ExitGame = true;
        }
    }
}
