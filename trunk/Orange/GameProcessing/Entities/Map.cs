using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using Orange.GameData.Materials;
using Orange.GameProcessing.Logics;
using System.Xml;
using System.IO;
using Orange.GameRender.Scenes;

namespace Orange.GameProcessing.Entities
{
    public class Map
    {
        #region Field
        // graphics
        public Vector2 viewOffset;
        private int moveSpeed;
        public Vector2 size;
        private Sprite background;
        // entities
        public List<Brick> bricks;
        public List<Boomer> boomers;
        public List<Boom> booms;
        public List<Fire> fires;
        public List<Mob> mobs;
        public List<PowerUp> powers;
        // logics
        public bool [,] brickMap;
        public bool[,] boomMap;
        #endregion

        #region Initialize
        public Map(string texture,int width,int height)
        {
            viewOffset = Vector2.Zero;
            moveSpeed = 8;
            size.X = width*42; size.Y = height*42;
            background = new Sprite(texture, Vector2.Zero, 0);
            brickMap = new bool[width,height];
            boomMap = new bool[width, height];
            bricks = new List<Brick>();
            booms = new List<Boom>();
            fires = new List<Fire>();
            boomers = new List<Boomer>();
            mobs = new List<Mob>();
            powers = new List<PowerUp>();
            //LoadXml("Content/123455.xml");
        }
        public void LoadXml(string xml)
        {
            mobs.Clear();
            boomers.Clear();
            booms.Clear();
            bricks.Clear();
            fires.Clear();
            powers.Clear();
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    brickMap[i, j] = false;
                    boomMap[i, j] = false;
                }   
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(File.ReadAllText(xml));
            XmlElement mapTAG;
            mapTAG = (XmlElement)doc.FirstChild.NextSibling;
            XmlElement nodeTAG = (XmlElement)mapTAG.FirstChild;
            while (nodeTAG != null)
            {
                int node_x = int.Parse(nodeTAG.GetAttribute("x"));
                int node_y = int.Parse(nodeTAG.GetAttribute("y"));
                string node_type = nodeTAG.GetAttribute("node_type");
                string file = nodeTAG.GetAttribute("file");
                if (node_type == "MOB")
                {
                    Mob mob = new Mob(new Vector2(node_x, node_y), file);
                    mobs.Add(mob);
                }
                else if (node_type == "BRICK")
                {
                    Brick b = new Brick(new Vector2(node_x, node_y), file);
                    b.Z = node_y + 1;
                    bricks.Add(b);
                    brickMap[node_x, node_y] = true;
                }
                else if (node_type == "PLAYER")
                {
                    Boomer boomer = new Boomer(new Vector2(node_x, node_y), "Boomer/image22.Animation");
                    boomers.Add(boomer);
                }
                nodeTAG = (XmlElement)nodeTAG.NextSibling;
            }
        }
        ~Map()
        {
            background.Dispose();
            for (int i = 0; i < bricks.Count; i++)
            {
                bricks[i].Dispose();
            }
            bricks.Clear();
            for (int i = 0; i < boomers.Count; i++)
            {
                boomers[i].Dispose();
            }
            boomers.Clear();
            for (int i = 0; i < booms.Count; i++)
            {
                booms[i].Dispose();
            }
            booms.Clear();
            for (int i = 0; i < powers.Count; i++)
            {
                powers[i].Dispose();
            }
            powers.Clear();
        }
        #endregion

        #region Scroll
        public void ScrollUP()
        {
            if (viewOffset.Y < moveSpeed)
                return;
            viewOffset.Y -= moveSpeed;
            background.position.Y += moveSpeed * (float)(background.texture.Height - 600) / (size.Y - 600);
            UpdateItemOffset();
        }

        public void ScrollDOWN()
        {
            if (viewOffset.Y+600+moveSpeed > size.Y)
                return;
            viewOffset.Y += moveSpeed;
            background.position.Y -= moveSpeed * (float)(background.texture.Height - 600) / (size.Y - 600);
            UpdateItemOffset();
        }

        public void ScrollLEFT()
        {
            if (viewOffset.X < moveSpeed)
                return;
            viewOffset.X -= moveSpeed;
            background.position.X += moveSpeed * (float)(background.texture.Width - 800) / (size.X - 800);
            UpdateItemOffset();
        }

