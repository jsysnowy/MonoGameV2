using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Microsoft XNA.
using Microsoft.Xna.Framework;

namespace Aurora.Core.Modules.CollisionBoxes {
    class CustomRectHitArea : CollisionModule {
        /// <summary>
        /// Stores the custom defined rect.
        /// </summary>
        private Rectangle _customRect = new Rectangle(0, 0, 0, 0);

        /// <summary>
        /// Sets bounds customly.
        /// </summary>
        /// <param name="rect"></param>
        public void SetBounds( Rectangle rect ) {
            _customRect = rect;
        }

        public override void Update(GameTime gT) {
            _bounds = new Rectangle(_customRect.X + (int)MyObj.WorldPosition.X, _customRect.Y + (int)MyObj.WorldPosition.Y, _customRect.Width, _customRect.Height);

            base.Update(gT);
        }

        public override void OnCollision(CollisionModule Other) {
            //MyObj.WorldPosition.X = -1;
            //MyObj.WorldPosition.Y = -1;
            base.OnCollision(Other);
        }
    }
}
