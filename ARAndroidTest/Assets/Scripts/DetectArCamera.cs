using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectArCamera : MonoBehaviour
{
    public Canvas canvas;
    [HideInInspector]
    public Camera cam;
    void OnEnable()
    {
        cam = Camera.main;
        canvas.worldCamera = cam;
    }
    private void Update()
    {
           canvas.transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }
}
