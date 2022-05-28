using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChildGameplay : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Border Atas" && collision.gameObject.tag == "Kaleng")
        {
            return;
        }

        Transform parent = transform.parent;

        if (SceneManager.GetActiveScene().name == "Basketball")
        {
            BasketballMechanic basketBall = parent.GetComponent<BasketballMechanic>();
            basketBall.CollisionDetected(collision);
            return;

        }

        CanballMechanic canBall = parent.GetComponent<CanballMechanic>();
        canBall.CollisonDetected(collision);
    }
}
