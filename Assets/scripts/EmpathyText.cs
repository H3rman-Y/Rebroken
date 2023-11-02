using UnityEngine;
using UnityEngine.UI;

public class EmpathyText : MonoBehaviour
{
    public Text empathyText;
    private int empathy = 5;

    void Start()
    {
        empathyText.text = "Empathy: " + empathy;
    }

    public void UpdateEmpathy(int amount)
    {
        empathy += amount;
        empathyText.text = "Empathy: " + empathy;
    }
}
