﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGame
{
    public class Background : Sprite
    {
        public Background(Texture2D spriteTexture, int width, int height)
        : base(spriteTexture, width, height)
        {
        }
    }
}
