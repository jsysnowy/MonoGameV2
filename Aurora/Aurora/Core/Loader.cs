using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Aurora.Core {
    class Loader {
        /// <summary>
        /// Stores all textures.
        /// </summary>
        public static Dictionary<string, Texture2D> Cache = new Dictionary<string, Texture2D>();

        /// <summary>
        /// Loads textures.
        /// </summary>
        /// <param name="textures"></param>
        public static void Load( ContentManager content, string[] textures ) {
            // Loop over and load all textures:
            foreach ( string tex in textures) {
                if ( Cache.Keys.Contains("tex")  ) {
                    // TODO: exception
                } else {
                    Cache.Add(tex, content.Load<Texture2D>(tex));
                }
            }
        }
    }
}
