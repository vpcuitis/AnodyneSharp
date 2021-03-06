﻿using AnodyneSharp.Registry;
using Microsoft.Xna.Framework;
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

        public static int OneRandomOf(params int[] p)
        {
            return p[GlobalState.RNG.Next(p.Length)];
        }

        public static string IntToString(int num)
        {
            switch (num)
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                default:
                    return ":(";
            }
        }
    }
}
