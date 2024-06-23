using System.Linq;
using Extensions;
using UnityEngine;

namespace Tools.UI.Card
{
    /// <summary>
    ///     Picks a Texture randomly when it Awakes.
    /// </summary>
    public class UiTexturePicker : MonoBehaviour
    {
        [SerializeField] private Sprite[] Sprites;
        [SerializeField] private SpriteRenderer MyRenderer { get; set; }

        private void Awake()
        {
            MyRenderer = GetComponent<SpriteRenderer>();

            // Pick card character sprite

            if (Sprites.Length > 0)
                MyRenderer.sprite = Sprites.ToList()[0];//.RandomItem();
        }
    }
}