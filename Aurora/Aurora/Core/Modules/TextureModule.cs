using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aurora.Core.Modules {
    class TextureModule : Base.Module {

        /// <summary>
        /// Set TextureID, this also sets Texture.
        /// </summary>
        public string TextureID {
            set {
                Texture = Loader.TextureCache[value];
            }
        }


        /// <summary>
        /// Stores the Texture.
        /// </summary>
        public Texture2D Texture { get; private set; }
        
        /// <summary>
        /// Create this TextureModule.
        /// </summary>
        public TextureModule() {}

        /// <summary>
        ///  Draw this texture at the objects position.
        /// </summary>
        /// <param name="sB"></param>
        public override void Draw(SpriteBatch sB) {
            sB.Draw(Texture, new Vector2(MyObj.WorldPosition.X, MyObj.WorldPosition.Y), Color.White);
        }
    }
}
