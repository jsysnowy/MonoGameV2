using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Aurora.Core.Modules.PlayerControllers {
    class GRIDController : Base.Module {
        #region Class Properties
        /// <summary>
        /// Stores how big each grid area is.
        /// TODO: Tie into some GridController thingy?
        /// </summary>
        public float GridSize;

        /// <summary>
        /// Speed of this controller.
        /// </summary>
        public float Speed;

        /// <summary>
        /// Whether the player is currently moving.
        /// </summary>
        public bool Moving;

        /// <summary>
        /// Stores direction map grid.
        /// </summary>
        private int[] directionGrid = new int[4];
        
        /// <summary>
        /// Stores the last direction pressed.
        /// </summary>
        private Vector2 currentMovementDirection;

        /// <summary>
        /// Stores how far between grid positions moved.
        /// </summary>
        private float currentMovedAmount;

        /// <summary>
        /// Order of pressed keys.
        /// </summary>
        private List<int> MoveOrder;

        #endregion
        /// <summary>
        /// Create new instance of GRIDController
        /// </summary>
        public GRIDController() : base () {
            GridSize = 64;
            Moving = false;
            Speed = 8f;
            directionGrid[0] = 0;
            directionGrid[1] = 0;
            directionGrid[2] = 0;
            directionGrid[3] = 0;
            MoveOrder = new List<int>();
            
        }

        /// <summary>
        /// Updates this GRIDController.
        /// </summary>
        /// <param name="gT"></param>
        public override void Update(GameTime gT) {

            // Get Keyboard state:
            KeyboardState keyState = Keyboard.GetState();

            if (!Moving) {
                // Set nonmoving parmas
                currentMovedAmount = 0;

                // Walk up
                if (keyState.IsKeyDown(Keys.W)) {
                    if (directionGrid[0] == 0) {
                        directionGrid[0] = 1;
                        MoveOrder.Add(0);
                    }
                } else {
                    if (directionGrid[0] == 1) {
                        directionGrid[0] = 0;
                        MoveOrder.Remove(0);
                    }
                }

                // Walk down
                if (keyState.IsKeyDown(Keys.S)) {
                    if (directionGrid[1] == 0) {
                        directionGrid[1] = 1;
                        MoveOrder.Add(1);
                    }
                } else {
                    if (directionGrid[1] == 1) {
                        directionGrid[1] = 0;
                        MoveOrder.Remove(1);
                    }
                }

                // Walk left
                if (keyState.IsKeyDown(Keys.A)) {
                    if (directionGrid[2] == 0) {
                        directionGrid[2] = 1;
                        MoveOrder.Add(2);
                    }
                } else {
                    if (directionGrid[2] == 1) {
                        directionGrid[2] = 0;
                        MoveOrder.Remove(2);
                    }
                }

                // Walk right
                if (keyState.IsKeyDown(Keys.D)) {
                    if (directionGrid[3] == 0) {
                        directionGrid[3] = 1;
                        MoveOrder.Add(3);
                    }
                } else {
                    if (directionGrid[3] == 1) {
                        directionGrid[3] = 0;
                        MoveOrder.Remove(3);
                    }
                }

                // Sort direction based on held key
                if (MoveOrder.Count == 0) {
                    currentMovementDirection = new Vector2(0, 0);
                } else if (MoveOrder.Last() == 0) {
                    currentMovementDirection = new Vector2(0, -1);
                    Moving = true;
                } else if (MoveOrder.Last() == 1) {
                    currentMovementDirection = new Vector2(0, 1);
                    Moving = true;
                } else if (MoveOrder.Last() == 2) {
                    currentMovementDirection = new Vector2(-1, 0);
                    Moving = true;
                } else if (MoveOrder.Last() == 3) {
                    currentMovementDirection = new Vector2(1, 0);
                    Moving = true;
                }

                if (currentMovedAmount >= GridSize ) {
                    currentMovedAmount = GridSize;
                    Moving = false;
                }

                // Increment currentMovedAmount:
                currentMovedAmount += Math.Abs(currentMovementDirection.X * Speed);
                currentMovedAmount += Math.Abs(currentMovementDirection.Y * Speed);


                // Add speed to the object.
                MyObj.WorldPosition.X += currentMovementDirection.X * currentMovedAmount;
                MyObj.WorldPosition.Y += currentMovementDirection.Y * currentMovedAmount;
            } else {
                // Increment currentMovedAmount:
                float movedThisFrame = 0;
                movedThisFrame += Math.Abs(currentMovementDirection.X * Speed);
                movedThisFrame += Math.Abs(currentMovementDirection.Y * Speed);

                currentMovedAmount += movedThisFrame;

                
                if (currentMovedAmount+Speed >= GridSize) {
                    Moving = false;
                }

                // Add speed to the object.
                MyObj.WorldPosition.X += currentMovementDirection.X * movedThisFrame;
                MyObj.WorldPosition.Y += currentMovementDirection.Y * movedThisFrame;
            }

            //System.Diagnostics.Trace.WriteLine(MyObj.WorldPosition);

            // Update base.
            base.Update(gT);
        }
    }
}
