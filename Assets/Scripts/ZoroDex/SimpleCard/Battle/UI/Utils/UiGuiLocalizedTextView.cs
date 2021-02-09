using UnityEngine;

namespace ZoroDex.SimpleCard
{
    public class UiGuiLocalizedTextView : UiGUIText
    {
        [SerializeField] private LocalizationIds id;

        protected override void Awake()
        {
            base.Awake();
            SetText(Localization.Instance.Get(id));
        }

    }
}