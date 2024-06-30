using System.Linq;
using Extensions;
using UnityEngine;
using System;
using CARD_DATA;
using System.Collections.Generic;

namespace Tools.UI.Card
{
    /// <summary>
    ///     Picks a Texture randomly when it Awakes.
    /// </summary>
    public class UiTexturePicker : MonoBehaviour
    {
        [SerializeField] private Sprite[] Sprites;

        private List<Sprite> spriteList = new List<Sprite>();
        [SerializeField] private SpriteRenderer MyRenderer { get; set; }

        private CardConfigData[] allCards => DataCardManager.instance.config.cards; // Should this be a SerializedField?

        private void Awake()
        {
            MyRenderer = GetComponent<SpriteRenderer>();

            // Pick card character sprite

            foreach (var card in allCards)
            {
                spriteList.Add(card.cardSprite);
            }

            if (spriteList.Count > 0)
                MyRenderer.sprite = spriteList.RandomItem();
                //allCards.Where(c => c.name == "BB").ToArray()[0].cardSprite;// Just testing -> need to use allCards / Deck in the function that calls this one
        }
    }
}