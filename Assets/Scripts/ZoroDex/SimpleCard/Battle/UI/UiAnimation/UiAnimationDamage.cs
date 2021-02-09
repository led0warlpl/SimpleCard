using UnityEngine;
using TMPro;
using UnityEngine.UI;
using ZoroDex.SimpleCard.Battle;

namespace ZoroDex.SimpleCard
{
    public class UiAnimationDamage : UiAnimation,GameEvents.IDoDamage
    {
        private TMP_Text Text { get; set; }

        void GameEvents.IDoDamage.OnDamage(IDamager source, IDamageable target, int amount)
        {
            Text.text = -amount + " " + Localization.Instance.Get(LocalizationIds.Damage);
            StartCoroutine(Animate());
        }
        

        protected override void Awake()
        {
            base.Awake();
            Text = GetComponent<TMP_Text>();
        }
        
    
    }
}
