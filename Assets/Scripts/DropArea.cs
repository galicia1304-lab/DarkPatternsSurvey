using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropArea : MonoBehaviour
{
    public NextButton nextButton;

    private AnimationClip clip;

    private void Start()
    {
        clip = nextButton.GetComponent<Animation>().clip;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("DragObj"))
        {
            if (collision.GetComponent<DragnDrop>().beingDragged)
            {
                return;
            }
            else
            {
                collision.transform.position = transform.position;
                nextButton.PlayAnimation(clip);
                //send answer here
                collision.GetComponent<DragnDrop>().questionAnswer = collision.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text + " : " + gameObject.name;
            }
        }
    }
}
