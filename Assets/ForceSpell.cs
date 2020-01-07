using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceSpell : MonoBehaviour
{
    float lifeTime = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime >= 2)
        {
            Destroy(this.gameObject);
        }
    }
}
