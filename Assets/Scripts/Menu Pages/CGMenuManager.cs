using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using CARD_DATA;

public class CGMenuManager : MonoBehaviour
{
    public static CGMenuManager instance;

    private MenuPage activePage = null;
    private bool isOpen = false;
    [SerializeField] private CanvasGroup root;
    [SerializeField] private MenuPage[] pages;

    private CanvasGroupController rootCG;
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rootCG = new CanvasGroupController(this, root); 
    }

    private MenuPage GetPage(MenuPage.PageType pageType)
    {
        return pages.FirstOrDefault(page => page.pageType == pageType);
    }

    public void OpenDeckManagerPage()
    {
        var page = GetPage(MenuPage.PageType.DeckManagerPage);
        var dm = page.anim.GetComponentInParent<DeckManagerPage>();
        dm.menuFunction = DeckManagerPage.MenuFunction.add;
        OpenPage(page);
        
    }
    private void OpenPage(MenuPage page)
    {
        if (page == null)
            return;
        if (activePage != null && activePage != page)
            activePage.Close();
        
        page.Open();
        activePage = page;

        if (!isOpen)
            OpenRoot();
    }

    public void OpenRoot()
    {
        rootCG.Show();
        rootCG.SetInteractableState(true);
        isOpen = true;
    }

    public void CloseRoot()
    {
        rootCG.Hide();
        rootCG.SetInteractableState(false);
        isOpen = false;
    }

    public void Click_Quit()
    {
        Application.Quit();
    }

    

}
