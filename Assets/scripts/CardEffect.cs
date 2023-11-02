using UnityEngine;
using Cards;

public class CardEffect : MonoBehaviour
{
    public CardData cardData;
    public GameLogic gameLogic;

    public void ApplyEffects()
    {
        gameLogic.IncreaseFeeling(cardData.feelingChange);
        gameLogic.IncreaseEmpathy(cardData.empathyChange);
    }
}



