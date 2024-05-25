using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public bool poderMaximo = false;
    public float velocidadeCorrida = 5;
    public float velocidadeAndar = 2;
    public AudioSource audioPassos;
    public Camera cameraPlayer;
    public TextMeshProUGUI textoAlteres;
    public TextMeshProUGUI textoInicial;
    public Transform cinderella;
    public Transform cinderellaBaiana;


    private float velocidadePlayer;
    private Vector3 direcoes;
    private Animator anim;
    private int contAltere = 0;
    private GameObject inimigo;

    void Start()
    {
        // Vector3 playerPosition = transform.position;
        anim = GetComponent<Animator>();
        textoAlteres.gameObject.SetActive(false);
        inimigo = GameObject.FindWithTag("inimigo");
        StartCoroutine(MensagemInicial());
    }

    void Update()
    {
        float InputX = Input.GetAxis("Horizontal");
        float InputZ = Input.GetAxis("Vertical");
        float InputRun = Input.GetAxis("correr");

        direcoes = new Vector3(InputX,0, InputZ);
        if(InputX != 0 || InputZ != 0)
        {
            var camrotation = cameraPlayer.transform.rotation;
            camrotation.x = 0;
            camrotation.z = 0;
            anim.SetBool("walk", true);
            transform.Translate(0, 0, velocidadePlayer * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direcoes) * camrotation, 5 * Time.deltaTime);

            if(InputRun != 0)
            {
                anim.SetBool("run", true);
                velocidadePlayer = velocidadeCorrida;
            }
            else
            {
                anim.SetBool("run", false);
                velocidadePlayer = velocidadeAndar;
            }
        }
        else if (InputX == 0 && InputZ == 0)
        {
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "altere")
        {
            contAltere++;

            if(contAltere == 7)
            {
                inimigo.GetComponent<Enemy>().raiva = true;
                cinderellaBaiana.gameObject.SetActive(true);
                cinderella.gameObject.SetActive(false);
            }

            if(contAltere == 10)
            {
                poderMaximo = true;
            }

            if(contAltere % 2 == 0)
            {
                inimigo.GetComponent<Enemy>().velocidadeOriginal*=1.2f;
            }

            StartCoroutine(TextoAltere());
        }
        if(collider.gameObject.tag == "peCind")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private IEnumerator MensagemInicial()
    {
        textoInicial.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        textoInicial.gameObject.SetActive(false);
    } 

    private IEnumerator TextoAltere()
    {
        textoAlteres.gameObject.SetActive(true);
        textoAlteres.text = "Você coletou "+ contAltere +" de 10 Alteres!";
        yield return new WaitForSeconds(3f);
        textoAlteres.gameObject.SetActive(false);
    }

    public void SonsPassos()
    {
        audioPassos.Play();
    }
}
