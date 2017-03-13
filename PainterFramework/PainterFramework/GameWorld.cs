using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PainterFramework
{
    class GameWorld : GameObjectList
    {
        private SpriteGameObject backround = null;

        public GameWorld()
        {
            backround = new SpriteGameObject("spr_background");
            this.Add(backround);
        }

        
    }
}
