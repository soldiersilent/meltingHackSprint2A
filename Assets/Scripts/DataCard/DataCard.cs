using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CARD_DATA
{
    // TODO check if this makes sense here vs extending Card UI
    public abstract class DataCard
    {
        public string name = "";
        public string displayName = "";
        public RectTransform root = null; // refers to card rect, allows us to make it appear and disappear etc

        public CardConfigData config;

        public Animator animator; // TODO check if needed

        // TODO highlighted and unhighlighted colours?

        public DataCardManager manager => DataCardManager.instance;

        public DataCard (string name, CardConfigData config, GameObject prefab)
        {
            this.name = name;
            displayName = name;
            this.config = config;

            if (prefab != null)
            {
                GameObject obj = Object.Instantiate(prefab, manager.cardPanel);
                obj.name = manager.FormatCardPath(manager.cardPrefabNameFormat, name); // See code that defines names as Card_01 etc - change this to take in card data name from prefab
                //obj.SetActive(true);
                root = obj.GetComponent<RectTransform>();
                //animator = root.GetComponentInChildren<animator>();
            }
        }

        public enum CardType
        {
            Demon,
            Spell,
            Item
        }


    }
}
