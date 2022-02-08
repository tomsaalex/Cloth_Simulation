using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PointColorSelector
{
    public static Color SelectPointColor(Point p)
    {
        if (p.locked)
            return new Color(255, 0, 0);
        return new Color(255, 255, 255);
    }
}
