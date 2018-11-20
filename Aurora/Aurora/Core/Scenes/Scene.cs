using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Aurora.Core.Objects;
using Aurora.Core.Camera;


namespace Aurora.Core.Scenes {
    class Scene : GameObject {
        /// <summary>
        /// Stores ActiveCamera 
        /// </summary>
        public Camera.Camera ActiveCamera { get; private set; }

        /// <summary>
        /// Create this new scene.
        /// </summary>
        public Scene() : base() {
            ActiveCamera = new Camera.Camera(Overseer.Instance.GD.Viewport);
        }

        /// <summary>
        /// Updates this scene.
        /// </summary>
        public override void Update( GameTime gT) {
            ActiveCamera.Update();
      
            base.Update(gT );
        }
    }
}
