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
            Background = new GameObject();
            Background.AddModule<TextureModule>().TextureID = "bg";
            Add(Background);

            Sprite = new GameObject();
            Sprite.AddModule<TextureModule>().TextureID = "down_stand";
            Sprite.AddModule<WASDController>();
            Add(Sprite);

            GameObject sprite2 = new GameObject();
            sprite2.AddModule<TextureModule>().TextureID = "down_stand";
            sprite2.WorldPosition.X = 55;
            Sprite.Add(sprite2);
        }
    }
}
