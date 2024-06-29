using Extension;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.UI.Card
{
    public class UICardPlacer : MonoBehaviour
    {
        [SerializeField] UiCardPile uiCardPile;
        //input player card details

        void Update(){
            Debug.Log(uiCardPile.InPlayCards.Length);
        }
    }


    
    

}
