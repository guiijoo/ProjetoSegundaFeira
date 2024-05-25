using UnityEngine;

public class mudaCor : MonoBehaviour
{
    // public ImageEditor panel;
    public Color32 corCarlos;
    public Color32 corCamila;
    public Color32 corGordao;

    public GameObject carlos;
    public GameObject camila;
    public GameObject gordao;

    public GameObject balaoFundo;

    UnityEngine.UI.Image corBalao;

    // Start is called before the first frame update
    void Start()
    {
        corBalao = balaoFundo.GetComponent<UnityEngine.UI.Image>();
    }

    public void BalaoCarlos()
    {
        camila.SetActive(false);
        gordao.SetActive(false);
        carlos.SetActive(true);
        corBalao.color = corCarlos;
    }

    public void BalaoCamila()
    {
        camila.SetActive(true);
        gordao.SetActive(false);
        carlos.SetActive(false);
        corBalao.color = corCamila;
    }

    public void BalaoGordao()
    {
        camila.SetActive(false);
        gordao.SetActive(true);
        carlos.SetActive(false);
        corBalao.color = corGordao;
    }
}
