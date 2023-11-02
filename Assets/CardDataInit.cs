//using Cards;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class CardDataInit : MonoBehaviour
//{
//    public GameLogic gameLogic;
//    // Start is called before the first frame update
//    public void Init(CardData cardData)
//    {
//        this.transform.GetChild(1).GetComponent<Text>().text = "Empathy:" + cardData.empathyChange;
//        this.transform.GetChild(2).GetComponent<Text>().text = "Feeling:" + cardData.feelingChange;
//        this.GetComponent<Button>().onClick.AddListener(() => {
//            gameLogic.ApplyEffects(cardData);
//            for (int i = 0; i < this.transform.parent.childCount; i++)
//            {
//                Destroy(this.transform.parent.GetChild(i).gameObject);
//            }
//        });
//    }
//}
using Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDataInit : MonoBehaviour
{
    public GameLogic gameLogic;
    public Text empathyText; // Reference this in the Inspector
    public Text feelingText; // Reference this in the Inspector
    public Text descriptionText; // Reference this in the Inspector

    private DialogManager dialogManager;
    // Start is called before the first frame update
    public void Init(CardData cardData)
    {
        empathyText.text = "Empathy: " + cardData.empathyChange;
        feelingText.text = "Feeling: " + cardData.feelingChange;
        descriptionText.text = cardData.description;
        dialogManager = this.transform.parent.parent.Find("DialogManager").GetComponent<DialogManager>();
        this.GetComponent<Button>().onClick.AddListener(() => {
            gameLogic.ApplyEffects(cardData);
            for (int i = 0; i < this.transform.parent.childCount; i++)
            {
                Destroy(this.transform.parent.GetChild(i).gameObject);
            }
            //dakai duihua 
            dialogManager.gameObject.SetActive(true);
            dialogManager.DialogInit(cardData.Dialogs);
        });
      
    }
    public void ShowDialog(CardData cardData)
    {
        // Check if there's dialogue content and display it
        if (cardData.Dialogs.Count > 0)
        {
            int randomIndex = Random.Range(0, cardData.Dialogs.Count);
           
            Debug.Log("Dialog displayed: " + cardData.Dialogs[randomIndex]);
        }
        else
        {
          
            Debug.Log("No dialog available for this card.");
        }

        // º§ªÓ DialogCanvas ∂‘œÛ
        GameObject dialogCanvas = GameObject.Find("DialogCanvas");
        dialogCanvas.SetActive(true);
        if (dialogCanvas != null)
        {
            dialogCanvas.SetActive(true);
            Debug.Log("DialogCanvas activated.");
        }
        else
        {
            Debug.LogError("DialogCanvas not found in the Hierarchy.");
        }
    }

}

