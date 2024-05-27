using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GVRClick : MonoBehaviour
{
    public Image img_gaze;
    public UnityEvent GVRClicked;
    public float total_time = 2f;
    bool gvr_status;
    float gvr_timer;

    public int distance_of_ray = 10;
    // Start is called before the first frame update
    void Start()
    {
        CancelInvoke();
        img_gaze.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gvr_status)
        {  
            CancelInvoke();
            gvr_timer += Time.deltaTime;
            img_gaze.fillAmount = gvr_timer/total_time;
        }
        if(gvr_timer>total_time)
        {
            GVRClicked.Invoke();
            gvr_timer = 0;
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
