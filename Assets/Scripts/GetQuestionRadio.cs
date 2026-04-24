using TMPro;
using UnityEngine;

public class GetQuestionRadio : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public string question;
    
    void Start()
    {
        question = questionText.text;
    }
}
