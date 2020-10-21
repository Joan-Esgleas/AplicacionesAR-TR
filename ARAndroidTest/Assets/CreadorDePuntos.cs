using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreadorDePuntos : MonoBehaviour
{
    public Vector3 cordenadas;
    public GameObject puntoGrafico;
    public TextMeshPro NombreGrafico;

    [HideInInspector]
    public Color colorPunto;

    Renderer rendererGraphics;
    void OnEnable()
    {
        puntoGrafico.SetActive(true);
        rendererGraphics = puntoGrafico.GetComponent<Renderer>();
        gameObject.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(puntoGrafico.activeSelf == false)
        {
            puntoGrafico.SetActive(true);
        }
        puntoGrafico.transform.position = transform.position + (cordenadas / 10);
        if(rendererGraphics == null)
        {
            rendererGraphics = puntoGrafico.GetComponent<Renderer>();
        }
        if(rendererGraphics.material.color != colorPunto)
        {
            rendererGraphics.material.color = colorPunto;
        }
        if(NombreGrafico.color != colorPunto)
        {
            NombreGrafico.color = colorPunto;
        }
    }
}
