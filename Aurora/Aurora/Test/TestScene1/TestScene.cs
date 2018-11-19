using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Aurora.Core.Objects;
using Aurora.Core.Modules;

namespace Aurora.Test.TestScene1 {
    class TestScene {
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

            Sprite = new GameObject();
            Sprite.AddModule<TextureModule>().TextureID = "down_stand";
            Sprite.AddModule<WASDController>();
        }

        /// <summary>
        /// Ths scene updates
        /// </summary>
        /// <param name="gT"></param>
        public void Update( GameTime gT) {
            Sprite.Update(gT);
        }

        /// <summary>
        /// Draws this scene.
        /// </summary>
        /// <param name="gT"></param>
        public void Draw(SpriteBatch sB) {
            // TODO: Remove:
            sB.Begin();

            Background.Draw(sB);
            Sprite.Draw(sB);

            sB.End();
        }
    }
}
