using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Microsoft XNA
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

// Monogame.Extended
using MonoGame.Extended.Tiled;

namespace Aurora.Core {
    class Loader {
        /// <summary>
        /// Stores all textures.
        /// </summary>
        public static Dictionary<string, Texture2D> TextureCache = new Dictionary<string, Texture2D>();
        
        /// <summary>
        /// Stores all textures.
        /// </summary>
        public static Dictionary<string, TiledMap> MapCache = new Dictionary<string, TiledMap>();

        /// <summary>
        /// Loads textures.
        /// </summary>
        /// <param name="textures"></param>
        public static void LoadTextures( ContentManager content, string[] textures ) {
            // Loop over and load all textures:
            foreach ( string tex in textures) {
                if ( TextureCache.Keys.Contains(tex)  ) {
                    // TODO: exception
                } else {
                    TextureCache.Add(tex, content.Load<Texture2D>(tex));
                }
            }
        }
        
        /// <summary>
        /// Loads textures.
        /// </summary>
        /// <param name="textures"></param>
        public static void LoadMaps( ContentManager content, string[] maps ) {
            // Loop over and load all textures:
            foreach ( string map in maps) {
                if (MapCache.Keys.Contains(map)  ) {
                    // TODO: exception
                } else {
                    MapCache.Add(map, content.Load<TiledMap>(map));
                }
            }
        }
    }
}
