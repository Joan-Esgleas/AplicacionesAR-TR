using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interjec2 : MonoBehaviour
{
    public float A;
    public float B;
    public float C;
    public float D;
    public float pA;
    public float pB;
    public float pC;
    public float pD;
    public TabManager tbm;

    private void OnEnable()
    {
        A = 3.45879f;
        B = 3.45879f;
        C = 3.45879f;
        D = 3.45879f;
        pA = 3.45879f;
        pB = 3.45879f;
        pC = 3.45879f;
        pD = 3.45879f;
        tbm = GameObject.FindObjectOfType<TabManager>();
        tbm.RectaDetectada = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(pD!= 3.45879f && tbm.RectaDetectada==false)
        {
            tbm.CrearRecta();
            tbm.IndetectarIntegracion();
        }
    }
}
