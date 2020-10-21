using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminInterjecciones : MonoBehaviour
{
    public GameObject[] botonPlanos;
    public bool activarBuscaDeInterject = false;
    public List<GameObject> butPlan; 
    void Start()
    {
        butPlan = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        butPlan.AddRange(GameObject.FindGameObjectsWithTag("BotonInterjector"));
        //if (activarBuscaDeInterject == true)
        //{
        //for (int i = 0; i < botonPlanos.Length; i++)
        //{
        //botonPlanos[i].SetActive(true);
        //}
        //}
        //else
        //{
        if (activarBuscaDeInterject == true)
        {
            for (int i = 0; i < botonPlanos.Length; i++)
            {
                botonPlanos[i].SetActive(false);
            }
        }
        //}
    }
}
