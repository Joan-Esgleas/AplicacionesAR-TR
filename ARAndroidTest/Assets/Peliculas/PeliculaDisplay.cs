using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class PeliculaDisplay : MonoBehaviour
{
    // Scriptable Object
    public Pelicula pelicula;

    //UI
    public GameObject aboutWindow;
    public GameObject sinopsisWindow;
    public GameObject netflixBoton;
    public GameObject abautBoton;
    public GameObject tituloWindow;
    public GameObject botonAtras;
    public GameObject activadorDeCartel;
    public GameObject cruzBotton;
    public GameObject trailerObject;
    public GameObject playButton;
    public GameObject videoCheck;

    //Objetos de textos
    public TextMeshProUGUI namePelicula;
    public TextMeshProUGUI year;
    public TextMeshProUGUI duracion;
    public TextMeshProUGUI pais;
    public TextMeshProUGUI director;
    public TextMeshProUGUI guion;
    public TextMeshProUGUI musica;
    public TextMeshProUGUI fotografia;
    public TextMeshProUGUI reparto;

    public TextMeshProUGUI sinopsis;

    public TextMeshProUGUI criticaAudiencia;
    public TextMeshProUGUI criticaProfesional;

    public VideoPlayer trailer;

    //Detec Camera
    public Canvas canvas;
    [HideInInspector]
    public Camera cam;

    void OnEnable()
    {
        activadorDeCartel.SetActive(false);

        aboutWindow.SetActive(false);
        botonAtras.SetActive(false);
        sinopsisWindow.SetActive(true);
        netflixBoton.SetActive(true);
        abautBoton.SetActive(true);
        tituloWindow.SetActive(true);
        videoCheck.SetActive(false);
        playButton.SetActive(true);
        trailerObject.SetActive(true);

        trailer.Stop();

        namePelicula.text = pelicula.nombreDePelicula;
        sinopsis.text = pelicula.sinposis;
        year.text = " Año: " + pelicula.year;
        duracion.text = " Duración: " + pelicula.duracion + " min";
        pais.text = " País: " + pelicula.pais;
        director.text = " Dirección: " + pelicula.director;
        guion.text = " Guion: " + pelicula.guion;
        musica.text = " Música: " + pelicula.musica;
        fotografia.text = " Fotografía: " + pelicula.fotografia;
        reparto.text = " Reparto: " + pelicula.reparto;
        criticaAudiencia.text = "" + pelicula.criticaAudiencia;
        criticaProfesional.text = "" + pelicula.crticaProfesional;

        cam = Camera.main;
        canvas.worldCamera = cam;

    }
    void Update(){
        
        canvas.transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        
        Vector3 puntoEnPantalla = cam.WorldToViewportPoint(gameObject.transform.position);
        bool enPantalla = puntoEnPantalla.z > 0 && puntoEnPantalla.x > 0 && puntoEnPantalla.x < 1 && puntoEnPantalla.y > 0 && puntoEnPantalla.y < 1;
        if(enPantalla == false)
        {
            cruz();
        }
    }
    public void netflix()
    {
        Application.OpenURL(pelicula.urlNetflix);
    }
    public void cruz()
    {
        activadorDeCartel.SetActive(true);
        aboutWindow.SetActive(false);
        botonAtras.SetActive(false);
        sinopsisWindow.SetActive(false);
        netflixBoton.SetActive(false);
        abautBoton.SetActive(false);
        tituloWindow.SetActive(false);
        cruzBotton.SetActive(false);
        trailer.Stop();
        videoCheck.SetActive(false);
        playButton.SetActive(false);
        trailerObject.SetActive(false);

    }

    public void about()
    {
        aboutWindow.SetActive(true);
        sinopsisWindow.SetActive(false);
        netflixBoton.SetActive(false);
        abautBoton.SetActive(false);
        tituloWindow.SetActive(false);
        botonAtras.SetActive(true);
        trailerObject.SetActive(false);
        videoCheck.SetActive(false);
        playButton.SetActive(false);
        trailerObject.SetActive(false);
        trailer.Pause();
    }
    public void atras()
    {
        aboutWindow.SetActive(false);
        botonAtras.SetActive(false);
        sinopsisWindow.SetActive(true);
        netflixBoton.SetActive(true);
        abautBoton.SetActive(true);
        tituloWindow.SetActive(true);
        trailerObject.SetActive(false);
        videoCheck.SetActive(false);
        playButton.SetActive(true);
        trailerObject.SetActive(true);
        trailer.Pause();
    }
    public void activarCartel()
    {
        aboutWindow.SetActive(false);
        botonAtras.SetActive(false);
        sinopsisWindow.SetActive(true);
        netflixBoton.SetActive(true);
        abautBoton.SetActive(true);
        tituloWindow.SetActive(true);
        activadorDeCartel.SetActive(false);
        cruzBotton.SetActive(true);
        videoCheck.SetActive(false);
        playButton.SetActive(true);
        trailerObject.SetActive(true);

        trailer.Stop();
    }
    public void trailerPlay()
    {
        videoCheck.SetActive(true);
        playButton.SetActive(false);
        trailerObject.SetActive(true);
        trailer.Play();
    }
    public void trailerStop()
    {
        videoCheck.SetActive(false);
        playButton.SetActive(true);
        trailerObject.SetActive(true);
        trailer.Pause();
    }
    public void youtube()
    {
        Application.OpenURL(pelicula.urltrailer);
    }
    public void Onscreen()
    {
        activadorDeCartel.SetActive(true);
    }
}
