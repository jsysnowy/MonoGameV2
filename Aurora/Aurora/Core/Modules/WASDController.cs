using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Aurora.Core.Modules {
    class WASDController : Base.Module {

        public float Speed { get; set; } = 3.0f;

        public override void Update(GameTime gT) {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.W)) {
                MyObj.WorldPosition.Y -= Speed;
            }
            if (keyState.IsKeyDown(Keys.A)) {
                MyObj.WorldPosition.X -= Speed;
            }
            if (keyState.IsKeyDown(Keys.S)) {
                MyObj.WorldPosition.Y += Speed;
            }
            if (keyState.IsKeyDown(Keys.D)) {
                MyObj.WorldPosition.X += Speed;
            }
        }
    }
}
