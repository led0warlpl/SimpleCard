﻿using TMPro;
using UnityEngine;

namespace ZoroDex.SimpleCard
{
    [RequireComponent(typeof(TextMeshPro))]
    public class UiText3DListener : UiListener
    {
        [Tooltip("Color of the text.")][SerializeField]
        protected Color color = Color.black;

        [SerializeField] private string defaultText = string.Empty;

        [Tooltip("TmPro Component assigned by the Editor or Automatically n Awake.")]
        private TextMeshPro TmProText;

        protected virtual void Awake()
        {
            if (TmProText == null)
                TmProText = GetComponent<TextMeshPro>();
            ResetColor();
            SetText(defaultText);
        }

        public virtual void SetText(string text) => TmProText.text = text;

        public void ResetColor()
        {
            if (TmProText == null)
                TmProText = GetComponent<TextMeshPro>();
            TmProText.color = color;
        }

    }
}