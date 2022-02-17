using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody bulletRigid;
    [SerializeField] float speed;
    void Start()
    {
        bulletRigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        bulletRigid.AddRelativeForce(Vector3.forward * Time.deltaTime * speed);
    }
}
