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
            
            int amountOfCards = uiCardPile.InPlayCards.Count;
            Debug.Log (amountOfCards);
            for (int i = 0; i < amountOfCards; i++) {
                //generate each card inside InPlayCard
            }
        }
    }


    
    

}
