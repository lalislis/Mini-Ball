using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildGameplay : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Border Atas" && collision.gameObject.tag == "Kaleng")
        {
            return;
        }

        Transform parent = transform.parent;
        CanballMechanic gameplay = parent.GetComponent<CanballMechanic>();

        gameplay.CollisonDetected(collision);
    }
}
