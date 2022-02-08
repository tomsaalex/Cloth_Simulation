using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickRenderer : MonoBehaviour
{
    public Stick relatedStick;

    private void Update()
    {
        this.GetComponent<LineRenderer>().SetPosition(0, new Vector3(relatedStick.A.position.x, relatedStick.A.position.y, 3));
        this.GetComponent<LineRenderer>().SetPosition(1, new Vector3(relatedStick.B.position.x, relatedStick.B.position.y, 3));
    }

}
