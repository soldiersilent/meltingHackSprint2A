using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CARD_DATA;

public class TestingCardData : MonoBehaviour
{
    public CardScriptableObjectConfig cardConfigs;

    void Start()
    {
        foreach (var card in DataCardManager.instance.config.cards)
        {
            Debug.Log($"{card.name}");
        }
        
    }


}
