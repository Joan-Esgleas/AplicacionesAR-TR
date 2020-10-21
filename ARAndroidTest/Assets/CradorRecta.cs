using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CradorRecta : MonoBehaviour
{
    public GameObject OrigenDeCordenades;
    LineRenderer linea;
    public float escala;
    public Vector3 puntoX;
    public Vector3 punto;
    public Vector3 VectorDirector;
    Vector3 puntoXp;
    public Color colorRecta;
    private void OnEnable()
    {
        OrigenDeCordenades = GameObject.FindGameObjectWithTag("OrigenDeCordenadas");
    }
    private void Update()
    {
         if (OrigenDeCordenades == null)
         {
            OrigenDeCordenades = GameObject.FindGameObjectWithTag("OrigenDeCordenadas");
         }
        gameObject.transform.position = OrigenDeCordenades.transform.position;
        gameObject.transform.rotation = OrigenDeCordenades.transform.rotation;
        if(linea == null)
        {
            linea = gameObject.GetComponent<LineRenderer>();
        }
        float n = escala;
        puntoX = punto + VectorDirector * n;
        puntoXp = punto + (VectorDirector * (n-1)) * -1;
        DibujarLinea();
    }
    void DibujarLinea()
    {
        Vector3 p1p = transform.localToWorldMatrix * new Vector4((punto.x) / 10, (punto.y) / 10, (punto.z) / 10, 1);
        Vector3 p2p = transform.localToWorldMatrix * new Vector4(puntoX.x / 10, puntoX.y / 10, puntoX.z / 10, 1);
        Vector3 p3p = transform.localToWorldMatrix * new Vector4(puntoXp.x / 10, puntoXp.y / 10, puntoXp.z / 10, 1);
        linea.SetPosition(1, p1p);
        linea.SetPosition(0, p2p);
        linea.SetPosition(2, p3p);
        linea.startColor = colorRecta;
        linea.endColor = colorRecta;
    }
}
