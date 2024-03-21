using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Head1;
    public Transform Head2;
    public Transform Head3;
    float interpolation = 0.1f;
    void Start()
    {
        Head1.localScale = Vector3.zero;
        Head2.localScale = Vector3.zero;
        Head3.localScale = Vector3.zero;
        StartCoroutine(CreateBuilding());
    }
    IEnumerator CreateBuilding()
    {
        interpolation = 0;
        while (Head3.localScale.x < 1)
        {
            interpolation += Time.deltaTime;
            Head3.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, interpolation);
            yield return null;
        }
        interpolation = 0;
        while (Head2.localScale.x < 1)
        {
            //Debug.Log("hi");
            interpolation += Time.deltaTime;
            Head2.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, interpolation);
            yield return null;
        }
        interpolation = 0;
        while (Head1.localScale.x < 1)
        {
            interpolation += Time.deltaTime;
            Head1.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, interpolation);
            yield return null;
        }
        
    }
}
