using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CARD_DATA
{
    // [System.Serializable]
    public class DataDeck
    {
        // instance of decks to create

        // TODO - enable making multiple S.O. or other repeatable object so we can save decks
        // have player deck, have opponent deck, explore and persist these


        public List<DataCard> deckCards = new List<DataCard>();

        //private static Random rng = new Random();

        private System.Random rng = new System.Random();

        public DataDeck()//string deckName, List<DataCard> deckCards)
        {
            // TODO create deck based on prefabs / SO?
        }
        public void AddCardToDeck(DataCard card, DataDeck deck)
        {
            // permanent add
            deck.deckCards.Add(card);

        }

        public void RemoveCardFromDeck(DataCard card, DataDeck deck)
        {

            // permanent remove

            deck.deckCards.Remove(card);

        }

        

        public void ShuffleDeck(DataDeck deck, System.Random rng)
        {
            // randomise order of cards

            List<DataCard> cardList = new List<DataCard>();

            // TODO use Coroutine to prevent interruption
            if (deck.deckCards != null)
            {
                cardList = deck.deckCards;
                int n = cardList.Count;
                while (n>1)
                {
                    n --;
                    int k = rng.Next(n+1);
                    DataCard card = cardList[k];
                    cardList[k] = cardList[n];
                    cardList[n] = card;
                }
                deck.deckCards = cardList;
            }
            else
                return;
        }

        public void DrawCard()
        {
            // review existing Draw
        }

        public void ReplaceCard()
        {

            // review existing replace or add funct
        }
    }
}