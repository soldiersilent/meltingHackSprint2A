using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace CARD_DATA
{    
    public class DataCardManager : MonoBehaviour
    {
        public const string CARD_NAME_ID ="<cardname>";
        public const string CARD_CASTING_ID = " as ";
        public static DataCardManager instance {get; private set;}

        public DataCard[] allCards => dataCards.Values.ToArray();
        private Dictionary<string, DataCard> dataCards = new Dictionary<string, DataCard>();

        [SerializeField] private CardSystemConfiguration _config;
        public CardSystemConfiguration systemConfig => _config;

        // DEBUG - NEED TO TURN ABOVE OR BELOW CONFIG INTO AN INSTANCE OR GENERALLY SIMPLIFY
        public CardScriptableObjectConfig config => systemConfig.cardConfigurationAsset;

        public string cardPrefabPathFormat => $"{cardRootPathFormat}/{cardPrefabNameFormat}";

        public string cardRootPathFormat => $"Cards/{CARD_NAME_ID}";

        public string cardPrefabNameFormat => $"Cards-({CARD_NAME_ID})";

        // TODO specify panels / rects -> link to existing UI cards

        [SerializeField] private RectTransform _cardPanel = null;
        public RectTransform cardPanel => _cardPanel;

        private void Awake()
        {
            if (instance ==null)
               instance = this;
            else
                DestroyImmediate(gameObject);
        }

        // adapted from a VN character manager - update for our cards
        private CARD_INFO GetCardInfo(string cardName)
        {
            CARD_INFO result = new CARD_INFO();

            result.name = cardName;
            result.config = config.GetConfig(result.castingName);
            result.prefab = GetPrefabForCard(result.castingName);
            result.rootCardFolder = FormatCardPath(cardRootPathFormat, result.castingName);
            return result;
        }

        // todo add create card? Am I recreating existing functions

        // below needs to reference UICARD? Get card info from our card prefab config
        private GameObject GetPrefabForCard(string cardName)
        {
            string prefabPath = FormatCardPath(cardPrefabPathFormat, cardName);
            return Resources.Load<GameObject>(prefabPath);
        }
        public string FormatCardPath(string path, string cardName) => path.Replace(CARD_NAME_ID, cardName);

        private class CARD_INFO
        {
            public string name = "";
            public string castingName = "";
            public string rootCardFolder = "";
            public CardConfigData config = null;

            public GameObject prefab = null;
        }
    }
}