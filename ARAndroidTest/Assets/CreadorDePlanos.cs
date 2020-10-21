using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorDePlanos : MonoBehaviour
{
    public GameObject OrigenDeCordenades;
    public float A;
    public float B;
    public float C;
    public float D;

    public Vector3 centroTriangulo;

    public float escala;

    public Vector3 punto1;
    public Vector3 punto2;
    public Vector3 punto3;

    public Vector3 puntoX;
    public Vector3 puntoY;
    public Vector3 puntoZ;

    public Vector3 puntDeTallX;
    public Vector3 puntDeTallY;
    public Vector3 puntDeTallZ;

    public Vector3 punto1b;
    public Vector3 punto2b;
    public Vector3 punto3b;

    public Vector3 proba;

    public Color colorPlano;

    Plane plano;

    GameObject origendeCordenadas;

    Vector3[] vertex;
    int[] triangles;

    float ancho;
    float altura;

    MeshCollider col;

    Mesh mesh;
    private void OnEnable()
    {
        mesh = gameObject.GetComponent<MeshFilter>().mesh;
        mesh.Clear();
        OrigenDeCordenades = GameObject.FindGameObjectWithTag("OrigenDeCordenadas");
        col = gameObject.GetComponent<MeshCollider>();
        gameObject.transform.parent = null;
    }
    private void Update()
    {
        float e = escala;
        float s = e;
        if (A == 0)
        {
            if (e<1)
            {
                s = 1;
            }
            else
            {
                s = e;
            }
            
            if (B > 0 && C > 0)
            {
                punto1 = new Vector3(0, ((-B * e) - D) / C, e);
                punto2 = new Vector3(s, s, (-C * s - D) / B);
                punto3 = new Vector3(-s, s, (-C * s - D) / B);
            }
            if (C < 0)
            {
                punto1 = new Vector3(0, e, ((-B)*e-D)/C);
                punto2 = new Vector3(-s, (C * s - D) / B, -s);
                punto3 = new Vector3(s, (C * s - D) / B, -s);
            }
            if (B < 0)
            {
                punto1 = new Vector3(0, s, ((-B) * s - D) / C);
                punto2 = new Vector3(-s, (C * s - D) / B, -s);
                punto3 = new Vector3(s, (C * s - D) / B, -s);
            }
            if (B < 0 && C < 0)
            {
                punto1 = new Vector3(0, s, ((-C * s) - D) / B);
                punto2 = new Vector3(s,-s,(C*s-D)/B);
                punto3 = new Vector3(-s,-s,(C*s-D)/B);
            }
        }
        if (B == 0)
        {
            if (e < 1)
            {
                s = 1;
            }
            else
            {
                s = e;
            }
            if (A > 0 && C > 0)
            {
                punto1 = new Vector3((C*s-D)/A,-s,0);
                punto2 = new Vector3(-s,(C*s-D)/A,-s);
                punto3 = new Vector3(-s,(C*s-D)/A,s);
            }
            if (A < 0)
            {
                punto1 = new Vector3(-e, (-C * e - D) / A,0) ;
                punto2 = new Vector3(s, (-A * s - D) / -C, s);
                punto3 = new Vector3(s, (-A*s - D) / -C, -s);
            }
            if (C < 0)
            {
                punto1 = new Vector3(s,(-A*s - D) / C,-s);
                punto2 = new Vector3(s, (-A * s - D) / C, s);
                punto3 = new Vector3((C * e - D) / A, -e,0);
            }
            if (A < 0 && C < 0)
            {
                punto1 = new Vector3((C * e - D) / A, -e, 0);
                punto2 = new Vector3(-s, (C * s - D) / A, -s);
                punto3 = new Vector3(-s, (C * s - D) / A, s);
            }
        }
        if (C == 0)
        {
            if (e < 1)
            {
                s = 1;
            }
            else
            {
                s = e;
            }
            if (A > 0 && B > 0)
            {
                punto1 = new Vector3((B * s - D) / A, -s, 0);
                punto2 = new Vector3(-s, (B * s - D) / A, -s);
                punto3 = new Vector3(-s, (B * s - D) / A, s);
            }
            if (A < 0)
            {
                punto1 = new Vector3(-e, (-B * e - D) / A, 0);
                punto2 = new Vector3(s, (-A * s - D) / -B, s);
                punto3 = new Vector3(s, (-A * s - D) / -B, -s);
            }
            if (B < 0)
            {
                punto1 = new Vector3(s, (-A * s - D) / B, -s);
                punto2 = new Vector3(s, (-A * s - D) / B, s);
                punto3 = new Vector3((B * e - D) / A, -e, 0);
            }
            if (A < 0 && B < 0)
            {
                punto1 = new Vector3((B * e - D) / A, -e, 0);
                punto2 = new Vector3(-s, (B * s - D) / A, -s);
                punto3 = new Vector3(-s, (B * s - D) / A, s);
            }
        }
        if (A == 0 && C == 0)
        {
            if (e < 1)
            {
                s = 1;
            }
            else
            {
                s = e;
            }
            punto1 = new Vector3(s, D, s);
            punto2 = new Vector3(-s, D, s);
            punto3 = new Vector3(s, D, -s);
        }
        if (A == 0 && B == 0)
        {
            if (e < 1)
            {
                s = 1;
            }
            else
            {
                s = e;
            }
            punto1 = new Vector3(D, s, s);
            punto2 = new Vector3(D, -s, s);
            punto3 = new Vector3(D, s, -s);
        }
        if (C == 0 && B == 0)
        {
            if (e < 1)
            {
                s = 1;
            }
            else
            {
                s = e;
            }
            punto1 = new Vector3(s, s, D);
            punto2 = new Vector3(s, -s, D);
            punto3 = new Vector3(-s, s, D);
        }
        if (A == 0 && B == 0 && C == 0)
        {
            punto1 = new Vector3(0,0,0);
            punto2 = new Vector3(0, 0, 0);
            punto3 = new Vector3(0, 0, 0);
        }
        if (A < 0&&C != 0 && B != 0)
        {
            punto1 = new Vector3(((-B * e - C * e - D) / A), e, e);
            punto2 = new Vector3(-e, (-A * -e - C * e - D) / B, e);
            punto3 = new Vector3(-e, e, (-A * -e - B * e - D) / C);
        }
        if (B < 0&&A != 0 && C != 0)
        {
            punto1 = new Vector3(((-B * -e - C * e - D) / A), -e, e);
            punto2 = new Vector3(e, (-A * e - C * e - D) / B, e);
            punto3 = new Vector3(e, -e, (-A * e - B * -e - D) / C);
        }
        if (C < 0&& A!=0&&B!=0)
        {
            punto1 = new Vector3(((-B * e - C * -e - D) / A), e, -e);
            punto2 = new Vector3(e, (-A * e - C * -e - D) / B, -e);
            punto3 = new Vector3(e, e, (-A * e - B * e - D) / C);
        }
        if (A < 0 && B < 0&&C!=0)
        {
            punto1 = new Vector3(((-B * -e - C * e - D) / A), -e, e);
            punto2 = new Vector3(-e, (-A * -e - C * e - D) / B, e);
            punto3 = new Vector3(-e, -e, (-A * -e - B * -e - D) / C);
        }
        if (A < 0 && C < 0&&B!=0)
        {
            punto1 = new Vector3(((-B * e - C * -e - D) / A), e, -e);
            punto2 = new Vector3(-e, (-A * -e - C * -e - D) / B, -e);
            punto3 = new Vector3(-e, e, (-A * -e - B * e - D) / C);
        }
        if (B < 0 && C < 0 && A != 0)
        {
            punto1 = new Vector3(((-B * -e - C * -e - D) / A), -e, -e);
            punto2 = new Vector3(e, (-A * e - C * -e - D) / B, -e);
            punto3 = new Vector3(e, -e, (-A * e - B * -e - D) / C);
        }
        if (A > 0 && B > 0 && C > 0)
        {
            punto1 = new Vector3(((-B * e - C * e - D) / A), e, e);
            punto2 = new Vector3(e, (-A * e - C * e - D) / B, e);
            punto3 = new Vector3(e, e, (-A * e - B * e - D) / C);
        }
        if (A < 0 && B < 0 && C < 0)
        {
            punto1 = new Vector3(((-B * e - C * e - D) / A), e, e);
            punto2 = new Vector3(e, (-A * e - C * e - D) / B, e);
            punto3 = new Vector3(e, e, (-A * e - B * e - D) / C);
        }

        punto1b = punto1 / 10;
        punto2b = punto2 / 10;
        punto3b = punto3 / 10;

        MakeMeshData();

        CreatMesh();

        ColorearPlano();
    }
    void MakeMeshData()
    {
        //Determinacion de los vertices del triangulo
        vertex = new Vector3[]
        {
           punto1b,
           punto2b,
           punto3b,
           punto3b,
           punto2b,
           punto1b,
        };
        //Determinacion del orden de render
        triangles = new int[] { 0, 1, 2, 3, 4, 5 };
        //Establecer los normales
        Vector3[] normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
        mesh.normals = normals;
        //Definición de las UV
        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };
        mesh.uv = uv;

        col.sharedMesh = mesh;
    }
    
    void ColorearPlano()
    {
        //Determinación del color del Triangulo
        Vector3[] vertices = mesh.vertices;
        Color[] colors = new Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
            colors[i] = colorPlano;

        mesh.colors = colors;
    }
    private void CreatMesh()
    {
        //Creación del triangulo
        mesh.vertices = vertex;
        mesh.triangles = triangles;
    }
}
