using UnityEngine;

namespace ZoroDex.SimpleCard.Tools.UI
{
    public class UiMotion
    {
        public UiMotion(MonoBehaviour handler)
        {
            
        }
        
        public UiMotionBase Movement { get; }
        public UiMotionBase Rotation { get; }
        public UiMotionBase Scale { get; }

        public void Update()
        {
            Movement?.Update();
            Rotation?.Update();
            Scale?.Update();
        }

        public void RotateTo(Vector3 rotation, float speed) => Rotation?.Execute(rotation, speed);

        public void MoveTo(Vector3 position, float speed, float delay = 0) => Movement?.Execute(position, speed, delay);

        public void MoveToWithZ(Vector3 position, float speed, float delay = 0) =>
            Movement?.Execute(position, speed, delay, true);

        public void ScaleTo(Vector3 scale, float speed, float delay = 0) => Scale?.Execute(scale, speed, delay);


    }
}