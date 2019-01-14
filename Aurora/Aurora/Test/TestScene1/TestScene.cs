using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Aurora.Core.Scenes;
using Aurora.Core.Objects;
using Aurora.Core.Modules;
using Aurora.Core.Modules.PlayerControllers;
using Aurora.Core.Modules.CollisionBoxes;
using Aurora.Core.Modules.TileMaps;
using Microsoft.Xna.Framework.Input;

namespace Aurora.Test.TestScene1 {
    class TestScene : Scene {
        /// <summary>
        /// Test background image
        /// </summary>
        private GameObject Background;

        /// <summary>
        /// Test sprite.
        /// </summary>
        private GameObject _raptor;

        /// <summary>
        /// Creates this scene.
        /// </summary>
        public TestScene() {
            ActiveCamera.Zoom = 1f;

            ///Temp BG image, switch with TileSprites.
            Background = new GameObject();
            Background.AddModule<TileMap>().MapID = "BattleMap";
            Add(Background);


            // Test sprite for Spritesheets
            _raptor = new Components.Raptor();
            Add(_raptor);



            Random rnd = new Random();

            for ( int i = 0; i < 500; i++) {
                GameObject rndp = new GameObject();
                rndp.WorldPosition.X = (float)rnd.NextDouble() * 2000;
                rndp.WorldPosition.Y = (float)rnd.NextDouble() * 2000;
                SpritesheetTexture tex = rndp.AddModule<SpritesheetTexture>();
                tex.TextureID = "phoenix";
                tex.StartIndex = 0;
                tex.EndIndex = 3;
                tex.Enable();
                //Phoenix.AddModule<GRIDController>();
                rndp.AddModule<CustomRectHitArea>().SetBounds(new Rectangle(0, 0, 12, 12));
                Add(rndp);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gT"></param>
        public override void Update(GameTime gT) {
            base.Update(gT);

            ActiveCamera.Position = _raptor.WorldPosition;
            
        }
    }
}
