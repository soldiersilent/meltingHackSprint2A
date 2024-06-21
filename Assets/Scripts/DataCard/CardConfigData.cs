using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CARD_DATA
{
    [System.Serializable]
    public class CardConfigData
    {
        public string name;
        public string alias;
        public string cardType;
        //public DataCard.CardType cardType; TODO

        public string sinType;
        // public DataCard.SinType sinType; TODO - maybe not under Card

        public string description;

        // TODO consider moving this script to an extension for each card type as not relevant for item and spell cards

        public int hitPoints;

        public int defencePoints;

        public int attackPoints;

        // public SummonConditions[] summonConditions;
        // public Spells[] spells;
        // public DemonEffects[] demonEffects;

        // Decision - control sprites here or elsewhere?

        
        // Settings for card display. These can be updated and extened later.
        // TODO further sprite related exploration
        public Color nameColor;
        public Color descriptionColor;

        //public TMP_FontAsset nameFont;
        //public TMP_FontAsset descriptionFont;


        public CardConfigData Copy()
        {
            CardConfigData result = new CardConfigData();

            result.name = name;
            result.alias = alias;
            result.cardType = cardType;
            result.sinType = sinType;
            result.description = description;

            result.hitPoints = hitPoints;
            result.defencePoints = defencePoints;
            result.attackPoints = attackPoints;


            //result.nameFont = nameFont;
            ///result.descriptionFont = descriptionFont;

            result.nameColor = new Color(nameColor.r, nameColor.g, nameColor.b, nameColor.a);
            result.descriptionColor = new Color(descriptionColor.r, descriptionColor.g, descriptionColor.b, descriptionColor.a);

            return result;
        }
        private static Color defaultColor = Color.black;
        //private static TMP_FontAsset defaultFont = ; TODO assign default font elswhere or directly call font from the TMP folder by file location
        public static CardConfigData Default
        {
            get
            {
                CardConfigData result = new CardConfigData();

                result.name = "";
                result.alias = "";
                result.cardType = "";//DataCard.CardType.Text;
                result.sinType = ""; // DataCard.SinType.Text;
                result.description = "";

                result.hitPoints = 0;
                result.defencePoints = 0;
                result.attackPoints = 0;

                //result.nameFont = defaultFont;
                //result.descriptionFont = defaultFont;

                result.nameColor = new Color(defaultColor.r, defaultColor.g, defaultColor.b, defaultColor.a);
                result.descriptionColor = new Color(defaultColor.r, defaultColor.g, defaultColor.b, defaultColor.a);

                return result;
            }
        }
        

    }

}