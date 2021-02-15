
using System;
using UnityEngine;
using ZoroDex.SimpleCard.Data.Card;

namespace ZoroDex.SimpleCard.Data.UI.Card
{
    [RequireComponent((typeof(SpriteRenderer)))]
    public class UiChangeCardTexture : MonoBehaviour
    {
        private SpriteRenderer MyRenderer { get; set; }
        private IUiCardData Handler { get; set; }

        void OnSetData(ICardData data) => SetTexture(data.Artwork);

        void SetTexture(Sprite sprite) => MyRenderer.sprite = sprite;

        void awake()
        {
            MyRenderer = GetComponent<SpriteRenderer>();
            Handler = GetComponentInParent<IUiCardData>();
            Handler.OnSetData += OnSetData;
        }

        private void OnDestroy()
        {
            if (Handler?.OnSetData != null)
                Handler.OnSetData -= OnSetData;
        }
    }
}