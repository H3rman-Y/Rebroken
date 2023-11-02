using UnityEngine;
using UnityEngine.UI;

public class FeelingText : MonoBehaviour
{
    public Text feelingText;
    private int feeling = 5;

    void Start()
    {
        feelingText.text = "Feeling: " + feeling;
    }

    public void UpdateFeeling(int amount)
    {
        feeling += amount;
        feelingText.text = "Feeling: " + feeling;
    }
}
