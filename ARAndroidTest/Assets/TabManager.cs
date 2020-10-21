using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    public GameObject Inspector;
    public GameObject botonMostrarInspector;
    public GameObject bloqueDeElementos;
    GameObject OrigenDeCordenades;
    public int maxElementos = 11;
    public GameObject Elementobj;
    [HideInInspector]
    public int cantidadDeElementos;
    public int cantidadDePlanos=0;

    public RectTransform PanelElementos;

    GameObject[] tagInspec;
    bool InspectorActivador;

    public bool activarBuscaDeInterject = false;
    public List<GameObject> butPlan;
    public GameObject BotonInterjeccion;

    public bool botInter = false;

    string planeIndicator;
    public Interjec2 interS;
    public CradorRecta cradorRecta;

    [HideInInspector]
    public bool RectaDetectada;

    float PuntoUnoR;
    float PuntoDosR;
    float PuntoTresR;
    float VectorUnoR;
    float VectorDosR;
    float VectorTresR;
    private void Start()
    {
        Inspector.SetActive(true);
        tagInspec = GameObject.FindGameObjectsWithTag("Inspector");
        foreach (GameObject go in tagInspec)
        {
            go.SetActive(false);
        }
        InspectorActivador = false;
        butPlan = new List<GameObject>();

    }
    private void Update()
    {
        if (OrigenDeCordenades == null)
        {
            OrigenDeCordenades = GameObject.FindGameObjectWithTag("OrigenDeCordenadas");
            botonMostrarInspector.SetActive(false);
        }
        else
        {
            if (InspectorActivador == false)
            {
                botonMostrarInspector.SetActive(true);
            }
            else
            {
                botonMostrarInspector.SetActive(false);
                tagInspec = GameObject.FindGameObjectsWithTag("Inspector");
            }
        }

        if (botInter == false)
        {
            butPlan.AddRange(GameObject.FindGameObjectsWithTag("BotonInterjector"));
            foreach (GameObject gameObject in butPlan)
            {
                gameObject.SetActive(false);
            }
        }

    }
    public void MostrarInspector()
    {
        foreach (GameObject go in tagInspec)
        {
            go.SetActive(true);
        }
        InspectorActivador = true;
        botonMostrarInspector.SetActive(false);
    }
    public void OcultarInspector()
    {

        foreach (GameObject go in tagInspec)
        {
            go.SetActive(false);
        }
        InspectorActivador = false;
        botonMostrarInspector.SetActive(true);
    }
    public void BottonCrearPlanoInspector()
    {
        if (cantidadDeElementos < maxElementos)
        {
            GameObject obj = Instantiate(Elementobj, PanelElementos.transform);
            cantidadDeElementos++;
            cantidadDePlanos++;
            AdminElemento AdminElem = obj.GetComponent<AdminElemento>();
            obj.transform.SetParent(Inspector.transform);
            obj.transform.SetParent(bloqueDeElementos.transform);
            obj.transform.position = new Vector3(PanelElementos.position.x, PanelElementos.position.y - 150 * (cantidadDeElementos - 1), 0);

            AdminElem.Elemento = "Plano";
            planeIndicator = "Plano";
            obj.SetActive(true);
        }
    }
    public void BottonCrearRectaInspector()
    {
        if (cantidadDeElementos < maxElementos)
        {
            GameObject obj = Instantiate(Elementobj, PanelElementos.transform);
            cantidadDeElementos++;
            AdminElemento AdminElem = obj.GetComponent<AdminElemento>();
            obj.transform.SetParent(Inspector.transform);
            obj.transform.SetParent(bloqueDeElementos.transform);
            obj.transform.position = new Vector3(PanelElementos.position.x, PanelElementos.position.y - 150 * (cantidadDeElementos - 1), 0);

            AdminElem.Elemento = "Recta";
            obj.SetActive(true);
        }
    }
    public void BottonCrearPuntoInspector()
    {
        if (cantidadDeElementos < maxElementos)
        {
            GameObject obj = Instantiate(Elementobj, PanelElementos.transform);
            cantidadDeElementos++;
            AdminElemento AdminElem = obj.GetComponent<AdminElemento>();
            obj.transform.SetParent(Inspector.transform);
            obj.transform.SetParent(bloqueDeElementos.transform);
            obj.transform.position = new Vector3(PanelElementos.position.x, PanelElementos.position.y - 150 * (cantidadDeElementos - 1), 0);
            AdminElem.Elemento = "Punto";
            obj.SetActive(true);
        }
    }

    public void Detectarintergetcion()
    {
        if (planeIndicator == "Plano")
        {
            botInter = true;
            foreach (GameObject gameObject in butPlan)
            {
                gameObject.SetActive(true);
            }
        }

    }
    public void IndetectarIntegracion()
    {
            botInter = false;
            foreach (GameObject gameObject in butPlan)
            {
                gameObject.SetActive(false);
            }
        RectaDetectada = true;

    }
    public void CrearRecta()
    {
        
        if (cantidadDeElementos < maxElementos)
        {
            interS = GameObject.FindObjectOfType<Interjec2>();
            float A = interS.A;
            float B = interS.B;
            float C = interS.C;
            float D = interS.D;
            float E = interS.pA;
            float F = interS.pB;
            float G = interS.pC;
            float H = interS.pD;
            float M = ((A * F) - (E * B));
            if (M != 0)
            {
                PuntoUnoR = ((H * B) - (D * F)) / ((A * F) - (E * B));
                PuntoDosR = ((D * E) - (A * H)) / ((A * F) - (E * B));
                PuntoTresR = 0;
                VectorUnoR = ((G * B) - (C * F)) / ((A * F) - (E * B));
                VectorDosR = ((C * E) - (G * A)) / ((A * F) - (E * B));
                VectorTresR = 1;
            }
            if (M == 0)
            {
                PuntoUnoR = 0;
                PuntoDosR = ((C * H) - (D * G)) / ((B * G) - (F * C));
                PuntoTresR = ((F*D) - (B * H)) / ((B * G) - (F * C));
                VectorUnoR = 1;
                VectorDosR = ((C * E) - (G * A)) / ((B * G) - (F * C));
                VectorTresR = ((F * A) - (B * E)) / ((B * G) - (F * C));
            }

            GameObject obj = Instantiate(Elementobj, PanelElementos.transform);
            cantidadDeElementos++;
            AdminElemento AdminElem = obj.GetComponent<AdminElemento>();
            obj.transform.SetParent(Inspector.transform);
            obj.transform.SetParent(bloqueDeElementos.transform);
            obj.transform.position = new Vector3(PanelElementos.position.x, PanelElementos.position.y - 150 * (cantidadDeElementos - 1), 0);
            AdminElem.P1.text = PuntoUnoR.ToString();
            AdminElem.P2.text = PuntoDosR.ToString();
            AdminElem.P3.text = PuntoTresR.ToString();
            AdminElem.D1.text = VectorUnoR.ToString();
            AdminElem.D2.text = VectorDosR.ToString();
            AdminElem.D3.text = VectorTresR.ToString();
            AdminElem.Elemento = "Recta";
            obj.SetActive(true);
        }

    }
}
