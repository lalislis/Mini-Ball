using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

// Spawn TargetBehaviour setiap kali plane di tap
// Masih placeholder dari dokumentasi, script mau dimodifikasi lagi

public class TargetManager : MonoBehaviour
{
    public GameObject TargetPrefab;
    public ReticleBehaviour Reticle;
    public SurfaceManager SurfaceManager;

    public TargetBehaviour Target;

    private void Update()
    {
        if (Target == null && WasTapped() && Reticle.CurrentPlane != null)
        {
            // Spawn Target di Reticle
            var obj = GameObject.Instantiate(TargetPrefab);
            Target = obj.GetComponent<TargetBehaviour>();
            Target.Reticle = Reticle;
            Target.transform.position = Reticle.transform.position;
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