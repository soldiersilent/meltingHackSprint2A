﻿using Extensions;
using System;
using UnityEngine;

namespace Tools.UI.Card
{
    //------------------------------------------------------------------------------------------------------------------

    /// <summary>
    ///     Card Hand holds a register of cards.
    /// </summary>
    public class UiCardHand : UiCardPile, IUiCardHand
    {
        //--------------------------------------------------------------------------------------------------------------

        #region Properties

        /// <summary>
        ///      Card currently selected by the player.
        /// </summary>
        public IUiCard SelectedCard { get; private set; }


        private event Action<IUiCard> OnCardSelected = card => { };

        private event Action<IUiCard> OnCardPlayed = card => { };

        /// <summary>
        ///  musashi edited code - event when card is placed
        /// </summary>
        private event Action<IUiCard> OnCardPlaced = card => { };

        /// <summary>
        ///     Event raised when a card is played.
        /// </summary>
        Action<IUiCard> IUiCardHand.OnCardPlayed { get => OnCardPlayed; set => OnCardPlayed = value; }

        /// <summary>
        /// musashi-code event raised when a card is placed
        /// </summary>
        Action<IUiCard> IUiCardHand.OnCardPlaced {get => OnCardPlaced; set => OnCardPlaced = value;}

        /// <summary>
        ///     Event raised when a card is selected.
        /// </summary>
        Action<IUiCard> IUiCardHand.OnCardSelected{ get => OnCardSelected; set => OnCardSelected = value; }
        #endregion
        //--------------------------------------------------------------------------------------------------------------
        #region Operations
        /// <summary>
        ///     Select the card in the parameter.
        /// </summary>
        /// <param name="card"></param>
        public void SelectCard(IUiCard card)
        {
            SelectedCard = card ?? throw new ArgumentNullException("Null is not a valid argument.");
            //disable all cards
            DisableCards();
            NotifyCardSelected();
        }
        /// <summary>
        ///     Play the card which is currently selected. Nothing happens if current is null.
        /// </summary>
        /// <param name="card"></param>
        public void PlaySelected()
        {
            if (SelectedCard == null)
                return;
            PlayCard(SelectedCard);
        }
        /// <summary>
        ///     Play the card in the parameter.
        /// </summary>
        /// <param name="card"></param>
        public void PlayCard(IUiCard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");
            SelectedCard = null;
            RemoveCard(card);
            OnCardPlayed?.Invoke(card);
            EnableCards();
            NotifyPileChange();
        }
        /// <summary>
        /// musashi - Play the card that is currently selected. Nothing happens if current is null.
        /// </summary>
        /// <param name="card"></param>

        public void PlaceSelected(){
            if (SelectedCard==null){
                return;
            }
            PlaceCard(SelectedCard);

        }

        /// <summary>
        /// musashi- Place the Card in the parameter
        /// </summary>
        /// <param name="card"></param>
        /// <exception cref="ArgumentNullException"></exception>

        public void PlaceCard(IUiCard card){
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            SelectedCard = null;
            AddCardToField(card);
            OnCardPlaced?.Invoke(card);
            Unselect();
            EnableCards();
            NotifyPileChange();


            //TO-DO edit the variables that need to be changed when the card is placed down
        }

        /// <summary>
        ///    Unselect the card in the parameter.
        /// </summary>
        /// <param name="card"></param>
        public void UnselectCard(IUiCard card)
        {
            if (card == null)
                return;

            SelectedCard = null;
            card.Unselect();
            NotifyPileChange();
            EnableCards();
        }

        /// <summary>
        ///     Unselect the card which is currently selected. Nothing happens if current is null.
        /// </summary>
        public void Unselect()
        {
            UnselectCard(SelectedCard);
        }

        /// <summary>
        ///     Disables input for all cards.
        /// </summary>
        public void DisableCards()
        {
            foreach (var otherCard in Cards)
                otherCard.Disable();
        }

        /// <summary>
        ///     Enables input for all cards.
        /// </summary>
        public void EnableCards()
        {
            foreach (var otherCard in Cards)
                otherCard.Enable();
        }

        [Button]
        private void NotifyCardSelected()
        {
            OnCardSelected?.Invoke(SelectedCard);
        }

        #endregion
    }
}