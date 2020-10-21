using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValorsDeCordenades : MonoBehaviour
{
    [SerializeField]
    float maxNumberOfCubes = 50;
    float nombreSegment;
    float perSegment;

    [SerializeField]
    GameObject numero;

    public float valor;

    ValorAlIniciar valorquetoma;

    private void Awake()
    {
        valorquetoma = numero.GetComponent<ValorAlIniciar>();
    }
    private void Update()
    {
        if (nombreSegment <= maxNumberOfCubes)
        {
            Creat();
        }
    }
    void Creat()
    {
        nombreSegment += 1;
        perSegment = (nombreSegment);

        for (int i = 1; i < nombreSegment; i++)
        {
            //X
            Vector3 disxpos = new Vector3(transform.position.x + 0.1f* + i, transform.position.y, transform.position.z);
            Vector3 CreatPositionxpos = transform.position + (disxpos);
            Vector3 disxneg = new Vector3(transform.position.x + 0.1f * +i * -1, transform.position.y, transform.position.z);
            Vector3 CreatPositionxneg = transform.position + (disxneg);

            //Y
            Vector3 disypos = new Vector3(transform.position.x , transform.position.y + 0.1f * +i, transform.position.z);
            Vector3 CreatPositionypos = transform.position + (disypos);
            Vector3 disyneg = new Vector3(transform.position.x, transform.position.y + 0.1f * +i * -1, transform.position.z);
            Vector3 CreatPositionyneg = transform.position + (disyneg);

            //Z
            Vector3 diszpos = new Vector3(transform.position.x , transform.position.y, transform.position.z + 0.1f * +i);
            Vector3 CreatPositionzpos = transform.position + (diszpos);
            Vector3 diszneg = new Vector3(transform.position.x , transform.position.y, transform.position.z + 0.1f * +i * -1);
            Vector3 CreatPositionzneg = transform.position + (diszneg);

            valor = i;
            valorquetoma.valoress = valor;
            Instantiate(numero, CreatPositionxpos, Quaternion.identity);
            Instantiate(numero, CreatPositionxneg, Quaternion.identity);

            Instantiate(numero, CreatPositionypos, Quaternion.identity);
            Instantiate(numero, CreatPositionyneg, Quaternion.identity);

            Instantiate(numero, CreatPositionzpos, Quaternion.identity);
            Instantiate(numero, CreatPositionzneg, Quaternion.identity);

        }
    }
    }
