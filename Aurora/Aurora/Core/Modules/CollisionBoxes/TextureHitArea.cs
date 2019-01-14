using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;


namespace Aurora.Core.Modules.CollisionBoxes {
    class TextureHitArea : CollisionModule {
        /// <summary>
        /// Create new instance of TextureHitArea.
        /// </summary>
        public TextureHitArea() {
            _bounds = new Rectangle();
            
        }

        public override void Update(GameTime gT) {

            TextureModule texModule = MyObj.GetModule<TextureModule>();
            if ( texModule == null) {
                _bounds = new Rectangle();
                return;
            }
            
            if ( texModule.Texture == null) {
                _bounds = new Rectangle();
                return;
            }

            _bounds = new Rectangle((int)MyObj.WorldPosition.X, (int)MyObj.WorldPosition.Y, texModule.Texture.Width, texModule.Texture.Height);
                base.Update(gT);
        }
    }
}
