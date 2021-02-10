using System.ComponentModel;
using UnityEngine;
using UnityEngine.Networking;

namespace ZoroDex.SimpleCard.Tools.UI
{
    public class UiMotionMovement : UiMotionBase
    {
        public UiMotionMovement(MonoBehaviour handler) : base(handler)
        {
            
        }

        private bool WithZ { get; set; }

        public override void Execute(Vector3 vector, float speed, float delay = 0, bool WithZ = false)
        {
            WithZ = WithZ;
            base.Execute(vector, speed, delay, WithZ);
        }

        protected override void OnMotionEnds()
        {
            WithZ = false;
            IsOperating = false;
            var target = Target;
            target.z = Handler.transform.position.z;
            Handler.transform.position = target;
            base.OnMotionEnds();
        }

        protected override void KeepMotion()
        {
            var current = Handler.transform.position;
            var amount = Speed * Time.deltaTime;
            var delta = Vector3.Lerp(current, Target, amount);
            if (!WithZ)
                delta.z = Handler.transform.position.z;
            Handler.transform.position = delta;
        }

        protected override bool CheckFinalState()
        {
            var distance = Target - Handler.transform.position;
            if (!WithZ)
                distance.z = 0;
            return distance.magnitude <= Threshold;
        }
    }
}