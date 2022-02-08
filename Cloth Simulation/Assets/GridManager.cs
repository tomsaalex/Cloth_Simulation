using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
    public Vector2 position, prevPosition;
    public bool locked = false;

    public Point(Vector2 position)
    {
        this.position = position;
        this.prevPosition = position;
    }
}

public class Stick
{
    public Point A = null, B = null;
    public float length;
}

public static class GridManager
{
    public static List<Point> pointsList = new List<Point>();
    public static List<Stick> sticksList = new List<Stick>();

    public static void Simulate()
    {
        Debug.Log("Workin'");
        foreach(Point p in pointsList)
        {
            if(!p.locked)
            {
                Vector2 positionBeforeUpdate = p.position;
                p.position += p.position - p.prevPosition;
                p.position += Vector2.down * 1.5f * Time.deltaTime * Time.deltaTime;
                p.prevPosition = positionBeforeUpdate;
            }
        }

        for(int i = 0; i < 10000; i++)
            foreach(Stick s in sticksList)
            {
                Vector2 stickCenter = (s.A.position + s.B.position) / 2;
                Vector2 stickDir = (s.A.position - s.B.position).normalized;

                Vector2 desiredPos1 = stickCenter + stickDir * s.length / 2;
                Vector2 desiredPos2 = stickCenter - stickDir * s.length / 2;

                if (!s.A.locked)// && Vector2.Distance(s.A.position, desiredPos1) > 0.1)
                    s.A.position = desiredPos1;
                if(!s.B.locked)// && Vector2.Distance(s.B.position, desiredPos2) > 0.1)
                    s.B.position = desiredPos2;
            }
        
    }
}
