using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolding : Spell
{
    public Transform guide;
    GameObject item;
    bool isHolding = false;

    public Texture crosshairSmall;
    public Texture crosshairBig;
    public Image crosshair;
    
    void FixedUpdate()
    {
        RaycastHit hit;
        if (isHolding)
        {
            item.transform.position = guide.position;
            if (Input.GetMouseButtonDown(0))
            {
                guide.GetChild(0).transform.parent = null;
                item.GetComponent<Rigidbody>().useGravity = true;
                item.GetComponent<Rigidbody>().freezeRotation = false;
                item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                item.GetComponent<Rigidbody>().velocity = Vector3.zero;
                item = null;
                isHolding = false;
            }
        }
        else if (Physics.Raycast(transform.position, transform.forward, out hit, 2f) && hit.collider.gameObject.CompareTag("Object"))
        {
            if (Input.GetMouseButtonDown(0) && !isHolding)
            {
                item = hit.collider.gameObject;
                item.GetComponent<Rigidbody>().freezeRotation = true;
                item.transform.SetParent(guide);
                item.GetComponent<Rigidbody>().useGravity = false;
                isHolding = true;
            }
            crosshair.rectTransform.localScale = Vector3.one * 4;
        }
        else
        {
            crosshair.rectTransform.localScale = Vector3.one * 2;
        }
    }
}
