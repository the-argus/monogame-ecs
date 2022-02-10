using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameObject_Proof_of_Concept
{
    class SpriteRenderer: Component, IDraw
    {
        public SpriteBatch spriteBatch;
        public Rectangle Rect;
        public Texture2D Texture;
        void IDraw.Draw()
        {
            spriteBatch.Draw(Texture, Rect, Color.White);
        }
        
        public SpriteRenderer(GameObject gameObject, SpriteBatch spriteBatch, Texture2D Texture) : base(gameObject)
        {
            this.Texture = Texture;
            this.spriteBatch = spriteBatch;
            
            // grab any existing transform component
            Transform c = gameObject.GetComponent<Transform>();
            Point pos;
            
            // make sure we actually found a transform component
            if (c != null)
            {
                pos = c.position;
            }
            else
            {
                throw new System.Exception("SpriteRenderer Relies on an instance of the transform component.");
            }

            // create a rectangle from the transform
            this.Rect = new Rectangle(pos, new Point(Texture.Width, Texture.Height));
        }
    }
}
