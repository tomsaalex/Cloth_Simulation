using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredefinedShapeGenerator : MonoBehaviour
{

    Point point, prevPoint = null;

    GameObject gameManager;
    Transform nodeParent;

    public int rows;
    public int cols;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        nodeParent = GameObject.FindWithTag("NodeParent").transform;
        for (int j = 0; j < rows; j++)
        {
            for (int i = 0; i < cols; i ++)
            {
                Point point = NodeSpawner.AddNodeAtPosition(new Vector2(200 + i * 60, 1040 - j * 60));
                /*if (prevPoint != null)
                {
                    Stick s = new Stick();
                    s.B = point;
                    s.A = prevPoint;
                    gameManager.GetComponent<StickSpawner>().GenerateStick(s);
                }*/
            }
        }

        for (int i = 0; i < rows; i++)
        {
            prevPoint = null;
            for (int j = 0; j < cols; j++)
            {
                point = GridManager.pointsList[i * cols + j];
                if (prevPoint == null)
                {
                    prevPoint = point;
                    continue;
                }

                Stick s = new Stick();
                s.B = point;
                s.A = prevPoint;
                GridManager.sticksList.Add(s);
                gameManager.GetComponent<StickSpawner>().GenerateStick(s);
                prevPoint = point;
            }
        }
        
        for (int i = 0; i < cols; i++)
        {
            prevPoint = null;
            for (int j = 0; j < rows; j++)
            {
                point = GridManager.pointsList[i + j * cols];
                if (prevPoint == null)
                {
                    prevPoint = point;
                    continue;
                }

                Stick s = new Stick();
                s.B = point;
                s.A = prevPoint;
                GridManager.sticksList.Add(s);
                gameManager.GetComponent<StickSpawner>().GenerateStick(s);
                prevPoint = point;
            }
        }

    }

    
}
