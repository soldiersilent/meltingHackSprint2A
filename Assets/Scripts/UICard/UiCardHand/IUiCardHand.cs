using System;

namespace Tools.UI.Card
{
    public interface IUiCardHand : IUiCardPile
    {
        void PlaySelected();
        void PlaceSelected();
        void Unselect();
        void PlayCard(IUiCard uiCard);
        void PlaceCard(IUiCard uiCard);
        void SelectCard(IUiCard uiCard);
        void UnselectCard(IUiCard uiCard);
        Action<IUiCard> OnCardPlayed { get; set; }
        Action<IUiCard> OnCardPlaced {get; set;}
        Action<IUiCard> OnCardSelected { get; set; }
    }
}