        public void ScrollRIGHT()
        {
            if (viewOffset.X + 800 + moveSpeed > size.X)
                return;
            viewOffset.X += moveSpeed;
            background.position.X -= moveSpeed * (float)(background.texture.Width - 800) / (size.X - 800);
            UpdateItemOffset();
        }

        public void Center(Vector2 cpoint)
        {
            viewOffset.X = cpoint.X - 400;
            viewOffset.Y = cpoint.Y - 300;
            if (viewOffset.X < 0) viewOffset.X = 0;
            else if (viewOffset.X > background.texture.Width - 800) viewOffset.X = background.texture.Width - 800;
            if (viewOffset.Y < 0) viewOffset.Y = 0;
            else if (viewOffset.Y > background.texture.Height - 600) viewOffset.Y = background.texture.Height - 600;
            UpdateItemOffset();
        }

        public void Focus(Vector2 point)
        {
            Vector2 newOffset = new Vector2(point.X - 300, point.Y - 400);
            if (viewOffset.Y != newOffset.Y)
                if (viewOffset.Y > newOffset.Y) ScrollUP(); else ScrollDOWN();
            if (viewOffset.X != newOffset.X)
                if (viewOffset.X > newOffset.X) ScrollLEFT(); else ScrollRIGHT();
        }

        private void UpdateItemOffset()
        {
            foreach (Brick item in bricks)
            {
                item.UpdateOffset(viewOffset);
            }
            foreach (Boomer item in boomers)
            {
                item.UpdateOffset(viewOffset);
            }
            foreach (Mob item in mobs)
            {
                item.UpdateOffset(viewOffset);
            }
            foreach (Boom item in booms)
            {
                item.UpdateOffset(viewOffset);
            }
            foreach (Fire item in fires)
            {
                item.UpdateOffset(viewOffset);
            }
            foreach (PowerUp item in powers)
            {
                item.UpdateOffset(viewOffset);
            }
        }
        #endregion

        #region Update, Draw, Dispose
        public void Update()
        {
            UpdateObject();
            UpdateItemOffset();
        }

        private void UpdateObject()
        {
            for (int i = 0; i < bricks.Count; )
            {
                bricks[i].Update();
                if (bricks[i].IsDispose())
                {
                    brickMap[(int)bricks[i].gridPosition.X, (int)bricks[i].gridPosition.Y] = false;
                    bricks.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            for (int i = 0; i < boomers.Count; )
            {
                boomers[i].Update();
                if (boomers[i].IsDispose())
                {
                    boomers.RemoveAt(i);
                    
                }
                else
                {
                    i++;
                }
            }
            for (int i = 0; i < booms.Count; )
            {
                booms[i].Update();
                if (booms[i].IsDispose())
                {
                    boomMap[(int)booms[i].gridPosition.X, (int)booms[i].gridPosition.Y] = false;
                    booms.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            for (int i = 0; i < fires.Count; )
            {
                fires[i].Update();
                if (fires[i].IsDispose())
                {
                    fires.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            for (int i = 0; i < mobs.Count; )
            {
                mobs[i].Update();
                if (mobs[i].IsDispose())
                {
                    mobs.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            for (int i = 0; i < powers.Count; )
            {
                powers[i].Update();
                if (powers[i].IsDispose())
                {
                    powers.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            if (boomers.Count == 0) return;
            Focus(boomers[0].mapPosition);
        }

        public void AddBoom(int x, int y, string boom, Boomer owner)
        {
            Boom b = new Boom(new Vector2(x, y), boom);
            b.owner = owner;
            booms.Add(b);
            boomMap[x, y] = true;
        }
        public void AddFire(int x, int y, string name, int direction)
        {
            Fire fire = new Fire(new Vector2(x,y), name, direction);
            fires.Add(fire);
        }

        public void Draw()
        {
            background.Draw();
            foreach (Brick item in bricks)
            {
                item.Draw();
            }
            foreach (Boom item in booms)
            {
                item.Draw();
            }
            foreach (Fire item in fires)
            {
                item.Draw();
            }
            foreach (Boomer item in boomers)
            {
                item.Draw();
            }
            foreach (Mob item in mobs)
            {
                item.Draw();
            }
            foreach (PowerUp item in powers)
            {
                item.Draw();
            }

        }

        public void Dispose()
        {
            background.Dispose();
        }
        #endregion
    }
}