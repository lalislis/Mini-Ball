using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ReticleBehaviour : MonoBehaviour
{
    public GameObject Child;
    public SurfaceManager SurfaceManager;

    public ARPlane CurrentPlane;

    // Start sebelum first frame update
    private void Start() 
    {
        Child = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        // Menentukan Center Point pada Screen dengan Camera
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

        // Conduct Raycast
        var hits = new List<ARRaycastHit>();
        SurfaceManager.RaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinBounds);

        // Menentukan intersection point of interest dari antrian hits list.
        // Prioritas : locked plane yang ada di SurfaceManager.
        // Jika tidak ada : menggunakan first plane hit.
        // Add pada akhir Update()
        CurrentPlane = null;
        ARRaycastHit? hit = null;
        //if (hits.Length > 0) {
        //    // Jika belum memiliki locked plane...
        //    var lockedPlane = SurfaceManager.LockedPlane;
        //    hit = lockedPlane == null
        //        // ...gunakan first hit dari 'hits'.
        //        ? hits[0]
        //        // Atau gunakan locked plane jika sudah ada.
        //        : hits.SingleOrDefault(x => x.trackableId == lockedPlane.trackableId);
        //}

        // Jika hit memiliki result, GameObject di-transform (pindahkan) ke hit position
        if (hit.HasValue) {
            CurrentPlane = SurfaceManager.PlaneManager.GetPlane(hit.Value.trackableId);
            // Untuk memindahkan reticle ke lokasi hit
            transform.position = hit.Value.pose.position;
        }
        Child.SetActive(CurrentPlane != null);
    }
}