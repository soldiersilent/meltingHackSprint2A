using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CARD_DATA
{
    [CreateAssetMenu(fileName = "CardConfigurationAsset", menuName = "ScriptableObjects/Card Configuration Asset", order = 1)]
    public class CardScriptableObjectConfig : ScriptableObject
    {


        public CardConfigData[] cards;

        public CardConfigData GetConfig(string cardName)
        {
            cardName = cardName.ToLower();

            for (int i = 0; i < cards.Length; i++)
            {
                CardConfigData data = cards[i];

                if (string.Equals(cardName, data.name.ToLower()) || string.Equals(cardName, data.alias.ToLower()))
                    return data.Copy();
            }
            return CardConfigData.Default;
        }
    }
}
