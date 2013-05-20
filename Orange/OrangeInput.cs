using Microsoft.Xna.Framework.Input;

namespace Orange
{
    public class OrangeInput
    {
        static KeyboardState keyStateCurrent, keyStatePrevious;
        static MouseState mouseStateCurrent, mouseStatePrevious;
        
        public static void Initialize()
        {
            keyStateCurrent = Keyboard.GetState();
            keyStatePrevious = Keyboard.GetState();
            mouseStateCurrent = Mouse.GetState();
            mouseStatePrevious = Mouse.GetState();
        }
        public static bool press(Keys key)
        {
            keyStateCurrent = Keyboard.GetState();
            return keyStateCurrent.IsKeyDown(key);
        }
        public static bool mousePress(int mcode)
        {
            mouseStateCurrent = Mouse.GetState();
            if (mcode == 0)
                return (mouseStateCurrent.LeftButton == ButtonState.Pressed);
            else if (mcode == 1)
                return (mouseStateCurrent.RightButton == ButtonState.Pressed);
            else if (mcode == 2)
                return (mouseStateCurrent.MiddleButton == ButtonState.Pressed);
            else return false;
        }
        public static bool trigger(Keys key)
        {
            keyStateCurrent = Keyboard.GetState();
            return (keyStateCurrent.IsKeyDown(key) && !keyStatePrevious.IsKeyDown(key));
        }
        public static void Update()
        {
            keyStatePrevious = Keyboard.GetState();
            mouseStatePrevious = Mouse.GetState();
        }
        public static bool mouseTrigger(int mcode)
        {
            mouseStateCurrent = Mouse.GetState();
            bool result;
            if (mcode == 0)
                result = (mouseStateCurrent.LeftButton == ButtonState.Pressed && mouseStatePrevious.LeftButton == ButtonState.Released);
            else if (mcode == 1)
                result = (mouseStateCurrent.RightButton == ButtonState.Pressed && mouseStatePrevious.RightButton == ButtonState.Released);
            else if (mcode == 2)
                result = (mouseStateCurrent.MiddleButton == ButtonState.Pressed && mouseStatePrevious.MiddleButton == ButtonState.Released);
            else
                result = false;
            return result;
        }
    }
}
