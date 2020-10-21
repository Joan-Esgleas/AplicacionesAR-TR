using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nueva Pelicula", menuName = "Pelicula")]
public class Pelicula : ScriptableObject
{
    //Información sobre la Pelicula
    public string nombreDePelicula;
    public string urlNetflix;
    public string urltrailer;

    public float year;
    public float duracion;
    public string pais;
    public string director;
    public string guion;
    public string musica;
    public string fotografia;
    public string reparto;
    public string sinposis;

    public float criticaAudiencia;
    public float crticaProfesional;
}
