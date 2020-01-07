using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public GameObject player;
    bool left_hand_release;
    bool right_hand_release;

    // Telekinesis
    bool telekinesis = false;
    bool kinesis_held;
    public Transform tele_guide;
    public GameObject item;
    float moveStartTime;
    float tele_release = 0;
    int kinesis_hand;

    // Force
    public GameObject forceObject;

    public void Cast(string name, int hand)
    {
        // Telekinesis
        if (name == "Telekinesis")
        {
            RaycastHit hit;
            if (telekinesis)
            {
                tele_release += 0.1f;
            }
            else if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, 5f) && hit.collider.gameObject.CompareTag("Object"))
            {
                item = hit.collider.gameObject;
                item.GetComponent<Rigidbody>().freezeRotation = true;
                item.GetComponent<Rigidbody>().useGravity = false;
                telekinesis = !telekinesis;
                moveStartTime = Time.time;
                tele_release = 0;
                kinesis_hand = hand;
            }
        }

        // Force
        if (name == "Force" && !left_hand_release)
        {
            GameObject tempForce = Instantiate(forceObject, player.transform.position + player.transform.forward, player.transform.rotation);
            tempForce.GetComponent<Rigidbody>().velocity = Vector3.zero;
            print(tempForce.transform.forward);
            tempForce.GetComponent<Rigidbody>().AddForce(tempForce.transform.forward * 1000);
        }

        if (hand == 0)
        {
            right_hand_release = true;
        }
        else
        {
            left_hand_release = true;
        }
    }

    private void FixedUpdate()
    {
        if (!Input.GetMouseButton(0))
        {
            right_hand_release = false;
        }
        if (!Input.GetMouseButton(1))
        {
            left_hand_release = false;
        }
        // Telekinesis
        if (telekinesis)
        {
            item.GetComponentInChildren<ParticleSystem>().emissionRate = Math.Min(tele_release, 15);
            item.GetComponent<ParticleSystemForceField>().gravity = 1;
            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = Math.Min(Vector3.Distance(item.transform.position, tele_guide.position), 0.1f) / 1;

            // Set our position as a fraction of the distance between the markers.
            item.transform.position = Vector3.Lerp(item.transform.position, tele_guide.position, fractionOfJourney);

            if (!Input.GetMouseButton(kinesis_hand) && tele_release >= 0)
            {

                item.GetComponent<Rigidbody>().useGravity = true;
                item.GetComponent<Rigidbody>().freezeRotation = false;
                item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                item.GetComponent<Rigidbody>().velocity = player.transform.forward * Math.Min(tele_release, 15);
                item.GetComponentInChildren<ParticleSystem>().emissionRate = 0;
                item.GetComponent<ParticleSystemForceField>().gravity = 0;
                item = null;
                telekinesis = !telekinesis;
                tele_release = 0;
            }
        }
    }
}