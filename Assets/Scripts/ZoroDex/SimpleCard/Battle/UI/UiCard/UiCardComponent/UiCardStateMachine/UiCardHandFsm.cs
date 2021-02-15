using UnityEngine;
using ZoroDex.SimpleCard.Patterns;

namespace ZoroDex.SimpleCard.Battle.UI.Card
{
    /// <summary>
    ///     State Machine that holds all states of a Ui Card.
    /// </summary>
    public class UiCardHandFsm : BaseStateMachine
    {
        public UiCardHandFsm(Camera camera, UiCardParameters cardConfigParameters, IUiCard handler = null) :
            base(handler)
        {
            CardConfigsParamerers = cardConfigParameters;

            IdleState = new UiCardIdle(handler, this, CardConfigsParamerers);
            DisableState = new UiCardDisable(handler, this, CardConfigsParamerers);
            DragState = new UiCardDrag(handler, camera, this, CardConfigsParamerers);
            HoverState = new UiCardHover(handler, this, CardConfigsParamerers);
            DrawState = new UiCardDraw(handler, this, CardConfigsParamerers);
            DiscardState = new UiCardDiscard(handler, this, CardConfigsParamerers);
            TargetState = new UiCardTarget(handler, camera, this, CardConfigsParamerers);

            RegisterState(IdleState);
            RegisterState(DisableState);
            RegisterState(DragState);
            RegisterState(HoverState);
            RegisterState(DrawState);
            RegisterState(DiscardState);
            RegisterState(TargetState);

            Initialize();



        }
        
        UiCardIdle IdleState { get; }
        UiCardDisable DisableState { get; }
        UiCardDrag DragState { get; }
        UiCardHover HoverState { get; }
        UiCardDraw DrawState { get; }
        UiCardDiscard DiscardState { get; }
        UiCardTarget TargetState { get; }
        UiCardParameters CardConfigsParamerers { get; }

        public void Hover() => PushState<UiCardHover>();
        public void Disable() => PushState<UiCardDisable>();
        public void Enable() => PushState<UiCardIdle>();
        public void Select() => PushState<UiCardDrag>();
        public void UnSelect() => Enable();
        public void Draw() => PushState<UiCardDraw>();
        public void Discard() => PushState<UiCardDiscard>();

        public void Play()
        {
            
        }

        public void Target() => PushState<UiCardTarget>();


    }
}