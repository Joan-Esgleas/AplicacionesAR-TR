using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValorAlIniciar : MonoBehaviour
{
    ValorsDeCordenades valorsDeCordenades;
    public float valoress;
    ARTapToPlaceObject placeObjetss;

    private void Start()
    {
        placeObjetss = FindObjectOfType<ARTapToPlaceObject>();
    }
    // Start is called before the first frame update
    void OnEnable()
    {
       TextMeshPro textis = gameObject.GetComponent<TextMeshPro>();
        if (transform.position.x < 0 || transform.position.y < 0 || transform.position.z < 0)
        {
            textis.text = "-" + valoress;
        }
        else
        {
            textis.text = "" + valoress;
        }


    }

    // Update is called once per frame
}
