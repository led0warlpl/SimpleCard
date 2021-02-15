using Extensions;
using UnityEngine;
using ZoroDex.SimpleCard.Patterns;

namespace ZoroDex.SimpleCard.Battle.UI.Card
{
    /// <summary>
    ///     This state tells what happen with a card when searching for a target.
    /// </summary>
    public class UiCardTarget : UiBaseCardState
    {
        public UiCardTarget(IUiCard handler, Camera camera, BaseStateMachine fsm, UiCardParameters parameters)
            : base(handler, fsm, parameters)
        {
            var screenCenter = new Vector2(Screen.width, Screen.height) / 2;
            WorldCenter = camera.ScreenToWorldPoint(screenCenter).WithZ(0);
            Speed = 8;
        }
        
        Vector3 WorldCenter { get; }
        float Speed { get; }

        public override void OnEnterState() => Handler.Motion.MoveTo(WorldCenter, Speed);

    }
}