using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetQuestionRadio : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public string question;

    void Start()
    {
        question = questionText.text;
    }

    public void DisableChildButtons()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Button>().interactable = false;
        }
    }
}
