using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceSpell : MonoBehaviour
{
    float lifeTime = 0;
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rig = other.GetComponent<Rigidbody>();
        if (rig && !other.gameObject.CompareTag("Destructible"))
        {
            rig.AddForce(transform.forward * 200f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime >= 2)
        {
            Destroy(gameObject);
        }
    }
}
