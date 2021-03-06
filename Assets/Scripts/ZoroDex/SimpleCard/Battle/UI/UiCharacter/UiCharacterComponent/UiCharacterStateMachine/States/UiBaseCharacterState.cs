﻿
using ZoroDex.SimpleCard.Patterns;

namespace ZoroDex.SimpleCard.Battle.UI.Character
{
    /// <summary>
    ///     Base UI Character State.
    /// </summary>
    public abstract class UiBaseCharacterState : IState
    {
        const int LayerToRenderNormal = 0;
        const int LayerToRenderTop = 1;

        protected UiBaseCharacterState(IUiCharacter handler, BaseStateMachine fsm, UiCharacterParameters parameters)
        {
            Fsm = fsm;
            Handler = handler;
            IsInitialized = true;
            Parameters = parameters;

        }
        
        protected IUiCharacter Handler { get; }
        protected BaseStateMachine Fsm { get; }
        protected UiCharacterParameters Parameters { get; }
        
        public bool IsInitialized { get; }

        /// <summary>
        ///     Renders the textures in the first layer. Each card state is responsible to handle its own layer activity.
        /// </summary>
        protected virtual void MakeRenderFirst() => Handler.Renderer.sortingOrder = LayerToRenderTop;

        /// <summary>
        ///     Renders the textures in the regular layer. Each card state is responsible to handle its own layer activity.
        /// </summary>
        protected virtual void MakeRenderNormal() => Handler.Renderer.sortingOrder = LayerToRenderNormal;

        /// <summary>
        ///     Enables the card entirely. Collision, Rigidbody and adds Alpha.
        /// </summary>
        protected void Enable()
        {
            if (Handler.Collider)
                EnableCollision();
            if (Handler.Rigidbody)
                Handler.Rigidbody.Sleep();

            MakeRenderNormal();
            RemoveAllTransparency();

        }

        /// <summary>
        ///     Disables the card entirely. Collision, Rigidbody and adds Alpha.
        /// </summary>
        protected virtual void Disable()
        {
            DisableCollision();
            Handler.Rigidbody.Sleep();
            MakeRenderNormal();
            var myColor = Handler.Renderer.color;
            myColor.a = Parameters.DisabledAlpha;
            Handler.Renderer.color = myColor;

        }

        /// <summary>
        ///     Disables the collision with this card.
        /// </summary>
        protected void DisableCollision() => Handler.Collider.enabled = false;

        /// <summary>
        ///     Enables the collision with this card.
        /// </summary>
        protected void EnableCollision() => Handler.Collider.enabled = true;


        /// <summary>
        ///     Remove any alpha channel in all renderers.
        /// </summary>
        protected void RemoveAllTransparency()
        {
            if (Handler.Renderer)
            {
                var myColor = Handler.Renderer.color;
                myColor.a = 1;
                Handler.Renderer.color = myColor;
            }
        }
        
        void IState.OnInitialize()
        {
            throw new System.NotImplementedException();
        }

        public virtual void OnEnterState()
        {
            throw new System.NotImplementedException();
        }

        public virtual void OnExitState()
        {
            throw new System.NotImplementedException();
        }

        public virtual void OnUpdate()
        {
            throw new System.NotImplementedException();
        }

        public virtual void OnClear()
        {
            throw new System.NotImplementedException();
        }

        public virtual void OnNextState(IState next)
        {
            throw new System.NotImplementedException();
        }
    }
}