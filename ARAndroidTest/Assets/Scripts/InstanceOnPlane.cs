using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;


public class InstanceOnPlane : MonoBehaviour
{
    ARRaycastManager raycastManager;
    List<ARRaycastHit> hits;
    public GameObject bola;
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        hits = new List<ARRaycastHit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;

            Touch touch = Input.GetTouch(0);

            if (IsPointerOverUIObject(touch.position))
                return;

            if (raycastManager.Raycast(touch.position, hits))
            {
                Pose pose = hits[0].pose;

                Instantiate(bola, pose.position, pose.rotation);
            }
        
    }
    bool IsPointerOverUIObject(Vector2 pos)
    {
        if (EventSystem.current == null)
            return false;
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(pos.x, pos.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;

    }
}
