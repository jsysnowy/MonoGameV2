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
using Aurora.Core.Modules.CollisionBoxes;
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
        private GameObject Sprite;

        /// <summary>
        /// Creates this scene.
        /// </summary>
        public TestScene() {
            ActiveCamera.Zoom = 3;

            Background = new GameObject();
            Background.AddModule<TextureModule>().TextureID = "bg";
            Add(Background);

            Sprite = new GameObject();
            AnimatedTextureModule anim = Sprite.AddModule<AnimatedTextureModule>();
            anim.Prefix = "down_walk";
            anim.numFrames = 2;
            anim.Playing = true;
            anim.FPS = 6;


            Sprite.AddModule<WASDController>();
            Sprite.AddModule<TextureHitArea>();
            Add(Sprite);

            GameObject sprite2 = new GameObject();
            sprite2.AddModule<TextureModule>().TextureID = "down_stand";
            sprite2.WorldPosition.X = 55;
            Sprite.Add(sprite2);
        }

        public override void Update(GameTime gT) {
            base.Update(gT);

            ActiveCamera.Position = Sprite.WorldPosition;

            AnimatedTextureModule anim = Sprite.GetModule<AnimatedTextureModule>();
            bool pressed = false;

            KeyboardState kbs = Keyboard.GetState();
            if ( kbs.IsKeyDown(Keys.W)) {
                anim.Prefix = "up_walk";
                pressed = true;
            }
            if (kbs.IsKeyDown(Keys.A)) {
                anim.Prefix = "left_walk";
                pressed = true;
            }
            if (kbs.IsKeyDown(Keys.S)) {
                anim.Prefix = "down_walk";
                pressed = true;
            }
            if (kbs.IsKeyDown(Keys.D)) {
                anim.Prefix = "right_walk";
                pressed = true;
            }

            if ( !pressed) {
                anim.Playing = false;
                anim.TextureID = "down_stand";
            } else {
                anim.Playing = true;
            }
        }
    }
}
