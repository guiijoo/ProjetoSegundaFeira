using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VRGaze : MonoBehaviour
{

    public Image img_gaze;
    public float total_time = 2f;
    bool gvr_status;
    float gvr_timer;

    public int distance_of_ray = 10;
    private RaycastHit _hit;

    // Start is called before the first frame update
    void Start()
    {
        img_gaze.fillAmount = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gvr_status)
        {
            gvr_timer += Time.deltaTime;
            img_gaze.fillAmount = gvr_timer/total_time;
        }


        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0f));

        if(Physics.Raycast(ray, out _hit, distance_of_ray))
        {
            if(img_gaze.fillAmount == 1 && _hit.transform.CompareTag("Teleport"))
            {
                _hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();

            }else if(img_gaze.fillAmount == 1 && _hit.transform.CompareTag("Inspetor"))
            {

                _hit.transform.gameObject.GetComponent<Interact>().InspetorInteract();

            }else if(img_gaze.fillAmount == 1 && _hit.transform.CompareTag("Friend"))
            {

                _hit.transform.gameObject.GetComponent<Interact>().InspetorInteract();

            }else if(img_gaze.fillAmount == 1 && _hit.transform.CompareTag("MarketDoor"))
            {

                SceneManager.LoadScene("Market");

            }else if(img_gaze.fillAmount == 1 && _hit.transform.CompareTag("BathroomDoor"))
            {

                SceneManager.LoadScene("Bathroom");

            }else if(img_gaze.fillAmount == 1 && _hit.transform.CompareTag("BathroomExit"))
            {

                SceneManager.LoadScene("Market2");

            }else if(img_gaze.fillAmount == 1 && _hit.transform.CompareTag("MarketExit"))
            {

                SceneManager.LoadScene("Out2");

            }else if(img_gaze.fillAmount == 1 && _hit.transform.CompareTag("Iniciar"))
            {

                SceneManager.LoadScene("Out");

            }
        }
        
    }

    public void GVROn()
    {
        gvr_status = true;
    }

    public void GVROff()
    {
        gvr_status = false;
        gvr_timer = 0;
        img_gaze.fillAmount = 0;
    }
}
