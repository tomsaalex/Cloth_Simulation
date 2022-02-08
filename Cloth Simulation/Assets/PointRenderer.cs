using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointRenderer : MonoBehaviour
{
    public Point relatedPoint;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager");
    }

    void DetectMiddleSelection()
    {
        if (!Input.GetMouseButtonDown(2))
            return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider == null)
            return;

        if (hit.collider.gameObject != this.gameObject)
            return;

        this.relatedPoint.locked = !this.relatedPoint.locked;
        this.GetComponent<SpriteRenderer>().color = PointColorSelector.SelectPointColor(this.relatedPoint);
    }

    void DetectRightSelection()
    {
        if (!Input.GetMouseButtonDown(1))
            return;
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider == null)
            return;
            
        if (hit.collider.gameObject != this.gameObject)
            return;
        if (StickSpawner.tempStick.A == null)
        {
            StickSpawner.tempStick.A = hit.collider.gameObject.GetComponent<PointRenderer>().relatedPoint;
            return;
        }
        if (StickSpawner.tempStick.B == null)
        {
            StickSpawner.tempStick.B = hit.collider.gameObject.GetComponent<PointRenderer>().relatedPoint;
            GridManager.sticksList.Add(StickSpawner.tempStick);
            gameManager.GetComponent<StickSpawner>().GenerateStick(StickSpawner.tempStick);
            StickSpawner.tempStick = new Stick();
        }

        Debug.Log(GridManager.sticksList.Count);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(relatedPoint.position.x, relatedPoint.position.y, 3);
        DetectRightSelection();
        DetectMiddleSelection();
    } 
}
