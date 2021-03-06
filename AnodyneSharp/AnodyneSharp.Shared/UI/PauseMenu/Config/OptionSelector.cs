﻿using AnodyneSharp.Input;
using AnodyneSharp.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnodyneSharp.UI.PauseMenu.Config
{
    public delegate void ValueChanged(string newValue, int index);
    public abstract class OptionSelector
    {
        public bool Enabled;
        public bool Exit;

        public ValueChanged ValueChangedEvent;

        protected Vector2 position;

        private MenuSelector _leftArrow;
        private MenuSelector _rightArrow;

        public OptionSelector(Vector2 pos, float width)
        {
            position = pos;
            float y = pos.Y + 2;

            _leftArrow = new MenuSelector();
            _rightArrow = new MenuSelector();

            _leftArrow.Position = new Vector2(pos.X, y);
            _rightArrow.Position = new Vector2(pos.X + width, y);

            _leftArrow.Play("enabledLeft");
            _rightArrow.Play("enabledRight");
        }

        public void Update()
        {
            _leftArrow.Update();
            _leftArrow.PostUpdate();
            _rightArrow.Update();
            _rightArrow.PostUpdate();

            if (KeyInput.JustPressedRebindableKey(KeyFunctions.Left))
            {
                LeftPressed();
            }
            else if (KeyInput.JustPressedRebindableKey(KeyFunctions.Right))
            {
                RightPressed();
            }
            else if (KeyInput.JustPressedRebindableKey(KeyFunctions.Accept))
            {
                SetValue();
                Exit = true;
            }
            else if (KeyInput.JustPressedRebindableKey(KeyFunctions.Cancel))
            {
                ResetValue();
                Exit = true;
            }
        }

        public abstract void SetValue();

        public abstract void ResetValue();

        public virtual void DrawUI()
        {
            if (Enabled)
            {
                _leftArrow.Draw();
                _rightArrow.Draw();
            }
        }

        protected abstract void LeftPressed();

        protected abstract void RightPressed();
    }
}
