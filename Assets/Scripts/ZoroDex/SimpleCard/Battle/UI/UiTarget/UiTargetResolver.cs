using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using ZoroDex.SimpleCard.Battle;
using ZoroDex.SimpleCard.Battle.Controller;
using ZoroDex.SimpleCard.Battle.UI.Card;
using ZoroDex.SimpleCard.Battle.UI.Character;
using ZoroDex.SimpleCard.Battle.UI.UiPlayerHand;
using ZoroDex.SimpleCard.Data.Effects;
using ZoroDex.SimpleCard.Patterns;
using IUiPlayerTeam = ZoroDex.SimpleCard.Battle.UI.Character.IUiPlayerTeam;

namespace ZoroDex.SimpleCard
{
    public interface ITargetResolver
    {
        IUiPlayerController Controller { get; }
        IUiPlayerTeam RightTeam { get; }
        IUiPlayerTeam LeftTeam { get; }
        IUiPlayerHand Hand { get; }
        IGameData GameData { get; }
        Action<ITargetable,PlayerSeat> OnSelectTarget { get; set; }
        Action<IUiCard> OnTargetsResolve { get; set; }
        IEnumerator ResolveTargets(IUiCard card, EffectTriggerType trigger);

    }

    public class UiTargetResolver : SingletonMB<UiTargetResolver>, ITargetResolver
    {
        [SerializeField] UiPlayerHand hand;
        [SerializeField] UiPlayerTeam leftTeam;
        [SerializeField] UiPlayerTeam rightTeam;

        public IGameData GameData => GameController.Instance.Data;

        public Action<ITargetable, PlayerSeat> OnSelectTarget { get; set; } = (target, seat) => { };
        public Action<IUiCard> OnTargetsResolve { get; set; } = card => { };
        
        public IUiPlayerHand Hand =>hand;
        public IUiPlayerTeam RightTeam => rightTeam;
        public IUiPlayerTeam LeftTeam => leftTeam;
        public IUiPlayerController Controller { get; private set; }

        public IEnumerator ResolveTargets(IUiCard uiCard, EffectTriggerType trigger)
        {
            if (uiCard == null)
                yield return 0;

            var card = uiCard.Data.RuntimeData;
            
            //grab all effects from the card
            var effects = GetEffects(card);
            
            //return if the specified trigger is not present
            if (!effects.Any(eff => eff.Key.tType == trigger))
                yield return 0;

            var effectsByTrigger = effects[effects.First(eff => eff.Key.tType == trigger).Key].Effects;
            
            //register them in the card with their respective targets
            foreach (var effect in effectsByTrigger)
            {
                var targetType = effect.Target;
                var targets = targetType.GetTargets(card, GameData.RuntimeGame);

                if (targetType.IsDynamic)
                {
                    uiCard.Target();

                    targetType.Subscribe(this);
                    
                    //keep checking the amount of targets until they are completely filled
                    yield return new WaitWhile(() =>
                        targetType.GetTargets(card, GameData.RuntimeGame).Length != targetType.TargetAmount);
                    targets = targetType.GetTargets(card, GameData.RuntimeGame);
                    effect.Target.Unsubscribe(this);

                }

                card.AddTargets(effect, targets);

            }
            
            //resolve the spell
            Controller.PlayerController.Player.Play(card);
            
            OnTargetsResolve.Invoke(uiCard);

        }

        protected override void OnAwake()
        {
            Hand.OnCardPlayed += card => StartCoroutine(ResolveTargets(card, EffectTriggerType.OnPlay));
            Controller = GetComponent<IUiPlayerController>();
            RightTeam.OnCharacterSelected += SelectTargetRight;
            LeftTeam.OnCharacterSelected += SelectTargetLeft;
        }

        void SelectTargetRight(IUiCharacter target) => OnSelectTarget(target.Data.RuntimeData, PlayerSeat.Right);
        void SelectTargetLeft(IUiCharacter target) => OnSelectTarget(target.Data.RuntimeData, PlayerSeat.Left);
        
        EffectsSet.EffectRegister GetEffects(IRuntimeCard card) => card.Data.Effects.Register;



    }
    
}