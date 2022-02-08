using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickSpawner: MonoBehaviour
{
    public static Stick tempStick = new Stick();

    GameObject st;
    public GameObject stick;

    public void GenerateStick(Stick s)
    {
        st = Instantiate(stick);
        st.GetComponent<LineRenderer>().SetPosition(0, new Vector3(s.A.position.x, s.A.position.y, 3));
        st.GetComponent<LineRenderer>().SetPosition(1, new Vector3(s.B.position.x, s.B.position.y, 3));
        s.length = Vector2.Distance(s.B.position, s.A.position);
        st.GetComponent<StickRenderer>().relatedStick = s;
    }
}
