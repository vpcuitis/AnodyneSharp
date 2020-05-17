﻿using AnodyneSharp.Entities.Gadget.Treasures;
using AnodyneSharp.Input;
using AnodyneSharp.Registry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnodyneSharp.Entities.Gadget
{
    [NamedEntity("Treasure"), Collision(typeof(Player))]
    public class TreasureChest : Entity
    {
        private enum TreasureType
        {
            NONE = -1,
            BROOM,
            KEY,
            GROWTH,
            JUMP,
            WIDE,
            LONG,
            SWAP,
            SECRET
        }

        EntityPreset _preset;
        Treasure _treasure;
        TreasureType _treasureType;

        public bool opened;

        public TreasureChest(EntityPreset preset)
            : base(preset.Position, "treasureboxes", 16, 16, Drawing.DrawOrder.ENTITIES)
        {
            int frame = 0;

            _preset = preset;
            immovable = true;

            if (GlobalState.CURRENT_MAP_NAME == "TRAIN")
            {
                frame = 4;
            }

            if (preset.Frame == -1)
            {
                frame++;
            }
            else
            {
                SetTreasure();
            }

            SetFrame(frame);
        }

        public override void Update()
        {
            base.Update();

            if (!opened && touching == Touching.DOWN && KeyInput.CanPressKey(Keys.V))
            {
                opened = true;
                _treasure.GetTreasure();

                SetFrame(_curFrame + 1);
                _preset.Frame = -1;
            }

            if (opened)
            {
                _treasure.Update();
            }
        }

        public override void Draw()
        {
            base.Draw();

            if (opened)
            {
                _treasure.Draw();
            }
        }

        public override void Collided(Entity other)
        {
            Separate(this, other);
        }

        private void SetTreasureType()
        {
            _treasureType = TreasureType.NONE;

            switch (_preset.Frame)
            {
                case 0:
                case 4:
                case 5:
                case 6:
                    _treasureType = TreasureType.BROOM;
                    break;
                case 1:
                    _treasureType = TreasureType.KEY;
                    break;
                default:
                    if (_preset.Frame >= 8 && _preset.Frame <= 20)
                    {
                        _treasureType = TreasureType.SECRET;
                    }
                    break;

            }
        }

        private void SetTreasure()
        {
            SetTreasureType();

            switch (_treasureType)
            {
                //case TreasureType.BROOM:
                //    break;
                case TreasureType.KEY:
                    _treasure = new KeyTreasure(Position);
                    break;
                //case TreasureType.GROWTH:
                //    break;
                //case TreasureType.JUMP:
                //    break;
                //case TreasureType.WIDE:
                //    break;
                //case TreasureType.LONG:
                //    break;
                //case TreasureType.SWAP:
                //    break;
                case TreasureType.SECRET:
                    _treasure = new Treasure("secret_trophies", Position, _preset.Frame -7, _preset.Frame == 10 ? 9 : -1);
                    break;
                default:
                    _treasure = new Treasure("PixieCatSupreme", Position, 0, -2);
                    break;
            }
        }
    }
}