using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public Image img_gaze;
    public GameObject player;
    public GameObject dialogue;
    public GameObject teleport;

    public void InspetorInteract()
    {
        img_gaze.fillAmount = 0;
        dialogue.SetActive(true);
        gameObject.GetComponent<EventTrigger>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        teleport.SetActive(false);
    }

    public void EndInspetorInteract()
    {
        dialogue.SetActive(false);
        teleport.SetActive(true);
        img_gaze.fillAmount = 0;
    }
}
