using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aurora.Core.Scenes {
    /// <summary>
    /// Manages all the scenes in the game.  You can switch between them and stuff.
    /// </summary>
    class SceneManager {
        #region Properties
        /// <summary>
        /// Stores the scenes with keys.
        /// </summary>
        private Dictionary<string, Scene> Scenes;

        /// <summary>
        /// Stores the currently active scene.
        /// </summary>
        public Scene ActiveScene;
        #endregion

        #region Constructors
        /// <summary>
        /// Create the SceneManager.
        /// </summary>
        public SceneManager() {
            Scenes = new Dictionary<string, Scene>();
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Add a Scene to the SceneManager.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="scene"></param>
        public void AddScene(string key, Scene scene, bool setActive) {
            Scenes[key] = scene;

            if ( setActive) {
                ActivateScene(key);
            }
        }

        /// <summary>
        /// Activate a scene.
        /// </summary>
        /// <param name="key"></param>
        public void ActivateScene( string key) {
            ActiveScene = Scenes[key];
        }

        /// <summary>
        /// Updates teh active scene.
        /// </summary>
        /// <param name="gT"></param>
        public void Update(GameTime gT) {
            ActiveScene.Update(gT);
        }

        /// <summary>
        /// Draws teh active scene.
        /// </summary>
        /// <param name="sB"></param>
        public void Draw(SpriteBatch sB) {
            ActiveScene.Draw(sB);
        }
        #endregion
    }
}
