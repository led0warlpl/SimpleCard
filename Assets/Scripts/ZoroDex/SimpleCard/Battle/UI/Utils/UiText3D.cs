﻿using System;
using TMPro;
using UnityEngine;

namespace ZoroDex.SimpleCard
{
    [RequireComponent(typeof(TextMeshPro))]
    public class UiText3D : MonoBehaviour
    {
        [Tooltip("Color of the text.")][SerializeField]
        protected Color color = Color.black;

        [SerializeField] private string defaultText = string.Empty;

        [Tooltip("TMPro Component assigned by the Editor or Automatically on Awake.")]
        private TextMeshPro TmProText;

        protected void Awake()
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
                TmProText = GetComponent < TextMeshPro>();
            TmProText.color = color;
        }
    }
}