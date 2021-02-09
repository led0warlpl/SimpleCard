using TMPro;
using UnityEngine.UI;
using ZoroDex.SimpleCard.Battle;

namespace ZoroDex.SimpleCard
{
    public class UiAnimationHeal: UiAnimation,GameEvents.IDoHeal
    {
        private TMP_Text Text { get; set; }

        void GameEvents.IDoHeal.OnHeal(IHealer source, IHealable target, int amount)
        {
            Text.text = Localization.Instance.Get(LocalizationIds.Heal)+ "+" +amount;
            StartCoroutine(Animate());
        }

        protected override void Awake()
        {
            base.Awake();
            Text = GetComponent<TMP_Text>();
        }
    }
}