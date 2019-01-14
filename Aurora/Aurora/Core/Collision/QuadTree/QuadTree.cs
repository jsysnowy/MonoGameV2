using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

// Collision module reference:
using Aurora.Core.Modules.CollisionBoxes;

// Microsoft.XNA
using Microsoft.Xna.Framework.Graphics;

// Monogame.Exteneded
using MonoGame.Extended;

/// <summary>
///     
///     QuadTree nodes map:
/// 
///     -----------------
///     |       |       | 
///     |   0   |   1   | 
///     |       |       |
///     -----------------
///     |       |       | 
///     |   2   |   3   | 
///     |       |       | 
///     -----------------
///     
/// </summary>

namespace Aurora.Core.Collision.QuadTree {
    class QuadTree {
        #region Class Properties
        /// <summary>
        /// Maximum allowed objects in this QuadTree before it splits.
        /// </summary>
        private readonly int MAX_OBJECTS = 2;

        /// <summary>
        /// Stores max depth the QuadTree can reach
        /// </summary>
        private readonly int MAX_DEPTH = 5;

        /// <summary>
        /// Stores the depth of this node.
        /// </summary>
        private int _depth;

        /// <summary>
        /// If this QuadTree is split into subtrees.
        /// </summary>
        private bool _split;

        /// <summary>
        /// Stores the bounds of this QuadTree.
        /// </summary>
        private Rectangle _bounds;

        /// <summary>
        /// Stores sub Quads inside this QuadTree.
        /// </summary>
        private QuadTree[] _nodes;

        /// <summary>
        /// Stores list of all objects currently inside the QuadTree.
        /// </summary>
        private List<CollisionModule> _objects;
        #endregion

        #region Constructor
        /// <summary>
        /// Create new QuadTree.
        /// </summary>
        /// <param name="bounds"></param>
        public QuadTree(int depth, Rectangle bounds) {
            _depth = depth;
            _bounds = bounds;
            _objects = new List<CollisionModule>();
            _split = false;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Checks which index the passed in bounds belongs to.
        /// </summary>
        /// <param name="In"></param>
        /// <returns></returns>
        public int CheckIndex( Rectangle In ) {
            // If it hasn't split, always return -1.
            if ( !_split) {
                return -1;
            }

            // Store the midpoint for Y, and flag for if it is above or below.
            float midY = _bounds.Y + (_bounds.Height / 2);
            bool above;
            
            // First we check if bounds exists completely above or below the middle of the quad
            if ( In.Y > midY) {
                // fully below the Y.
                above = false;
            } else if ( In.Y+ In.Height < midY) {
                // fully above the Y.
                above = true;
            } else {
                // Our rect exists somewhere along the Y, and can't be placed deeper.
                return -1;
            }

            // Store the midpoint for X, and flag for if it is left or right.
            float midX = _bounds.X + (_bounds.Width / 2);
            bool left;

            // Next, we check if bounds exists completely left or right the middle of the quad
            if (In.X > midX) {
                // fully below the Y.
                left = false;
            } else if (In.X + In.Width < midX) {
                // fully above the Y.
                left = true;
            } else {
                // Our rect exists somewhere along the Y, and can't be placed deeper.
                return -1;
            }

            // Return quad based off calculated position:
            if ( above ) {
                if (left) {
                    return 0;
                } else {
                    return 1;
                }
            } else {
                if ( left) {
                    return 2;
                } else {
                    return 3;
                }
            }
        }

        /// <summary>
        /// Add an object to this QTM.
        /// </summary>
        /// <param name="objIn"></param>
        public void AddObject( CollisionModule objIn ) {
            if (_split) {
                // Check index of obj
                int index = CheckIndex(objIn.Bounds);

                // Check if this obj needs to be added to a child node.
                if ( index == -1 ) {
                    // Push objIn into our list.
                    _objects.Add(objIn);
                } else {
                    // Push obj into child node this belongs to.
                    _nodes[index].AddObject(objIn);
                }
            } else {
                // Push objIn into our list.
                _objects.Add(objIn);
             
                // Check if a split needs to happen.
                if (_objects.Count == MAX_OBJECTS && _depth != MAX_DEPTH) {
                    Split();
                }
            }
        }

        /// <summary>
        /// Splits this QuadTree into 4 smaller QuadTrees.
        /// </summary>
        public void Split() {
            // If this QT has already split, then it doesn't split again.
            if ( _split) {
                return;
            }
            // Set split flag.
            _split = true;

            // Create new array of child nodes.
            _nodes = new QuadTree[4];

            // Store half W/H for use later.
            // TODO: This could cause issues as i'm loosely casting double to int.
            int hW = _bounds.Width / 2;
            int hH = _bounds.Height / 2;
            
            // Create the children
            _nodes[0] = new QuadTree(_depth + 1,
                new Rectangle(_bounds.X, _bounds.Y, hW, hH)    
            );
            _nodes[1] = new QuadTree(_depth + 1,
                new Rectangle(_bounds.X + hW, _bounds.Y, _bounds.Width / 2, _bounds.Height / 2)    
            );
            _nodes[2] = new QuadTree(_depth + 1,
                new Rectangle(_bounds.X, _bounds.Y + hH, _bounds.Width / 2, _bounds.Height / 2)    
            );
            _nodes[3] = new QuadTree(_depth + 1,
                new Rectangle(_bounds.X + hW, _bounds.Y + hH, _bounds.Width / 2, _bounds.Height / 2)    
            );

            // Redistribute all objects.
            int i = 0;
            while ( i < _objects.Count) {
                int index = CheckIndex(_objects[i].Bounds);
                if ( index == -1) {
                    i++;
                } else {
                    _nodes[index].AddObject(_objects[i]);
                    _objects.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Retrieve all colliding nodes which pased in CollisiomModule colides with.
        /// </summary>
        /// <param name="In"></param>
        /// <returns></returns>
        public List<CollisionModule> Retreive( CollisionModule In ) {
            // Get index of passed in CollisioModule
            int index = CheckIndex(In.Bounds);

            // Return all objects this needs to be tested against:
            if ( index == -1) {
                return _objects;
            } else {
                // Return all of the nodes objects  + this QTs objects.
                List<CollisionModule> objs = new List<CollisionModule>();
                objs.AddRange(_nodes[index].Retreive(In));
                objs.AddRange(_objects);
                return objs;
            }
        }

        /// <summary>
        /// Draws the QuadTree.
        /// </summary>
        public void Draw(SpriteBatch sB, Color col) {
            if ( _split) {
                _nodes[0].Draw(sB, Color.Red);
                _nodes[1].Draw(sB, Color.Blue);
                _nodes[2].Draw(sB, Color.Green);
                _nodes[3].Draw(sB, Color.Yellow);
            } else {
                //System.Diagnostics.Trace.WriteLine("Drawing" + _bounds.ToString());
                sB.DrawRectangle(_bounds, col, 5);
            }
        }
        #endregion
    }
}
