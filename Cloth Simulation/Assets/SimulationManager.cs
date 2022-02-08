using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    bool runSimulation = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            runSimulation = !runSimulation;
        if(runSimulation)
            GridManager.Simulate();       
    }
}
