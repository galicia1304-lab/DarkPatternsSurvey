using UnityEngine;
using UnityEngine.UI;

public class PageController : MonoBehaviour
{

    public Image blackoutFader;
    public float fadeSpeed = 1.0f;

    public string iconName = "";
    public GameObject[] pages;

    private bool faderOn = false;
    private float blackoutTimer = 0.0f;
    private float blackoutTimerWait = 1.1f;
    private GameObject nextPage;
    private GameObject disablePage;
    private bool canChangePage = false;

    public void NextPage(GameObject currentPage) 
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if (pages[i] == currentPage)
            {
                nextPage = pages[i + 1];
                faderOn = true;
                disablePage = currentPage;
                canChangePage = true;
                break;
            }
        }
    }

    void ChangePages()
    {
        disablePage.SetActive(false);
        nextPage.SetActive(true);
    }

    private void Update()
    {
        if (faderOn)
        {
            blackoutTimer += Time.deltaTime;
            if (blackoutTimer < blackoutTimerWait)
            {
                Color newCol = blackoutFader.color;
                newCol.a += Time.deltaTime * fadeSpeed;
                blackoutFader.color = newCol;
            }
            else if (blackoutTimer > blackoutTimerWait)
            {
                if (canChangePage)
                {
                    ChangePages();
                    canChangePage = false;
                }
                Color newCol = blackoutFader.color;
                newCol.a -= Time.deltaTime * fadeSpeed;
                blackoutFader.color = newCol;
                if (blackoutTimer > blackoutTimerWait*2)
                {
                    faderOn = false;
                    blackoutTimer = 0.0f;
                }
            }
        }
    }
}
