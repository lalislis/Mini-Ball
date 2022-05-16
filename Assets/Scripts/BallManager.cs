using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

// Spawn BallBehaviour setiap kali plane di tap
// Masih placeholder dari dokumentasi, script mau dimodifikasi lagi

public class BallManager : MonoBehaviour
{
    public GameObject BallPrefab;
    public ReticleBehaviour Reticle;
    public SurfaceManager SurfaceManager;

    public BallBehaviour Ball;

    private void Update()
    {
        if (Ball == null && WasTapped() && Reticle.CurrentPlane != null)
        {
            // Spawn Ball di Reticle
            var obj = GameObject.Instantiate(BallPrefab);
            Ball = obj.GetComponent<BallBehaviour>();
            Ball.Reticle = Reticle;
            Ball.transform.position = Reticle.transform.position;
            SurfaceManager.LockPlane(Reticle.CurrentPlane);
        }    
    }

    private bool WasTapped()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }

        if (Input.touchCount == 0)
        {
            return false;
        }

        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
        {
            return false;
        }

        return true;
    }
}