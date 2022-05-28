using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckGoal : MonoBehaviour
{
    private bool isGoal = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            isGoal = true;
        }
    }

    public bool getGoal()
    {
        return isGoal;
    }
}
