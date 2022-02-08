using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpawner : MonoBehaviour
{

    static GameObject point;
    static Transform nodeParent;
    private void Awake()
    {
        point = Resources.Load<GameObject>("point");
        nodeParent = GameObject.FindWithTag("NodeParent").transform;
    }

    public static Point AddNodeAtPosition(Vector2 position)
    {
        Vector3 pointCoordinates = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, 3));
        GameObject pointObject = Instantiate(point, pointCoordinates, Quaternion.identity, nodeParent.transform);
        Vector2 pointPosition2D = new Vector2(pointObject.transform.position.x, pointObject.transform.position.y);

        Point actualPoint = new Point(pointPosition2D);
        GridManager.pointsList.Add(actualPoint);
        pointObject.GetComponent<PointRenderer>().relatedPoint = actualPoint;

        return actualPoint;
    }

    void SpawnNode()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        AddNodeAtPosition(Input.mousePosition);
    }

    void Update()
    {
        SpawnNode();
    }
}
