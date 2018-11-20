using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;


namespace Aurora.Core.Modules.CollisionBoxes {
    class TextureHitArea : Base.Module {
        /// <summary>
        /// Create new instance of TextureHitArea.
        /// </summary>
        public TextureHitArea() {

        }

        /// <summary>
        /// Overrides drawing.
        /// </summary>
        /// <param name="sB"></param>
        public override void Draw(SpriteBatch sB) {
            // If it has a texture:
            if ( MyObj.GetModule<TextureModule>().Texture != null) {
                // Draw hitbox:
                Texture2D tex = MyObj.GetModule<TextureModule>().Texture;
                // Line across:
                sB.DrawLine(
                    MyObj.WorldPosition,
                    new Vector2(MyObj.WorldPosition.X + tex.Width, MyObj.WorldPosition.Y),
                    Color.LightGreen,
                    1
                );
                sB.DrawLine(
                    new Vector2(MyObj.WorldPosition.X + tex.Width, MyObj.WorldPosition.Y),
                    new Vector2(MyObj.WorldPosition.X + tex.Width, MyObj.WorldPosition.Y + tex.Height),
                    Color.LightGreen,
                    1

                );
                sB.DrawLine(
                    new Vector2(MyObj.WorldPosition.X + tex.Width, MyObj.WorldPosition.Y + tex.Height),
                    new Vector2(MyObj.WorldPosition.X , MyObj.WorldPosition.Y + tex.Height),
                    Color.LightGreen,
                    1
                );
                sB.DrawLine(
                    new Vector2(MyObj.WorldPosition.X, MyObj.WorldPosition.Y + tex.Height),
                    MyObj.WorldPosition,
                    Color.LightGreen,
                    1
                );
                sB.DrawLine(
                    new Vector2(MyObj.WorldPosition.X + tex.Width, MyObj.WorldPosition.Y),
                    new Vector2(MyObj.WorldPosition.X, MyObj.WorldPosition.Y + tex.Height),
                    Color.LightGreen,
                    1
                );
            }
            // Else hitArea is 0
            else {

            }
        }
    }
}
