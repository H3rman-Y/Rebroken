using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextGCU : MonoBehaviour
{
    //���ֵ�ʱ����
    public float TimeInterval = 0.3f;
    private string words;//������Ҫ��ʾ������
    public bool isActive = false;
    private float timer;//ʱ���ʱ
    private Text myText;
    private int currentPos = 0;//��ǰ����λ��
    void OnEnable()
    {
        timer = 0;
        isActive = true;
        TimeInterval = Mathf.Max(0.04f, TimeInterval);
        myText = GetComponent<Text>();
        words = myText.text;
        currentPos = 0;
        //��ȡText���ı���Ϣ�����浽words�У�Ȼ��̬�����ı���ʾ���ݣ�ʵ�ִ��ֻ���Ч��
        myText.text = "";
    }

    void Update()
    {
        OnStartWriter();
    }

    public void StartEffect()
    {
        isActive = true;
    }
    /// <summary>
    /// ��ʼ����
    /// </summary>
    void OnStartWriter()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= TimeInterval)
            {
                //�жϼ�ʱ��ʱ���Ƿ����
                timer = 0;
                currentPos++;
                myText.text = words.Substring(0, currentPos);//ˢ����ʾ����

                if (currentPos >= words.Length)
                {
                    OnFinish();
                }
            }
        }
    }

    /// <summary>
    /// �������֣���ʼ������
    /// </summary>
    public void OnFinish()
    {
        isActive = false;
        timer = 0;
        currentPos = 0;
        myText.text = words;
    }
}
