using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using CARD_DATA;

public class DeckSlot : MonoBehaviour
{
    public GameObject root;
    public Image previewImage;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public Button addButton;
    public Button removeButton;
    public Button updateButton;

    [HideInInspector] public int cardNumber = 0;

    public void PopulateDetails(DeckManagerPage.MenuFunction function, CardConfigData card)
    {

        // update from SO instead of filepath
        if (card != null)
        {
            PopulateDetailsFromSO(function, card);
        }
        else
        {
            PopulateDetailsFromSO(function, null);
        }
        
    }

    private void PopulateDetailsFromSO(DeckManagerPage.MenuFunction function, CardConfigData card)// card or card config?
    {
        if (card == null)
        {
            titleText.text = $"{cardNumber}. Empty Slot";
            descriptionText.text = $"Description of Empty Slot for card {cardNumber}";
            removeButton.gameObject.SetActive(false);
            addButton.gameObject.SetActive(false);
            updateButton.gameObject.SetActive(function == DeckManagerPage.MenuFunction.add);
            previewImage.sprite = DeckManagerPage.Instance.emptySlotImage;
        }
        else
        {
            titleText.text = $"{cardNumber}. {card.name}";
            descriptionText.text = @$"Type: {card.cardType}, 
Description: {card.description}
HP: {card.hitPoints}, AP: {card.attackPoints}, DP: {card.defencePoints}, 
Sin: {card.sinType}
        ";
            previewImage.sprite = card.cardSprite;
            removeButton.gameObject.SetActive(true);
            addButton.gameObject.SetActive(function == DeckManagerPage.MenuFunction.remove);
            updateButton.gameObject.SetActive(function == DeckManagerPage.MenuFunction.add);
            previewImage.sprite = card.cardSprite; // any conversion needed?
        }
    }

    public void CardRemove()
    {
        // TODO add confirmation warning
        //File.Delete(filePath);
        //PopulateDetails(SaveAndLoadPage.Instance.menuFunction);
    }

    public void CardAdd()
    {

    }

    public void CardUpdate()
    {

    }


}
