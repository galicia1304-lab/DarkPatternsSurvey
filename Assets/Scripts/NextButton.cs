using UnityEngine;
using TMPro;

public class NextButton : MonoBehaviour
{
    public RadioButtons radioAnswer;
    public TMP_InputField inputAnswer;
    public DragnDrop dragAnswer;
    public string customAnswer;
    
    private Animation anim;
    private bool canAnim = true;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void ToggleCanPlay()
    {
        canAnim = !canAnim;
    }

    public void PlayAnimation(AnimationClip clip)
    {
        if (canAnim)
        {
            canAnim = false;
            anim.clip = clip;
            anim.Play();
        }
    }

    public void SaveAnswer()
    {
        string answer = transform.parent.name + ":";
        if (radioAnswer)
        {
            for (int i = 0; i < radioAnswer.selectedInfo.Length; i++)
            {
                answer += " - " + radioAnswer.selectedInfo[i];
            }
            answer += ". ";
        }
        if (inputAnswer)
        {
            answer += inputAnswer.text + " ";
        }
        if (dragAnswer)
        {
            answer += dragAnswer.questionAnswer + " ";
        }
        if (customAnswer != "")
        {
            answer += customAnswer + " ";
        }
        transform.root.GetComponent<PageController>().answers += answer;
    }
}
