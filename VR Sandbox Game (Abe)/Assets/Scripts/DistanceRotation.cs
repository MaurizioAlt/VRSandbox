using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;



public class DistanceRotation : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("InteractableObject"))
            return;

        HandGrabbing.m_ContactInteractables.Add(other.gameObject.GetComponent<InteractableObj>());

        Debug.Log("Detected interactable");
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("InteractableObject"))
            return;

        HandGrabbing.m_ContactInteractables.Remove(other.gameObject.GetComponent<InteractableObj>());

        Debug.Log("UNDetected interactable");
    }

    // Update is called once per frame
    void Update()
    {

    }


}
