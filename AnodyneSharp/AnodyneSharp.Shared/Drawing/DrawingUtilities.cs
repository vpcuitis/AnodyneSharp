﻿using AnodyneSharp.Registry;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnodyneSharp.Drawing
{
    public enum DrawOrder
    {
        BACKGROUND,         //Moving background textures
        MAP_BG,             //Map layer 1
        PLAYER_REFLECTION,  //Reflection of the player
        BROOM_REFLECTION,   //Reflection of broom
        FOOT_OVERLAY,       //Feet stuff like water wrinkles
        MAP_BG2,            //Map layer 2
        UNDER_ENTITIES,     //Things like particles, keys, shadows, blood etc
        ENTITIES,           //Enemies, the player and other npcs
        FG_SPRITES,         //Bullets and other things that have to be drawn over entities
        MAP_FG,              //Foreground layer of the map
        DEC_OVER,           //Screen wide effects
        DARKNESS,           //Darkens the screen
        HEADER,             //Player UI
        UI_OBJECTS,         //Health, keys, mini mini map
        HEALTH_UPGRADE,     //Health cicida. Needs to be drawn on UI so it can fly over the header
        DEATH_FADEIN,       //A fade-in that happens on player death
        DEATH_TEXT,         //Text that appears on player death
        BLACK_OVERLAY       //Black fadeout on map transition and when player continues after death
    }

    public static class DrawingUtilities
    {

        public static float GetDrawingZ(DrawOrder order, float gridy = 0)
        {
            float z = (float)order;
            if(order == DrawOrder.ENTITIES)
            {
                z += gridy / (GameConstants.SCREEN_HEIGHT_IN_PIXELS + 1); //+1 to prevent z-fighting with next layer
            }
            return z/(float)DrawOrder.BLACK_OVERLAY;
        }
    }
}