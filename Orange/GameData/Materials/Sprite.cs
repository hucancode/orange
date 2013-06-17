using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace Orange.GameData.Materials
{
    public class Sprite
    {
        #region Field
        protected SpriteEffects effect;
        protected Rectangle rctImage;
        protected bool _mirror;
        protected string _image;
        protected float _depth;
        protected SpriteBatch spriteBatch;
        public float angle;
        public Vector2 zoom;
        public Vector2 position;
        public Vector2 original;
        public Texture2D texture;
        #endregion

        #region Properties
        public int Z
        {
            get { return (int)(_depth * 1000); }
            set { _depth = (float)value / 1000; }
        }
        public string image
        {
            get { return _image; }
            set
            {
                if (value != _image)
                {
                    texture.Dispose();
                    texture = Global.Content.Load<Texture2D>(value);
                    _image = value;
                }
            }
        }
        public bool mirror
        {
            get { return _mirror; }
            set
            {
                if (value != _mirror)
                {
                    if (value)
                        effect = SpriteEffects.FlipHorizontally;
                    else
                        effect = SpriteEffects.None;
                    _mirror = value;
                }
            }
        }
        #endregion

        #region Initialize
        public Sprite(string tex, Vector2 pos, int z)
        {
            texture = Global.Content.Load<Texture2D>(tex);
            position = pos;
            _depth = (float)z/1000;
            original = Vector2.Zero;
            zoom = Vector2.One;
            angle = 0f;
            _mirror = false;
            effect = SpriteEffects.None;
            rctImage = new Rectangle(0, 0, texture.Width, texture.Height);
            spriteBatch = new SpriteBatch(Global.graphicsDevice);
        }
        #endregion

        #region Draw, Dispose
        public virtual void Draw()
        {
            Global.spriteBatch.Draw(texture, position, rctImage, Color.Aqua, angle, original, zoom, effect, _depth);
        }
        public void Dispose()
        {
            //texture.Dispose();
            texture = null;
        }
        #endregion
    }

    public class TextSprite
    {
        #region Field
        public Color color;
        public string text;
        private SpriteFont font;
        private string fontName;
        public Vector2 position;
        #endregion
        
        #region Properties
        public string Font
        {
            set {
                if (value != fontName)
                {
                    fontName = value;
                    font = Global.Content.Load<SpriteFont>("Font/" + value);
                }
            }
        }
        #endregion

        #region Initialize
        public TextSprite()
        {
            position = Vector2.Zero;
            color = Color.Black;
            text = "";
            //fontName = "Tahoma15";
            font = Global.defaultFont;
        }
        public TextSprite(float x,float y,Color color,string text,string font)
        {
            position = new Vector2(x, y);
            this.color = color;
            this.text = text;
            fontName = font;
            this.font = Global.Content.Load<SpriteFont>("Font/"+font);
        }
        #endregion

        #region Draw, Dispose
        public void Draw()
        {
            Global.spriteBatch.DrawString(font, text, position, color);
        }
        #endregion
    }

    public class SimpleSprite
    { 
        #region Field
        private Rectangle rctImage; 
        private float _depth;
        private string _image;
        public Vector2 position;
        public Texture2D texture;
        #endregion

        #region Properties
        public int Z
        {
            get { return (int)(_depth * 1000); }
            set { _depth = (float)value / 1000; }
        }
        public string image
        {
            get { return _image; }
            set
            {
                if (value != _image)
                {
                    texture.Dispose();
                    texture = Global.Content.Load<Texture2D>(value);
                    _image = value;
                }
            }
        }
        #endregion

        #region Initialize
        public SimpleSprite(string tex, Vector2 pos, int z)
        {
            texture = Global.Content.Load<Texture2D>(tex);
            position = pos;
            _depth = 1-z/1000;
            rctImage = new Rectangle(0, 0, texture.Width, texture.Height);
        }
        #endregion

        #region Draw, Dispose
        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, rctImage, Color.Aqua, 0f, position, 1f, SpriteEffects.None, _depth);

        }
        public void Dispose()
        {
            //texture.Dispose();
            texture = null;
        }
        #endregion
    }

    public class Animation : Sprite
    {
        #region Field
        public int delay;
        public bool isLoop, isStop;
        public int frameCountX, frameCountY, 
            frameCurrent, frameStart, frameStop, 
            frameStartOriginal, frameStopOriginal;
        private bool switching;
        private int TimeCount;
        #endregion

        #region Properties
        public int Width
        {
            get { return rctImage.Width; }
        }
        public int Height
        {
            get { return rctImage.Height; }
        }
        #endregion

        #region Initialize
        public Animation(string tex, Vector2 pos, int z, int frameX) : base(tex, pos, z)
        {
            frameCurrent = 0;
            rctImage.Width = texture.Width / frameX - 2;
            rctImage.Height = texture.Height - 2;
            frameCountX = frameX;
            frameCountY = 1;
            delay = 50;
            isLoop = true;
            frameStart = 0;
            frameStop = frameCountX * frameCountY;
            switching = false;
        }
        public Animation(string tex, Vector2 pos, int z, int frameX,int frameY)
            : base(tex, pos, z)
        {
            frameCurrent = 0;
            rctImage.Width = texture.Width / frameX - 2;
            rctImage.Height = texture.Height / frameY - 2;
            frameCountX = frameX;
            frameCountY = frameY;
            delay = 50;
            isLoop = true;
            frameStart = 0;
            frameStop = frameCountX*frameCountY;
            switching = false;
        }
        #endregion

        #region Animation control
        public void Stop()
        {
            isStop = true;
            frameCurrent = 0;
            rctImage.X = frameCurrent * rctImage.Width;
            TimeCount = 0;
        }
        public void Pause()
        {
            isStop = true;
        }
        public void Play()
        {
            isStop = false;
        }
        public void PlayAnimation(int start, int stop)
        {
            if (start == frameStart && stop == frameStop)
                return;
            frameStart = start;
            frameStop = stop;
            frameCurrent = frameStart;
        }
        public void SwitchAnimation(int start, int stop)
        {
            if (switching)
                return;
            switching = true;
            frameStartOriginal = frameStart;
            frameStopOriginal = frameStop;
            frameStart = start;
            frameStop = stop;
            frameCurrent = frameStart;
        }
        #endregion

        #region Update,Draw,Dispose
        public void Update()
        {
            if (frameStart == frameStop)
                return;
            if (!isStop)
            {
                TimeCount += (int)Global.gameTime.ElapsedGameTime.TotalMilliseconds;
                if (TimeCount >= delay)
                {
                    TimeCount = 0;
                    frameCurrent++;
                    if (frameCurrent == frameStop)
                    {
                        if (switching)
                        {
                            frameStart = frameStartOriginal;
                            frameCurrent = frameStart;
                            frameStop = frameStopOriginal;
                            switching = false;
                        }
                        else
                        {
                            if (isLoop)
                                frameCurrent = frameStart;
                            else
                                isStop = true;
                        }
                    }
                    rctImage.Y = (frameCurrent / frameCountX) * (rctImage.Height + 2) + 1;
                    rctImage.X = frameCurrent % frameCountX * (rctImage.Width + 2) + 1;
                }
            }
        }
        public override void Draw()
        {
            Global.spriteBatch.Draw(texture, position, rctImage, Color.Aqua, angle, original, zoom, effect, _depth);
        }
        #endregion
    }

}