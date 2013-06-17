using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

//using Mango.GameProcessing.Logics;
using Orange.GameProcessing.Entities;
using Orange.GameData.Materials;
using Orange.GameProcessing.Logics;

namespace Orange.GameRender.Scenes
{
    public class SceneMap : Scene
    {
        private Map map;
        private BoomerSolver boomerSolver;
        private BoomSolver boomSolver;
        private MovingSolver movingSolver;
        private FireSolver fireSolver;
        private MobBoomerSolver mobBoomerSolver;
        private BoomerPowerSolver boomerPowerSolver;
        private LevelUpSolver levelUpSolver;
        private MobAISolver aiSolver;
        public SceneMap()
        {
            map = new Map("Background/back1Sprite", 13, 11);
            map.viewOffset.X = -65;
            map.viewOffset.Y = -120;

            boomerSolver = new BoomerSolver();
            boomerSolver.map = map;
            boomSolver = new BoomSolver();
            boomSolver.map = map;
            movingSolver = new MovingSolver();
            movingSolver.map = map;
            fireSolver = new FireSolver();
            fireSolver.map = map;
            mobBoomerSolver = new MobBoomerSolver();
            mobBoomerSolver.map = map;
            boomerPowerSolver = new BoomerPowerSolver();
            boomerPowerSolver.map = map;
            levelUpSolver = new LevelUpSolver();
            levelUpSolver.map = map;
            aiSolver = new MobAISolver();
            aiSolver.map = map;
        }
        public override void UnloadContent()
        {
        }
        public override void Update()
        {
            boomerSolver.Solve();
            movingSolver.Solve();
            fireSolver.Solve();
            boomSolver.Solve();
            mobBoomerSolver.Solve();
            boomerPowerSolver.Solve();
            levelUpSolver.Solve();
            aiSolver.Solve();
            map.Update();
        }
        public override void Draw()
        {
            map.Draw();
        }
    }
}
