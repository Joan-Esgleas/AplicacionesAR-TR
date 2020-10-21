using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Experimental.XR;

public class ARPlacingTapObj : MonoBehaviour
{
    public GameObject indicador;

    ARSessionOrigin arOrigin;
    ARRaycastManager raycastManager;
    bool plasmentPoseIsValid = false;
    Pose placementPose;
    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        UpdatePlasmentPose();
        UpdateIndicador();
    }
    void UpdatePlasmentPose()
    {
        var centroPantalla = Camera.current.ViewportToScreenPoint(new Vector3(0.5f,0.5f));
        var hits = new List<ARRaycastHit>();
        raycastManager.Raycast(centroPantalla,hits,TrackableType.Planes);

        plasmentPoseIsValid = hits.Count > 0;
        if (plasmentPoseIsValid)
        {
            placementPose = hits[0].pose;
        }
    }
    void UpdateIndicador()
    {
        if (plasmentPoseIsValid)
        {
            indicador.SetActive(true);
            indicador.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            indicador.SetActive(false);
        }
    }
}
