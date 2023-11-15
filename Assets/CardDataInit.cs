
//using Cards;
//using DG.Tweening;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

//public class CardDataInit : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
//{
//    public GameLogic gameLogic;
//    public Text empathyText; // Reference this in the Inspector
//    public Text feelingText; // Reference this in the Inspector
//    public Text descriptionText; // Reference this in the Inspector
//    public Text descriptionText2;
//    public  Vector3 MarkPoss;
//    private Vector3 initPos = new Vector3(-797,-50,0);
//    private DialogManager dialogManager;
//    private bool isDone;
//    // Start is called before the first frame update
//    public void Init(CardData cardData)
//    {
//        empathyText.text = "";
//        feelingText.text = "";
//        //empathyText.text = "Empathy: " + cardData.empathyChange;
//        //feelingText.text = "Feeling: " + cardData.feelingChange;
//        descriptionText.text = cardData.description;
//        descriptionText2.text = cardData.description2;
//        dialogManager = this.transform.parent.parent.Find("DialogManager").GetComponent<DialogManager>();

//        this.transform.GetChild(2). GetComponent<Button>().onClick.AddListener(() => {
//            gameLogic.ApplyEffects(cardData);
//            for (int i = 0; i < this.transform.parent.childCount; i++)
//            {
//                Destroy(this.transform.parent.GetChild(i).gameObject);
//            }
//            //dakai duihua 
//            dialogManager.gameObject.SetActive(true);
//            dialogManager.DialogInit(cardData.Dialogs);
//        });
//        this.GetComponent<RectTransform>().DOAnchorPos(MarkPoss, 0.5f);
//        isDone = false;
//    }
//    public void ShowDialog(CardData cardData)
//    {
//        // Check if there's dialogue content and display it
//        if (cardData.Dialogs.Count > 0)
//        {
//            int randomIndex = Random.Range(0, cardData.Dialogs.Count);

//            Debug.Log("Dialog displayed: " + cardData.Dialogs[randomIndex]);
//        }
//        else
//        {

//            Debug.Log("No dialog available for this card.");
//        }

//        // 激活 DialogCanvas 对象
//        GameObject dialogCanvas = GameObject.Find("DialogCanvas");
//        dialogCanvas.SetActive(true);
//        if (dialogCanvas != null)
//        {
//            dialogCanvas.SetActive(true);
//            Debug.Log("DialogCanvas activated.");
//        }
//        else
//        {
//            Debug.LogError("DialogCanvas not found in the Hierarchy.");
//        }
//    }

//    #region Drug
//    [Header("是否精准拖拽")]
//    public bool m_isPrecision;
//    private Vector3 m_offset;
//    private RectTransform m_rt;
//    public string MarkName;
//    private void Start()
//    {
//        MarkPos = GameObject.Find(MarkName).transform;
//        m_rt = gameObject.GetComponent<RectTransform>();
//    }
//    #endregion
//     //开始拖拽触发
//     public void OnBeginDrag(PointerEventData eventData)
//     {
//        if (isDone == true) return;

//        this.transform.DOScale(Vector3.one*1.1f,0.3f);
//        this.transform.GetChild(0).gameObject.SetActive(true);
//         //如果精确拖拽则进行计算偏移量操作
//         if (m_isPrecision)
//         {
//             // 存储点击时的鼠标坐标
//             Vector3 tWorldPos;
//             //UI屏幕坐标转换为世界坐标
//             RectTransformUtility.ScreenPointToWorldPointInRectangle(m_rt, eventData.position, eventData.pressEventCamera, out tWorldPos);
//             //计算偏移量   
//             m_offset = transform.position - tWorldPos;
//         }
//             //否则，默认偏移量为0
//         else
//         {
//             m_offset = Vector3.zero;
//         }

//         SetDraggedPosition(eventData);
//     }

//     //拖拽过程中触发
//     public void OnDrag(PointerEventData eventData)
//     {
//        if (isDone == true) return;

//        SetDraggedPosition(eventData);
//     }

//    public Transform MarkPos;
//     //结束拖拽触发
//     public void OnEndDrag(PointerEventData eventData)
//     {
//        if (isDone == true) return;

//        this.transform.GetChild(0).gameObject.SetActive(false);
//        this.transform.DOScale(Vector3.one * 1f, 0.3f);

//        //拖拽道目的地开始翻牌
//        //
//        print(Vector2.Distance(eventData.position, MarkPos.position));
//        if (Vector2.Distance(eventData.position, MarkPos.position)<10)
//        {
//            this.GetComponent<Transform>().DOMove(MarkPos.position, 0.5f).OnComplete(()=> {
//                this.transform.GetChild(1).DOScale(new Vector3(0,1,1),0.5f);
//                this.transform.GetChild(2).DOScale(new Vector3(1, 1, 1), 0.5f).OnComplete(()=> {
//                    //开始弹出对话框
//                    isDone = true;
//                }); ;
//            }) ;
//        }
//        else
//        {
//            this.GetComponent<RectTransform>().DOAnchorPos(MarkPoss, 0.5f);
//        }
//    }

//    public void OnMouseExit()
//    {
//        if (isDone == true) return;

//        this.transform.GetChild(0).gameObject.SetActive(false);
//        this.transform.DOScale(Vector3.one * 1f, 0.3f);

//    }

//    public void OnMouseEnter()
//    {
//        if (isDone == true) return;

