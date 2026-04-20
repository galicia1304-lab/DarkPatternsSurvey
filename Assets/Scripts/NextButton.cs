using UnityEngine;

public class NextButton : MonoBehaviour
{
    private Animation anim;
    private bool canAnim = true;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void PlayAnimation()
    {
        if (canAnim)
        {
            canAnim = false;
            anim.Play();
        }
    }
}
