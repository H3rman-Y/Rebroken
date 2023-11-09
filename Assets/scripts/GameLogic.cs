using UnityEngine;
using UnityEngine.UI;
using Cards;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public Slider feelingSlider;
    public Slider empathySlider;
    public Text feelingText;
    public Text empathyText;
    private int feeling = 5;
    private int empathy = 5;

    public List<CardData> cardDatas;

    private List<CardData> cardDatasProxy;

    public GameObject CardPrefab;

    public Transform CardParent;

   
    public GameObject EndPanel;
    public Button ReStartBtn;
    
    private void Awake()
    {
        cardDatasProxy = new List<CardData>();
        EndPanel.SetActive(false);
        UpdateUI();
        DataInit();
        //回合开始
        ResetNewScene();
        ReStartBtn.onClick.AddListener(()=> {
            SceneManager.LoadScene(0);
        });
    }

    public List<Vector3> vector3s;

    public void ResetNewScene() {
        if (CardParent.childCount>0) return;
        if (cardDatasProxy.Count <= 0) return;
        for (int i = 0; i < 3; i++)
        {
            GameObject card = GameObject.Instantiate(CardPrefab, CardParent);
            card.GetComponent<CardDataInit>().gameLogic = this;
            card.GetComponent<CardDataInit>().MarkPoss = vector3s[i];
            card.GetComponent<CardDataInit>().MarkName = "MarkPos" + i.ToString() ;
            card.GetComponent<CardDataInit>().Init(cardDatasProxy[0]);
            cardDatasProxy.RemoveAt(0);
        }
       
    }

    public void DataInit() {
        cardDatasProxy.Clear();
        for (int i = 0; i < cardDatas.Count; i++)
        {
            cardDatasProxy.Add(cardDatas[i]);
        }
        //乱序
        Outoforder(cardDatasProxy);
    }

    public void UpdateUI()
    {
        feelingSlider.value =feeling;
        empathySlider.value =empathy;
        feelingText.text = "Feeling:                                         " + feeling.ToString();
        empathyText.text = "Empathy:                                         " + empathy.ToString();
    }

    public void IncreaseFeeling(int amount)
    {
        feeling += amount;
        UpdateUI();
    }

    public void IncreaseEmpathy(int amount)
    {
        empathy += amount;
        UpdateUI();
    }

    void CheckGameOver()
    {
        if (feeling >= 10 || feeling <= 0 || empathy >= 10 || empathy <= 0)
        {
            Debug.Log("Game Over");
            EndPanel.SetActive(true);
        }
    }
    public void ApplyEffects(CardData cardData)
    {
        IncreaseFeeling(cardData.feelingChange);
        IncreaseEmpathy(cardData.empathyChange);
        CheckGameOver();
        if (cardDatasProxy.Count <= 0) {
            // "EnDPanel";
            EndPanel.SetActive(true);
        }
    }

    public List<T> Outoforder<T>(List<T> bag)
    {
        Random randomNum = new Random();
        int index = 0;
        T temp;
        for (int i = 0; i < bag.Count; i++)
        {
            index = randomNum.Next(0, bag.Count - 1);
            if (index != i)
            {
                temp = bag[i];
                bag[i] = bag[index];
                bag[index] = temp;
            }
        }
        return bag;
    }


    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}



