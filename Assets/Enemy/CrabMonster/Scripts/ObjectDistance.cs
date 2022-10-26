using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDistance : MonoBehaviour
{
    public GameObject objA;
    public GameObject objB;

    [SerializeField] float distance;

    void Update()
    {
        Vector3 objectA = objA.transform.position;
        Vector3 objectB = objB.transform.position;
        float dis = Vector3.Distance(objectA, objectB);

        if (dis > distance)
        {
            objB.GetComponent<BossEnemy>().WalkStartSet(true);
        }
        else
        {
            objB.GetComponent<BossEnemy>().WalkStartSet(false);
        }
    }
}