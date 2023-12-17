using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public List<string> DialogStr;
    private int index;
    public TextGCU textGCU;
    public Font myFont;
    public UnityEvent unityEvent;
    public void Awake()
    {
        DialogStr = new List<string>();
        this.GetComponent<Button>().onClick.AddListener(() => {



            if (textGCU.isActive==false)
            {
                index++;
                if (index > (DialogStr.Count - 1))
                {
                    this.gameObject.SetActive(false);
                }
                else
                {
                    this.transform.GetChild(0).gameObject.SetActive(false);
                    this.transform.GetChild(0).GetComponent<Text>().text = "";
                    this.transform.GetChild(0).GetComponent<Text>().text = (DialogStr[index]);
                    this.transform.GetChild(0).gameObject.SetActive(true);
                }
            }
            else
            {
                textGCU.OnFinish();
            }
            
        });
    }

    public void DialogInit(List<string> strings)
    {
        DialogStr.Clear();
        index = 0;

        // Randomly select one pair of conversation
        int pairIndex = Random.Range(0, 3); // Randomly select 0, 1, or 2
        int startIndex = pairIndex * 2;
        for (int i = startIndex; i < startIndex + 2; i++)
        {
            if (i % 2 == 0)
            {
                DialogStr.Add("Rain: " + strings[i]);
            }
            else
            {
                DialogStr.Add("Willow: " + strings[i]);
            }
        }
        this.transform.GetChild(1).gameObject.SetActive(true);
        this.transform.GetChild(0).gameObject.SetActive(false);
        //
        this.transform.GetChild(0).GetComponent<Text>().font = myFont;
        this.transform.GetChild(0).GetComponent<Text>().text = "";
        this.transform.GetChild(0).GetComponent<Text>().text = (DialogStr[index]);
        this.transform.GetChild(0).gameObject.SetActive(true);
    }

    public GameLogic gameLogic;
    public void OnDisable()
    {
        unityEvent.Invoke();
        gameLogic.ResetNewScene();
    }
}
