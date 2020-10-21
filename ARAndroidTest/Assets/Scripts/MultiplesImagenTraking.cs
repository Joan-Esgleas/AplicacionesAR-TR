using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class MultiplesImagenTraking : MonoBehaviour
{
    [SerializeField]
    private GameObject[] arObjectsPrefabs;
    [SerializeField]
    private Vector3 EscalaDeLosPrefabas = new Vector3(0.1f, 0.1f, 0.1f);
    [SerializeField]
    private Text NobreDeImagenText;

    private ARTrackedImageManager trackedImageManager;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();

    void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
        foreach (GameObject arObject in arObjectsPrefabs)
        {
            GameObject newARObject = Instantiate(arObject, Vector3.zero, Quaternion.identity);
            newARObject.SetActive(false);
            newARObject.name = arObject.name;
            arObjects.Add(arObject.name, newARObject);
        }
    }

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }


    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateARImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateARImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            arObjects[trackedImage.name].SetActive(false);
        }
    }

    private void UpdateARImage(ARTrackedImage trackedImage)
    {
        NobreDeImagenText.text = trackedImage.referenceImage.name;
        AssignGameObject(trackedImage.referenceImage.name, trackedImage.transform.position);
    }

    void AssignGameObject(string name, Vector3 newPosition)
    {
        if (arObjectsPrefabs != null)
        {
            arObjects[name].SetActive(true);
            arObjects[name].transform.position = newPosition;
            arObjects[name].transform.localScale = EscalaDeLosPrefabas;
            //foreach (GameObject go in arObjects.Values)
            //{
             //   if (go.name != name)
             //   {
             //       go.SetActive(false);
             //   }
            //}
        }
    }
}