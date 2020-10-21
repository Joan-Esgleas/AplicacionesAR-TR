using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaccion : MonoBehaviour
{
    public AdminElemento adminElemento;
    public float A;
    public float B;
    public float C;
    public float D;
    public Interjec2 interscript;
    private void Update()
    {
        A = float.Parse(adminElemento.ComponenteADelPlano.text);
        B = float.Parse(adminElemento.ComponenteCDelPlano.text);
        C = float.Parse(adminElemento.ComponenteBDelPlano.text);
        D = float.Parse(adminElemento.ComponenteDDelPlano.text);
        if(interscript== null)
        {
            interscript=FindObjectOfType<Interjec2>();
        }
    }

    public void ActivarInterjeccon()
    {
        if(interscript.A == 3.45879f)
        {
            interscript.A = A;
        }
        else
        {
            interscript.pA = A;
        }
        if (interscript.B == 3.45879f)
        {
            interscript.B = B;
        }
        else
        {
            interscript.pB = B;
        }
        if (interscript.C == 3.45879f)
        {
            interscript.C = C;
        }
        else
        {
            interscript.pC = C;
        }
        if (interscript.D == 3.45879f)
        {
            interscript.D = D;
        }
        else
        {
            interscript.pD = D;
        }
        gameObject.SetActive(false);
    }

}
