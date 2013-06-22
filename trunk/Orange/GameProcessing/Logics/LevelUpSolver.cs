using System;
using System.Collections.Generic;
using System.Text;
using Orange.GameProcessing.Entities;
using System.Xml;
using System.IO;
using Orange.GameRender.Scenes;

namespace Orange.GameProcessing.Logics
{
    class LevelUpSolver
    {
        public Map map;
        Queue<string> nameQueue;
        Queue<string> fileQueue;
        public LevelUpSolver()
        {
            nameQueue = new Queue<string>();
            fileQueue = new Queue<string>();
            XmlDocument document = new XmlDocument();
            document.LoadXml(File.ReadAllText("Content/Map/Stage.xml"));
            XmlElement stageTAG = (XmlElement)document.FirstChild;
            XmlElement levelTAG = (XmlElement)stageTAG.FirstChild;
            while (levelTAG != null)
            {
                string name = levelTAG.GetAttribute("name");
                string file = levelTAG.GetAttribute("file");
                nameQueue.Enqueue(name);
                fileQueue.Enqueue(file);
                levelTAG = (XmlElement)levelTAG.NextSibling;
            }
        }
        public void Solve()
        {
            if (fileQueue.Count == 0)
            {
                Global.currentScene = new SceneWin();
                return;
            }
            if (map.mobs.Count == 0)
            {
                if (map.keyPosition.X > 0 && map.keyPosition.Y > 0)
                {
                    foreach (Boomer item in map.boomers)
                    {
                        if (item.GridPosition == map.keyPosition)
                        {
                            map.LoadXml("Content/Map/" + fileQueue.Dequeue());
                            break;
                        }
                    }
                }
                else
                {
                    map.LoadXml("Content/Map/" + fileQueue.Dequeue());
                }
                
            }
            if (map.boomers.Count == 0)
            {
                Global.currentScene = new SceneLose();
                return;
            }
        }
    }
}
