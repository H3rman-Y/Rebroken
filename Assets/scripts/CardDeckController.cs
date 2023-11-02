using UnityEngine;
using System.Collections.Generic;
using Cards;

public class CardDeckController : MonoBehaviour
{
    public GameLogic gameLogic;
    public GameObject cardContainer; // Reference to the container for drawn cards.

    private List<GameObject> currentCards = new List<GameObject>();

    void Start()
    {
        DrawInitialCards();
    }

    public void DrawInitialCards()
    {
        DrawCards();
    }

    public void DrawCards()
    {
        DiscardCurrentCards();

        for (int i = 0; i < cardContainer.transform.childCount; i++)
        {
            // Get the card prefab from the children of the cardContainer.
            GameObject newCard = cardContainer.transform.GetChild(i).gameObject;

            // Ensure the CardClickHandler and CardEffect components are attached.
            CardClickHandler clickHandler = newCard.GetComponent<CardClickHandler>();
            CardEffect effect = newCard.GetComponent<CardEffect>();

            if (clickHandler != null && effect != null)
            {
                // Access the CardData script directly from the card prefab.
                CardData cardData = newCard.GetComponent<CardData>();

                // Attach the gameLogic reference.
                clickHandler.gameLogic = gameLogic;
                effect.gameLogic = gameLogic;

                currentCards.Add(newCard);
            }
            else
            {
                Debug.LogError("CardClickHandler and/or CardEffect components not found on card prefab.");
            }
        }
    }



    void DiscardCurrentCards()
    {
        foreach (GameObject card in currentCards)
        {
            Destroy(card);
        }
        currentCards.Clear();
    }
}
