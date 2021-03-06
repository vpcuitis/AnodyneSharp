﻿using AnodyneSharp.Entities;
using AnodyneSharp.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AnodyneSharp.Registry
{
    public static class InventoryManager
    {
        //Inventory stuff

        public static bool HasAnyBroom
        {
            get
            {
                return HasBroom || HasLenghten || HasWiden || HasTransformer;
            }
        }

        public static bool HasEveryBroom
        {
            get
            {
                return HasBroom && HasLenghten && HasWiden && HasTransformer;
            }
        }

        public static BroomType EquippedBroom
        {
            get
            {
                return _equippedBroom;
            }
            set
            {
                _equippedBroom = value;
                EquippedBroomChanged = true;
            }
        }

        public static int CardCount
        {
            get
            {
                return CardStatus.Count(c => c);
            }
        }

        public static bool UnlockedSecretz
        {
            get
            {
                return SecretStatus.Any(s => s);
            }
        }

        public static bool UnlockedAllSecretz
        {
            get
            {
                return SecretStatus.All(s => s);
            }
        }

        public static bool EquippedBroomChanged = false;

        public static bool HasBroom = false;
        public static bool HasLenghten = false;
        public static bool HasWiden = false;
        public static bool HasTransformer = false;

        public static bool CanJump = false;

        public static bool[] CardStatus;
        public static bool[] SecretStatus;

        private static Dictionary<string, int> _mapKeys;
        private static BroomType _equippedBroom = BroomType.NONE;

        public static void ResetValues()
        {
            DebugLogger.AddInfo("Setting inventory progress to default");

            _mapKeys = new Dictionary<string, int>();

            CardStatus = Enumerable.Repeat(false, 49).ToArray();
            SecretStatus = Enumerable.Repeat(false, 13).ToArray();

            HasBroom = false;
            HasLenghten = false;
            HasWiden = false;
            HasTransformer = false;

            CanJump = false;
        }

        public static int GetCurrentMapKeys()
        {
            return GetMapKeys(GlobalState.CURRENT_MAP_NAME);
        }

        public static int GetMapKeys(string mapName)
        {
            if (!_mapKeys.ContainsKey(mapName))
            {
                return 0;
            }

            return _mapKeys[mapName];
        }

        public static int AddCurrentMapKey()
        {
            return AddMapKey(GlobalState.CURRENT_MAP_NAME, 1);
        }

        public static int RemoveCurrentMapKey()
        {
            return AddMapKey(GlobalState.CURRENT_MAP_NAME, -1);
        }

        public static int AddMapKey(string mapName, int addition)
        {
            GlobalState.RefreshKeyCount = true;

            if (!_mapKeys.ContainsKey(mapName))
            {
                _mapKeys.Add(mapName, addition);
            }
            else
            {
                _mapKeys[mapName] += addition;
            }

            DebugLogger.AddInfo($"Set key count of {mapName} to {_mapKeys[mapName]}");

            return _mapKeys[mapName];
        }
    }
}
