using System.Linq;
using Extensions;
using UnityEngine;
using System;
using CARD_DATA;

namespace Tools.UI.Card
{
    /// <summary>
    ///     Picks a Texture randomly when it Awakes.
    /// </summary>
    public class UiTexturePicker : MonoBehaviour
    {
        [SerializeField] private Sprite[] Sprites;
        [SerializeField] private SpriteRenderer MyRenderer { get; set; }

        private CardConfigData[] allCards => DataCardManager.instance.config.cards; // Should this be a SerializedField?

        private void Awake()
        {
            MyRenderer = GetComponent<SpriteRenderer>();

            // Pick card character sprite

            if (Sprites.Length > 0)
                MyRenderer.sprite = allCards.Where(c => c.name == "BB").ToArray()[0].cardSprite;// Just testing -> need to use allCards / Deck in the function that calls this one
        }
    }
}