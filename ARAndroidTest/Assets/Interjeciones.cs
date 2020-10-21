using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class Interjeciones : MonoBehaviour
{
    public GameObject[] Planos;
    public CreadorDePlanos[] creadorDePlanos;
    public CreadorDePlanos PlanoSelecionado1;
    public CreadorDePlanos PlanoSelecionado2;

    public GameObject bola;

    [SerializeField]
    private Camera ArCam;

    Vector2 touchposition;
    ARRaycastManager arRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        ArCam = (Camera)FindObjectOfType(typeof(Camera));
        arRaycastManager = GetComponent<ARRaycastManager>();

    }
    // Update is called once per frame
    void Update()
    {
        Planos = GameObject.FindGameObjectsWithTag("PlanoObj");
        creadorDePlanos = new CreadorDePlanos[Planos.Length];
        for (int i = 0; i < Planos.Length; i++)
        {
            creadorDePlanos[i] = Planos[i].GetComponent<CreadorDePlanos>();
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (IsPointerOverUIObject(touch.position))
                return;
            touchposition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = ArCam.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if(Physics.Raycast(ray, out hitObject))
                {
                    CreadorDePlanos creadorPlanos = hitObject.transform.GetComponent<CreadorDePlanos>();
                    if (creadorPlanos != null)
                    {
                        if (PlanoSelecionado1 != null)
                        {
                            PlanoSelecionado2 = creadorPlanos;
                        }
                        if (PlanoSelecionado2 = null)
                        {
                            PlanoSelecionado1 = creadorPlanos;
                        }
                    }
                }
            }
        }
        
    }
    void SeleccioPlanos()
    {
        Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), touchposition, Quaternion.identity);
    }
    bool IsPointerOverUIObject(Vector2 pos)
    {
        if (EventSystem.current == null)
            return false;
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(pos.x, pos.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;

    }
}
