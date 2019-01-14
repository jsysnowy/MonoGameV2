// System
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Microsoft XNA
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Monogame Extended
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;

namespace Aurora.Core.Modules.TileMaps {
    class TileMap : Base.Module {
        #region Class properties
        /// <summary>
        /// Stores the maps ID string in the loader.
        /// </summary>
        private string _mapID;

        
        /// <summary>
        /// Stores the tiled map object.
        /// </summary>
        private TiledMap _map;

        /// <summary>
        /// Renderer which will render the TiledMap.
        /// </summary>
        private TiledMapRenderer _renderer;
        #endregion

        #region Get/Sets.
        /// <summary>
        /// Set map ID which is rendered.
        /// </summary>
        public string MapID {
            get {
                return _mapID;
            }
            set {
                _mapID = value;
                _map = Loader.MapCache[_mapID];
            }
        }

        #endregion
        
        #region Constructor
        /// <summary>
        /// Create Tiled Map.
        /// </summary>
        public TileMap() {
            _renderer = new TiledMapRenderer(Core.Overseer.Instance.GD);
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Update the Tiled Map.
        /// </summary>
        /// <param name="gT"></param>
        public override void Update(GameTime gT) {
            _renderer.Update(_map, gT);
            base.Update(gT);
        }

        /// <summary>
        /// Draw the TileMap using the current active scenes current active caneras transform.
        /// </summary>
        /// <param name="sB"></param>
        public override void Draw(SpriteBatch sB) {
            _renderer.Draw(_map, Overseer.Instance.SceneManager.ActiveScene.ActiveCamera.Transform );
            base.Draw(sB);
        }
        #endregion
    }
}
