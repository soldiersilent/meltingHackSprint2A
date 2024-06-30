using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CARD_DATA;
using UnityEngine.UI;
public class DeckManagerPage : MenuPage
{

    public static DeckManagerPage Instance {get; private set;}

    private CardConfigData[]  allCards => DataCardManager.instance.config.cards;//TODO replace with individual decks

    public const int MAX_CARDS = 99;
    private int currentPage = 1;

    public enum MenuFunction {add, remove, update}
    private bool loadedCardsForFirstTime = false;

    public MenuFunction menuFunction = MenuFunction.add;

    public DeckSlot[] deckSlots;
    public int slotsPerPage => deckSlots.Length;

    public Sprite emptySlotImage;

    private void Awake()
    {
        Instance = this;

        foreach (var card in allCards)
        {
            Debug.Log($"{card.name}");
        }
    }

    public override void Open()
    {
        base.Open();
        //if (!loadedCardsForFirstTime)
        //Debug.Log($"{allCards.Length}");
        PopulateDeckSlotsForPage(currentPage, allCards); // todo replace with being able to choose different stored decks
    }

    public void PopulateDeckSlotsForPage(int pageNumber, CardConfigData[] deckCards)
    {
        currentPage = pageNumber;
        int startingCard = ((currentPage - 1) * slotsPerPage) + 1;
        int endingCard =  startingCard + slotsPerPage - 1;

        for (int i = 0; i< slotsPerPage; i++)
        {
            int cardNum = startingCard + i;
            DeckSlot slot = deckSlots[i];
            
            if (cardNum < MAX_CARDS && cardNum <= deckCards.Length)
            {
                CardConfigData card = deckCards[startingCard + i];
                slot.root.SetActive(true);
    
                slot.cardNumber = cardNum;
                slot.PopulateDetails(menuFunction, card);
            }
            else
            {
                slot.root.SetActive(false);
            }
        }
    }
}
