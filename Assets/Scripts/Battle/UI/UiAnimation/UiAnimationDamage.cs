﻿using TMPro;

namespace SimpleCardGames.Battle
{
    public class UiAnimationDamage : UiAnimation, IDoDamage
    {
        TMP_Text Text { get; set; }

        void IDoDamage.OnDamage(IDamager source, IDamageable target, int amount)
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