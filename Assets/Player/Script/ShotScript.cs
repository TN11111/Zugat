using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    
    [SerializeField] public float speed;
    private Rigidbody rb;
    private int life;
    private Vector3 forward;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        life = 1200;
        forward = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = forward * speed;

        life--;
        if (life < 0)
        {
            Destroy(gameObject);
        }
    }

    //�I�u�W�F�N�g�ƐڐG�����u�ԂɌĂяo�����
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "CrabMonster 1")
        {
            Destroy(gameObject);
        }
    }
}
