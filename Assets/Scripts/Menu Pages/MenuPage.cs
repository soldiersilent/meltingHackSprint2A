using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPage : MonoBehaviour
{
    public enum PageType {DeckManagerPage}; // TODO add help and config pages
    public PageType pageType;
    private const string OPEN = "Open"; // trigger name set in animation menu
    private const string CLOSE = "Close"; // trigger name set in animation menu
    public Animator anim;

    public virtual void Open()
    {
        anim.SetTrigger(OPEN);
    }

    public virtual void Close(bool closeAllMenus = false)
    {
        anim.SetTrigger(CLOSE);
        if (closeAllMenus)
            CGMenuManager.instance.CloseRoot();
    }
}
