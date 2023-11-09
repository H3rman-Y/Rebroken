using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(menuName = "Cards/Card Data")]
    public class CardData : ScriptableObject
    {
        public string description = "null";
        public int feelingChange = 0;
        public int empathyChange = 0;
        public List<string> Dialogs=new List<string>();
        public string description2 = "null";
    }
}
