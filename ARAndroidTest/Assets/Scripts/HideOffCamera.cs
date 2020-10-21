using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOffCamera : MonoBehaviour
{
    PeliculaDisplay peliculaDisplay;
    DetectArCamera detectArCamera;
    private void Start()
    {
        detectArCamera = GetComponent<DetectArCamera>();
        peliculaDisplay = GetComponent<PeliculaDisplay>();
    }
    void Update()
    {
        Vector3 puntoEnPantalla = detectArCamera.cam.WorldToViewportPoint(gameObject.transform.position);
        bool enPantalla = puntoEnPantalla.z > 0 && puntoEnPantalla.x > 0 && puntoEnPantalla.x < 1 && puntoEnPantalla.y > 0 && puntoEnPantalla.y < 1;
        if(enPantalla == false)
        {
            peliculaDisplay.cruz();
        }
    }
}
