using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SituarSistemaDeReferencia : MonoBehaviour
{
    public GameObject primerPaso;
    public GameObject segundoPaso;
    public GameObject Indicador;
    public GameObject fondo;
    public GameObject boton;
    ARTapToPlaceObject scripSistemasRef;
    bool todochuta;
    void Start()
    {
        scripSistemasRef = gameObject.GetComponent<ARTapToPlaceObject>();
        todochuta = false;
    }
    private void Update()
    {
        if(Indicador.activeSelf == false)
        {
            if (todochuta == false)
            {
                primerPaso.SetActive(true);
                segundoPaso.SetActive(false);
                boton.SetActive(false);
            }
        }
        else
        {
            primerPaso.SetActive(false);
        }
        if (Indicador.activeSelf == true)
        {
            if (todochuta == false)
            {
                primerPaso.SetActive(false);
                segundoPaso.SetActive(true);
                boton.SetActive(true);
            }
        }
    }
    public void DesabilitarSistemaPlace()
    {
        todochuta = true;
        scripSistemasRef.enabled = false;
        primerPaso.SetActive(false);
        segundoPaso.SetActive(false);
        fondo.SetActive(false);
        Indicador.SetActive(false);
        boton.SetActive(false);
    }
}
