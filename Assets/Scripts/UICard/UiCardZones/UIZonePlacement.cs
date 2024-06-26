using UnityEngine.EventSystems;

namespace Tools.UI.Card{
    /// <summary>
    /// musashi-made
    /// place card in zone
    /// </summary>
    public class UIZonePlacement : UiBaseDropZone
    {
        protected override void OnPointerUp(PointerEventData eventData)
        {
            CardHand?.PlaceSelected();
        }
    }
}


