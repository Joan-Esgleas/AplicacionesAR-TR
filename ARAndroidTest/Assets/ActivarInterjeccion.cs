using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarInterjeccion : MonoBehaviour
{
    public GameObject[] CosasInabilitas;

    public void BotonInabilitar()
    {
        for (int i = 0; i < CosasInabilitas.Length; i++)
        {
            CosasInabilitas[i].SetActive(false);
        }
    }
}
