using UnityEngine;
using UnityEngine.UI;

public class PageController : MonoBehaviour
{

    public Image blackoutFader;
    public float fadeSpeed = 1.0f;
    public Transform battery;
    public string iconName = "";
    public GameObject[] pages;
    public string answers = "";

    private float batteryAmount = 0.0f;
    private int pageIndex = 0;
    private GameObject currentPage;
    private bool faderOn = false;
    private float blackoutTimer = 0.0f;
    private float blackoutTimerWait = 1.1f;
    private GameObject nextPage;
    private GameObject disablePage;
    private bool canChangePage = false;

    private void Start()
    {
        currentPage = pages[0];
        batteryAmount = 1.0f / pages.Length;
        Battery();
    }

    public void NextPage() 
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if (pages[i] == currentPage)
            {
                nextPage = pages[i + 1];
                pageIndex = i + 1;
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
        batteryAmount = (1.0f / pages.Length) * (pageIndex +1);
        Battery();
        nextPage.SetActive(true);
        currentPage = nextPage;
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

    private void Battery()
    {
        Vector3 batterySize = battery.localScale;
        batterySize.x = batteryAmount;
        battery.localScale = batterySize;
    }
}
