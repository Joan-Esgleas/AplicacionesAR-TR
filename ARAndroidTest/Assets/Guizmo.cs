using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guizmo : MonoBehaviour
{
    // When added to an object, draws colored rays from the
    // transform position.
    public int lineCount = 2;
    public float distancia = 50f;

    Vector3 pointB;
    private Color coloro;
    public enum colors
    {
        Rojo, Verde, Azul
    }

    // Create a new variable of that enum type above.
    public colors colores;

    public void Check_color()
    {
        switch (colores)
        {
            case colors.Rojo:
                coloro = Color.red;
                break;

            case colors.Verde:
                coloro = Color.green;
                break;

            case colors.Azul:
                coloro = Color.blue;
                break;
        }
    }

    static Material lineMaterial;
    private void Start()
    {
        Check_color();
    }
    static void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            Shader shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            lineMaterial.SetInt("_ZWrite", 0);
        }
    }
    public void OnRenderObject()
    {
        Check_color();
        CreateLineMaterial();
        lineMaterial.SetPass(0);

        GL.PushMatrix();

        GL.MultMatrix(transform.localToWorldMatrix);

        GL.Begin(GL.LINES);
        for (int i = 0; i < lineCount; ++i)
        {
            float n = i / (float)lineCount;
            float angleV = n * Mathf.PI * 2;
            //float puntZ = Mathf.Sqrt(Mathf.Pow(Mathf.Cos(angleV),2f) + Mathf.Pow(Mathf.Sin(angleV),2f));
            // Vertex colors canbian
            GL.Color(coloro);
            // 1 vertex a transform position
            GL.Vertex3(0, 0, 0);
            // un altre vertex al final del cercle
            pointB = new Vector3(Mathf.Cos(angleV) * distancia, Mathf.Sin(angleV) * distancia, 0);
            GL.Vertex3(pointB.x,pointB.y,pointB.z);
        }
        GL.End();
        GL.PopMatrix();
    }
  
}
