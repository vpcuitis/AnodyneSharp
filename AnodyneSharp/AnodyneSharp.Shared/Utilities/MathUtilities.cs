﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnodyneSharp.Utilities
{
    public static class MathUtilities
    {
        public static Rectangle ScaleRectangle(Rectangle rect, float scale)
        {
            return CreateRectangle(rect.X * scale, rect.Y * scale, rect.Width * scale, rect.Height * scale);
        }

        public static Rectangle CreateRectangle(float x, float y, float width, float height)
        {
            return new Rectangle((int)x, (int)y, (int)width, (int)height);
        }
    }
}