//        this.transform.DOScale(Vector3.one * 1.1f, 0.3f);
//        this.transform.GetChild(0).gameObject.SetActive(true);
//    }
//    /// <summary>
//    /// 设置图片位置方法
//    /// </summary>
//    /// <param name="eventData"></param>
//    private void SetDraggedPosition(PointerEventData eventData)
//     {
//         //存储当前鼠标所在位置
//         Vector3 globalMousePos;
//         //UI屏幕坐标转换为世界坐标
//         if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_rt, eventData.position, eventData.pressEventCamera, out globalMousePos))
//         {
//             //设置位置及偏移量
//             m_rt.position = globalMousePos + m_offset;
//         }
//     }
// }
using Cards;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDataInit : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameLogic gameLogic;
    public Text empathyText; // Reference this in the Inspector
    public Text feelingText; // Reference this in the Inspector
    public Text descriptionText; // Reference this in the Inspector
    public Text descriptionText2;
    public Vector3 MarkPoss;
    private Vector3 initPos = new Vector3(-797, -50, 0);
    private DialogManager dialogManager;
    private bool isDone;
    private Vector3 startPosition;
    public Font myFont;
    // Start is called before the first frame update

    public void Init(CardData cardData)
    {
        empathyText.text = "";
        feelingText.text = "";
        //empathyText.text = "Empathy: " + cardData.empathyChange;
        //feelingText.text = "Feeling: " + cardData.feelingChange;
        descriptionText.font = myFont;
        descriptionText2.font = myFont;
        descriptionText.text = cardData.description;
        descriptionText2.text = cardData.description2;
        dialogManager = this.transform.parent.parent.Find("DialogManager").GetComponent<DialogManager>();

        this.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => {
            gameLogic.ApplyEffects(cardData);
            for (int i = 0; i < this.transform.parent.childCount; i++)
            {
                Destroy(this.transform.parent.GetChild(i).gameObject);
            }
            //dakai duihua 
            dialogManager.gameObject.SetActive(true);
            dialogManager.DialogInit(cardData.Dialogs);
        });
        this.GetComponent<RectTransform>().DOAnchorPos(MarkPoss, 0.5f);
        isDone = false;
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

        // 激活 DialogCanvas 对象
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

    #region Drug
    [Header("是否精准拖拽")]
    public bool m_isPrecision;
    private Vector3 m_offset;
    private RectTransform m_rt;
    public string MarkName;
    private void Start()
    {
        MarkPos = GameObject.Find(MarkName).transform;
        m_rt = gameObject.GetComponent<RectTransform>();
    }
    #endregion
    //开始拖拽触发
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isDone == true) return;

        this.transform.DOScale(Vector3.one * 1.1f, 0.3f);
        this.transform.GetChild(0).gameObject.SetActive(true);
        //如果精确拖拽则进行计算偏移量操作
        if (m_isPrecision)
        {
            // 存储点击时的鼠标坐标
            Vector3 tWorldPos;
            //UI屏幕坐标转换为世界坐标
            RectTransformUtility.ScreenPointToWorldPointInRectangle(m_rt, eventData.position, eventData.pressEventCamera, out tWorldPos);
            //计算偏移量   
            m_offset = transform.position - tWorldPos;
        }
        //否则，默认偏移量为0
        else
        {
            m_offset = Vector3.zero;
        }

        SetDraggedPosition(eventData);
    }



    //拖拽过程中触发
    public void OnDrag(PointerEventData eventData)
    {
        if (isDone == true) return;

        SetDraggedPosition(eventData);
    }

    public Transform MarkPos;

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDone == true) return;

        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.DOScale(Vector3.one * 1f, 0.3f);

        // 获取卡片的 RectTransform
        RectTransform cardRect = this.GetComponent<RectTransform>();

        // 判定范围的矩形框，可以根据需求调整大小
        Rect dropArea = new Rect(MarkPos.position.x - 50, MarkPos.position.y - 50, 100, 100);

        // 判断鼠标位置是否在判定范围内
        if (RectTransformUtility.RectangleContainsScreenPoint(cardRect, eventData.position, eventData.pressEventCamera) &&
            dropArea.Contains(eventData.position))
        {
            this.GetComponent<Transform>().DOMove(MarkPos.position, 0.5f).OnComplete(() =>
            {
                this.transform.GetChild(1).DOScale(new Vector3(0, 1, 1), 0.5f);
                this.transform.GetChild(2).DOScale(new Vector3(1, 1, 1), 0.5f).OnComplete(() =>
                {
                    //开始弹出对话框
                    isDone = true;
                }); ;
            });
        }
        else
        {
            this.GetComponent<RectTransform>().DOAnchorPos(MarkPoss, 0.5f);
        }
    }

    public void OnMouseExit()
    {
        if (isDone == true) return;

        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.DOScale(Vector3.one * 1f, 0.3f);

    }

    public void OnMouseEnter()
    {
        if (isDone == true) return;

        this.transform.DOScale(Vector3.one * 1.1f, 0.3f);
        this.transform.GetChild(0).gameObject.SetActive(true);
    }
    /// <summary>
    /// 设置图片位置方法
    /// </summary>
    /// <param name="eventData"></param>
    private void SetDraggedPosition(PointerEventData eventData)
    {
        //存储当前鼠标所在位置
        Vector3 globalMousePos;
        //UI屏幕坐标转换为世界坐标
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_rt, eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            //设置位置及偏移量
            m_rt.position = globalMousePos + m_offset;
        }
    }
}




