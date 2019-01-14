using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aurora.Core {
    class Overseer {
        #region Singletons
        /// <summary>
        ///  Stores singleton instance of this.
        /// </summary>
        private static Overseer _instance;

        /// <summary>
        /// Instance of random!
        /// </summary>
        public Random rnd;

        /// <summary>
        /// Getter for this singleton.
        /// </summary>
        public static Overseer Instance {
            get {
                if ( _instance == null) {
                    _instance = new Overseer();
                }
                return _instance;
            }
        }
        #endregion

        #region Game properties
        /// <summary>
        /// Stores the graphics device manager.
        /// </summary>
        public GraphicsDeviceManager GDM;

        /// <summary>
        ///  Stores the graphics device.
        /// </summary>
        public GraphicsDevice GD;
        #endregion

        #region Managers
        /// <summary>
        /// Stores the SceneManager.
        /// </summary>
        public Scenes.SceneManager SceneManager;

        /// <summary>
        /// Stores the renderers manager.
        /// </summary>
        public Managers.Renderers Renderers;
        #endregion

        #region Constructor
        /// <summary>
        /// Create new Game instance
        /// </summary>
        private Overseer() {

        }
        #endregion

        #region Public Fuctions
        /// <summary>
        /// Initialises the Overseer.
        /// </summary>
        public void Init() {
            SceneManager = new Scenes.SceneManager();
            Renderers = new Managers.Renderers(GD);
            rnd = new Random();
        }
        #endregion
    }
}
