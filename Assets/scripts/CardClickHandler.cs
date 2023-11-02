using UnityEngine;
using Cards;

public class CardClickHandler : MonoBehaviour
{
    public CardData cardData;
    public GameLogic gameLogic;

    private void OnMouseDown()
    {
        gameLogic.ApplyEffects(cardData);
    }
}
