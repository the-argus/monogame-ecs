using Microsoft.Xna.Framework;

namespace GameObject_Proof_of_Concept
{
    class Transform : Component
    {
        public Point position;
        
        public Transform(GameObject gameObject, Point position): base(gameObject)
        {
            this.position = position;
        }
    }
}
