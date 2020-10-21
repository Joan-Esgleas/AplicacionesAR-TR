using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdminElemento : MonoBehaviour
{

    //Creador de Plano
    public GameObject Plano;
    public GameObject CearPlanoInspector;
    public InputField ComponenteADelPlano;
    public InputField ComponenteBDelPlano;
    public InputField ComponenteCDelPlano;
    public InputField ComponenteDDelPlano;
    public Slider EscaladorDelPlano;
    public Dropdown SelectorDeColoresPlano;
    public CreadorDePlanos creadorPlano;

    [Space(20)]
    //Creador de recta
    public GameObject Recta;
    public GameObject CearRectaInspector;
    public InputField P1;
    public InputField P2;
    public InputField P3;
    public InputField D1;
    public InputField D2;
    public InputField D3;
    public Slider EscaladorDelRecta;
    public Dropdown SelectorDeColoresRecta;
    CradorRecta creadorRecta;
    [Space(20)]
    //Creador de punto
    public GameObject Punto;
    public GameObject CearPuntoInspector;
    public InputField CordenadaA;
    public InputField CordenadaB;
    public InputField CordenadaC;
    public InputField NombrePunto;
    public Dropdown SelectorDeColoresPunto;
    CreadorDePuntos creadorDePuntos;
    [Space(20)]
    public TextMeshProUGUI ElementoText;
    public TextMeshProUGUI FormulaTexto;
    public Image ColorenInspector;
    public string Elemento;
    public Color ColorGeneral;
    TabManager tabManager;

    GameObject OrdCoord;
    Transform OrigenDeCordenadas;

    public Image ColorElemento;
    GameObject tabuladorM;
    bool Mostrable = true;
    int numelemento;

    public float CantidadDePlanos = 0;

     
    private void Start()
    {
        Plano.SetActive(false);
        CearPlanoInspector.SetActive(false);
        Recta.SetActive(false);
        CearRectaInspector.SetActive(false);
        Punto.SetActive(false);
        CearPuntoInspector.SetActive(false);
        tabuladorM = GameObject.FindGameObjectWithTag("TabManager");
        tabManager = tabuladorM.GetComponent<TabManager>();
        numelemento = tabManager.cantidadDeElementos;
    }
    private void Update()
    {
        if (OrdCoord == null)
        {
            OrdCoord = GameObject.FindGameObjectWithTag("OrigenDeCordenadas");
            OrigenDeCordenadas = OrdCoord.transform;
        }
        gameObject.transform.SetSiblingIndex(tabManager.cantidadDeElementos - numelemento);
        ColorenInspector.color = ColorGeneral;
        #region ElementoPlano de Texto
        ElementoText.text = Elemento;
        #endregion
        if (Elemento == "Plano"&& Mostrable == true)
        {
            if (Plano.activeSelf == false)
            {
                Plano.SetActive(true);
                CearPlanoInspector.SetActive(true);
            }
            if (creadorPlano == null)
            {
                creadorPlano = Plano.GetComponent<CreadorDePlanos>();
            }
            ManagerPlano();
            #region Formula Plano Texto
            FormulaTexto.text = creadorPlano.A + "x+" + creadorPlano.C + "y+" + creadorPlano.B + "z+" + creadorPlano.D + "=0";
            #endregion
        }
        if (Elemento == "Recta" && Mostrable == true)
        {
            if(Recta.activeSelf == false)
            {
                Recta.SetActive(true);
                CearRectaInspector.SetActive(true);
            }
            if(creadorRecta == null)
            {
                creadorRecta = Recta.GetComponent<CradorRecta>();
            }
            ManagerRecta();
            #region Formula Recta Texto
            FormulaTexto.text ="("+ creadorRecta.punto.x+","+creadorRecta.punto.z+","+creadorRecta.punto.y+")"+"+"+"λ"+"("+ creadorRecta.VectorDirector.x+","+ creadorRecta.VectorDirector.z+","+ creadorRecta.VectorDirector.y+")"+"=X";
            #endregion
        }
        if(Elemento == "Punto" && Mostrable == true)
        {
            if(Punto.activeSelf == false)
            {
                Punto.SetActive(true);
                CearPuntoInspector.SetActive(true);
            }
            if (creadorDePuntos == null)
            {
                creadorDePuntos = Punto.GetComponent<CreadorDePuntos>();
            }
            ManagerPunto();
            #region Formula Punto Texto
            FormulaTexto.text = NombrePunto.text+"=" + "(" + creadorDePuntos.cordenadas.x + "," + creadorDePuntos.cordenadas.z + "," + creadorDePuntos.cordenadas.y + ")" ;
            #endregion
        }
    }
    void ManagerPlano()
    {
        Plano.transform.position = OrdCoord.transform.position;
        Plano.transform.rotation = OrdCoord.transform.rotation;

        #region DeterminarColor
        if (SelectorDeColoresPlano.options[SelectorDeColoresPlano.value].text == "Rojo")
        {
            ColorRojo();

        }
        if (SelectorDeColoresPlano.options[SelectorDeColoresPlano.value].text == "Azul")
        {
            ColorAzul();
        }
        if (SelectorDeColoresPlano.options[SelectorDeColoresPlano.value].text == "Cian")
        {
            ColorCian();
        }
        if (SelectorDeColoresPlano.options[SelectorDeColoresPlano.value].text == "Gris")
        {
            ColorGris();
        }
        if (SelectorDeColoresPlano.options[SelectorDeColoresPlano.value].text == "Verde")
        {
            ColorVerde();
        }
        if (SelectorDeColoresPlano.options[SelectorDeColoresPlano.value].text == "Lila")
        {
            ColorLila();
        }
        if (SelectorDeColoresPlano.options[SelectorDeColoresPlano.value].text == "Blanco")
        {
            ColorBlanco();
        }
        if (SelectorDeColoresPlano.options[SelectorDeColoresPlano.value].text == "Amarillo")
        {
            ColorAmarillo();
        }
        if (SelectorDeColoresPlano.options[SelectorDeColoresPlano.value].text == "Negro")
        {
            ColorNegro();
        }
        #endregion
        creadorPlano.A = float.Parse(ComponenteADelPlano.text);
        creadorPlano.B = float.Parse(ComponenteBDelPlano.text);
        creadorPlano.C = float.Parse(ComponenteCDelPlano.text);
        creadorPlano.D = float.Parse(ComponenteDDelPlano.text);
        creadorPlano.escala = EscaladorDelPlano.value;
        creadorPlano.colorPlano = ColorGeneral;
    }
    void ManagerRecta()
    {
        Recta.transform.position = OrdCoord.transform.position;
        Recta.transform.rotation = OrdCoord.transform.rotation;

        #region DeterminarColor2
        if (SelectorDeColoresRecta.options[SelectorDeColoresRecta.value].text == "Rojo")
        {
            ColorRojo();

        }
        if (SelectorDeColoresRecta.options[SelectorDeColoresRecta.value].text == "Azul")
        {
            ColorAzul();
        }
        if (SelectorDeColoresRecta.options[SelectorDeColoresRecta.value].text == "Cian")
        {
            ColorCian();
        }
        if (SelectorDeColoresRecta.options[SelectorDeColoresRecta.value].text == "Gris")
        {
            ColorGris();
        }
        if (SelectorDeColoresRecta.options[SelectorDeColoresRecta.value].text == "Verde")
        {
            ColorVerde();
        }
        if (SelectorDeColoresRecta.options[SelectorDeColoresRecta.value].text == "Lila")
        {
            ColorLila();
        }
        if (SelectorDeColoresRecta.options[SelectorDeColoresRecta.value].text == "Blanco")
        {
            ColorBlanco();
        }
        if (SelectorDeColoresRecta.options[SelectorDeColoresRecta.value].text == "Amarillo")
        {
            ColorAmarillo();
        }
        if (SelectorDeColoresRecta.options[SelectorDeColoresRecta.value].text == "Negro")
        {
            ColorNegro();
        }
        #endregion
        creadorRecta.punto.x = float.Parse(P1.text);
        creadorRecta.punto.z = float.Parse(P2.text);
        creadorRecta.punto.y = float.Parse(P3.text);
        creadorRecta.VectorDirector.x = float.Parse(D1.text);
        creadorRecta.VectorDirector.z = float.Parse(D2.text);
        creadorRecta.VectorDirector.y = float.Parse(D3.text);
        creadorRecta.escala = EscaladorDelRecta.value;
        creadorRecta.colorRecta = ColorGeneral;
    }
    void ManagerPunto()
    {
        #region DeterminarColor3
        if (SelectorDeColoresPunto.options[SelectorDeColoresPunto.value].text == "Rojo")
        {
            ColorRojo();

        }
        if (SelectorDeColoresPunto.options[SelectorDeColoresPunto.value].text == "Azul")
        {
            ColorAzul();
        }
        if (SelectorDeColoresPunto.options[SelectorDeColoresPunto.value].text == "Cian")
        {
            ColorCian();
        }
        if (SelectorDeColoresPunto.options[SelectorDeColoresPunto.value].text == "Gris")
        {
            ColorGris();
        }
        if (SelectorDeColoresPunto.options[SelectorDeColoresPunto.value].text == "Verde")
        {
            ColorVerde();
        }
        if (SelectorDeColoresPunto.options[SelectorDeColoresPunto.value].text == "Lila")
        {
            ColorLila();
        }
        if (SelectorDeColoresPunto.options[SelectorDeColoresPunto.value].text == "Blanco")
        {
            ColorBlanco();
        }
        if (SelectorDeColoresPunto.options[SelectorDeColoresPunto.value].text == "Amarillo")
        {
            ColorAmarillo();
        }
        if (SelectorDeColoresPunto.options[SelectorDeColoresPunto.value].text == "Negro")
        {
            ColorNegro();
        }
        #endregion
        Punto.transform.position = OrdCoord.transform.position;
        Punto.transform.rotation = OrdCoord.transform.rotation;
        creadorDePuntos.cordenadas.x = float.Parse(CordenadaA.text);
        creadorDePuntos.cordenadas.z = float.Parse(CordenadaB.text);
        creadorDePuntos.cordenadas.y = float.Parse(CordenadaC.text);
        creadorDePuntos.NombreGrafico.text = NombrePunto.text;
        creadorDePuntos.colorPunto = ColorGeneral;
    }

    #region Colores

    public void ColorAzul()
    {
        ColorGeneral = Color.blue;

    }
    public void ColorRojo()
    {
        ColorGeneral = Color.red;

    }
    public void ColorNegro()
    {
        ColorGeneral = Color.black;

    }
    public void ColorCian()
    {
        ColorGeneral = Color.cyan;
    }
    public void ColorGris()
    {
        ColorGeneral = Color.gray;
    }
    public void ColorVerde()
    {
        ColorGeneral = Color.green;
    }
    public void ColorLila()
    {
        ColorGeneral = Color.magenta;

    }
    public void ColorBlanco()
    {
        ColorGeneral = Color.white;

    }
    public void ColorAmarillo()
    {
        ColorGeneral = Color.yellow;

    }
    #endregion
    public void Ajustes()
    {
        Mostrable = true;
        if (Elemento == "Plano")
        {
            CearPlanoInspector.SetActive(true);
        }
        if (Elemento == "Recta")
        {
            CearRectaInspector.SetActive(true);
        }
        if(Elemento == "Punto")
        {
            CearPuntoInspector.SetActive(true);
        }
    }
    public void Acceptar()
    {
        Mostrable = false;
        CearPlanoInspector.SetActive(false);
        CearRectaInspector.SetActive(false);
        CearPuntoInspector.SetActive(false);
    }
}
