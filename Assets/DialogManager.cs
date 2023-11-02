using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public List<string> DialogStr;
    private int index;

   

    public void Awake()
    {
        DialogStr = new List<string>();
        this.GetComponent<Button>().onClick.AddListener(() => {

            index++;
           
            if (index > (DialogStr.Count-1)) {
                this.gameObject.SetActive(false);
            }
            else
            {
                // this.transform.GetChild(0).GetComponent<TextGCU>().Init(DialogStr[index]);
                this.transform.GetChild(0).gameObject.SetActive(false);
                this.transform.GetChild(0).GetComponent<Text>().text = "";
                this.transform.GetChild(0).GetComponent<Text>().text = (DialogStr[index]);
                this.transform.GetChild(0).gameObject.SetActive(true);

            }

        });
    }
    public void DialogInit(List<string> strings) {
        DialogStr.Clear();
        index = 0;
        for (int i = 0; i < strings.Count; i++) {

            if (i % 2 != 1)
            {
                DialogStr.Add("Me: " + strings[i]);
            }
            else
            {
                DialogStr.Add("GrilFriend: "+ strings[i]);
            }
        }
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(0).GetComponent<Text>().text = "";


        this.transform.GetChild(0).GetComponent<Text>().text = (DialogStr[index]);
        this.transform.GetChild(0).gameObject.SetActive(true);
    }
    
}
