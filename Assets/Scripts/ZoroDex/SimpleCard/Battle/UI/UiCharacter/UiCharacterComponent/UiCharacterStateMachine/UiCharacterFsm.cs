using UnityEngine;
using UnityEngine.PlayerLoop;
using ZoroDex.SimpleCard.Patterns;

namespace ZoroDex.SimpleCard.Battle.UI.Character
{
    /// <summary>
    ///     State Machine that holds all states of a UI character.
    /// </summary>
    public class UiCharacterFsm : BaseStateMachine
    {
        public UiCharacterFsm(Camera camera,UiCharacterParameters parameters,IUiCharacter handler) : base(handler)
        {
            IdleState = new UiCharacterIdle(handler, this, parameters);
            DisableState = new UiCharacterDisable(handler, this, parameters);
            HoverState = new UiCharacterHover(handler, this, parameters);
            SelectedState = new UiCharacterSelected(handler, this, parameters);
            AttackState = new UiCharacterAttack(handler, this, parameters);

            RegisterState(IdleState);
            RegisterState(DisableState);
            RegisterState(HoverState);
            RegisterState(SelectedState);
            RegisterState(AttackState);

            Initialize();

        }
        
        
        UiCharacterIdle IdleState { get; }
        UiCharacterDisable DisableState { get; }
        UiCharacterHover HoverState { get; }
        
        UiCharacterSelected SelectedState { get; }
        
        UiCharacterAttack AttackState { get; }


        public void Hover() => PushState<UiCharacterHover>();
        public void Disable() => PushState<UiCharacterDisable>();
        public void Enable() => PushState<UiCharacterIdle>();
        public void Unselect() => Enable();
        public void Select() => PushState<UiCharacterSelected>();

        public void Attack(Vector3 targetPosition)
        {
            PushState<UiCharacterAttack>();
            AttackState.ExectueAttack(targetPosition);
        }


    }
}