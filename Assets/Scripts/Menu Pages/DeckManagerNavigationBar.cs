using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CARD_DATA;

public class DeckManagerNavigationBar : MonoBehaviour
{

    [SerializeField] private DeckManagerPage menu;

    private CardConfigData[] allCards => DataCardManager.instance.config.cards;//TODO replace with individual decks selectable and saveable

    private bool initialized = false;

    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject previousButton;
    [SerializeField] private GameObject nextButton;
    private const int MAX_BUTTONS = 5;
    public int selectedPage {get ; private set;} = 1;

    private int maxPages = 0;

    // Start is called before the first frame update
    void Start()
    {
        

        foreach (var card in allCards)
        {
            Debug.Log($"{card.name}");
        }

        InitializeMenu();
        
    }
    private void InitializeMenu()
    {
        if(initialized)
            return;
        initialized = true;

        maxPages = Mathf.CeilToInt((float)DeckManagerPage.MAX_CARDS / menu.slotsPerPage);

        int pageButtonLimit = MAX_BUTTONS < maxPages? MAX_BUTTONS :maxPages;

        for (int i =1; i <= pageButtonLimit; i++)
        {
            GameObject ob = Instantiate(buttonPrefab.gameObject, buttonPrefab.transform.parent);
            ob.SetActive(true);

            Button button = ob.GetComponent<Button>(); 

            ob.name = i.ToString();
            TextMeshProUGUI txt = button.GetComponentInChildren<TextMeshProUGUI>();
            txt.text = i.ToString();
            int closureIndex = i;
            button.onClick.AddListener(()=> SelectDeckPage(closureIndex));
        }

        previousButton.SetActive(pageButtonLimit <= maxPages);
        nextButton.SetActive(pageButtonLimit <= maxPages);
            
    }

    private void SelectDeckPage(int pageNumber)
    {
        selectedPage = pageNumber;
        menu.PopulateDeckSlotsForPage(pageNumber, allCards); // TODO update to use a selectable DeckCards variable

        nextButton.transform.SetAsLastSibling();
    }

    public void ToNextPage()
    {
        if (selectedPage < maxPages)
            SelectDeckPage(selectedPage + 1);

    }

    public void ToPreviousPage()
    {
        if (selectedPage > 1)
            SelectDeckPage(selectedPage - 1);

    }
    

}