using UnityEngine;

public class DragnDrop : MonoBehaviour
{
    //This whole thing might need changing for mobile. 
    public bool beingDragged = false;
    private float dragSpeed = 10.0f;
    public string questionAnswer = "";

    public void DragOn()
    {
        beingDragged = !beingDragged;
    }

    void Update()
    {
        if (beingDragged)
        {
            //transform.position = Input.mousePosition;
            transform.position = Vector3.Lerp(transform.position, Input.mousePosition, Time.deltaTime * dragSpeed);
        }
    }
}
