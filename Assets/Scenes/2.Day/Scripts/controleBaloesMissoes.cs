using System.Collections;
using TMPro;
using UnityEngine;

public class controleBaloesMissoes : MonoBehaviour
{
    public GameObject balaoTexto;
    public GameObject balaoCor;
    public TextMeshProUGUI textoBalao;
    public  GameObject cameraa;
    public TextMeshProUGUI sair;
    public TextMeshProUGUI texto_missao;
    public GameObject arco;
    public GameObject wesley;
    public GameObject colJaula;
    public GameObject aaaaaai;
    public GameObject nonono;
    public GameObject sonsIncompeensiveis;
    public GameObject saidaIgreja;
    public GameObject portaEcamila;
    public GameObject camilaMexicana;
    public GameObject taGostosinha;
    public GameObject carta;
    public GameObject cartaOBJ;
    public GameObject caiuLuz;
    public GameObject ronco;
    public GameObject gordao;
    public GameObject canva_missao_canto;

    public AudioSource audio;

    bool sairBool;
    public int dialogos;

    bool casa;
    bool banco;
    bool zebu;
    bool igreja;
    bool academia;
    bool praca;


    float velocidadePlayerA;
    float velocidadePlayerC;
    float sensibilidadeCamera;

    void Awake()
    {
        casa = PlayerPrefs.GetInt("praCasa", 0) == 1;
        banco = PlayerPrefs.GetInt("banco", 0) ==1;
        zebu = PlayerPrefs.GetInt("zebu", 0) == 1;
        igreja = PlayerPrefs.GetInt("igreja", 0) == 1;
        academia = PlayerPrefs.GetInt("academia", 0) == 1;
        praca = PlayerPrefs.GetInt("praca",0) == 1;

        velocidadePlayerA = GetComponent<Player>().velocidadeAndar;
        velocidadePlayerC = GetComponent<Player>().velocidadeCorrida;
        sensibilidadeCamera = cameraa.GetComponent<CameraController>().Sensibilidade;

        if(casa == false)
        {
            texto_missao.text = "Vá para sua casa.";
            textoBalao.text = "Ow shit... Here we go again!";
            audio.Play();
            StartCoroutine(Texto());
        }else if(casa == true && banco == false)
        {
            canva_missao_canto.SetActive(true);
            texto_missao.text = "Roube um Banco.";
            nonono.GetComponent<AudioSource>().Play();
            textoBalao.text = "Nossa, mas estou sem dinheiro...\nHum... Será que consigo roubar um banco?";
            StartCoroutine(Texto());
        }else if(banco == true && zebu == false)
        {
            canva_missao_canto.SetActive(true);
            texto_missao.text = "Roube o mercado.";
            sonsIncompeensiveis.GetComponent<AudioSource>().Play();
            textoBalao.text = "Agora posso ir \"comprar\" coca e pão para minha mãe!";
            StartCoroutine(Texto());
        }else if(zebu == true && igreja == false)
        {
            canva_missao_canto.SetActive(true);
            texto_missao.text = "Leve os itens para sua mãe.";
            textoBalao.text = "Pronto, agora só entregar para ela.\nEla disse que estava na missa, ela sempre vai na igreja da praça.";
            StartCoroutine(Texto());
        }else if(academia == true && praca == false)
        {
            canva_missao_canto.SetActive(true);
            texto_missao.text = "Veja o que aconteceu na praça!";
            portaEcamila.GetComponent<AudioSource>().Play();
            textoBalao.text = "O que foi isso?!\nParece ter vindo da praça.";
            StartCoroutine(Texto());
        }
    }
    void Update()
    {
        if(!carta.activeSelf && balaoTexto.activeSelf)
        {
            cameraa.GetComponent<CameraController>().Sensibilidade = 0;
            GetComponent<Player>().velocidadeAndar = 0;
            GetComponent<Player>().velocidadeCorrida = 0;
            GetComponent<Animator>().SetBool("lendo", true);
            wesley.SetActive(false);
            cartaOBJ.SetActive(false);
            gordao.SetActive(false);

        }else if(carta.activeSelf && !balaoTexto.activeSelf)
        {
            cameraa.GetComponent<CameraController>().Sensibilidade = 0;
            GetComponent<Player>().velocidadeAndar = 0;
            GetComponent<Player>().velocidadeCorrida = 0;
            GetComponent<Animator>().SetBool("lendo", true);
            wesley.SetActive(false);
        }else{
            cameraa.GetComponent<CameraController>().Sensibilidade = sensibilidadeCamera;
            GetComponent<Player>().velocidadeAndar = velocidadePlayerA;
            GetComponent<Player>().velocidadeCorrida = velocidadePlayerC;
            GetComponent<Animator>().SetBool("lendo", false);
            wesley.SetActive(true);
            cartaOBJ.SetActive(true);
            gordao.SetActive(true);
        }


        if(sairBool == true)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    sair.gameObject.SetActive(false);
                    balaoTexto.SetActive(false);
                    sairBool = false;
                }
            }

        if(dialogos == 1)
        {
            if(Input.GetKeyDown(KeyCode.E))
                {
                    sair.gameObject.SetActive(false);
                    balaoTexto.SetActive(false);
                    dialogos++;
                    taGostosinha.GetComponent<AudioSource>().Play();
                }
        }else if(dialogos == 2)
        {
            textoBalao.text = "Ta gostosinha";
            StartCoroutine(FalaCarlos());
        }else if(dialogos == 3)
        {
            if(Input.GetKeyDown(KeyCode.E))
                {
                    sair.gameObject.SetActive(false);
                    balaoTexto.SetActive(false);
                    dialogos++;
                }
        }else if(dialogos > 3)
        {
            dialogos = 0;
            sair.gameObject.SetActive(false);
            balaoTexto.SetActive(false);
            
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "passaArco" && casa == false)
        {
            canva_missao_canto.SetActive(true);
            aaaaaai.GetComponent<AudioSource>().Play();
            textoBalao.text = "Preciso ir para casa!\nMinha mãe deve estar preocupada!";
            arco.SetActive(false);
            StartCoroutine(Texto());
        }else if(collider.gameObject.tag == "jaula" && academia == true){
            canva_missao_canto.SetActive(true);
            texto_missao.text = "Vá conquistar o Shape!";
            textoBalao.text = "Ai Ai Ai Carlos. Ayuada me, soy Yo, Camila Mexicana!";
            colJaula.SetActive(false);
            camilaMexicana.GetComponent<AudioSource>().Play();
            StartCoroutine(FalaCamila());
        }
    }

    public void Carta()
    {
        caiuLuz.GetComponent<AudioSource>().Play();
        textoBalao.text = "Pelo visto o prefeito não pagou a conta.\nVamos ficar sem luz hoje.\nAinda bem que sempre ando com minha lanterna!";
        balaoTexto.GetComponent<mudaCor>().BalaoCarlos();
        StartCoroutine(Texto());
    }

    public void Gordao()
    {
        ronco.GetComponent<AudioSource>().Play();
        textoBalao.text = "zzzzzzzzzzzzzzz...";
        balaoTexto.GetComponent<mudaCor>().BalaoGordao();
        StartCoroutine(Texto());
    }

    public void Igreja()
    {
        texto_missao.text = "Vá conquistar o shape!";  
        saidaIgreja.GetComponent<AudioSource>().Play();
        textoBalao.text = "Holly shit police motherfucker!\nEntão, já que é assim, vou conquistar o shape para as Primas!\nAté lá a missa já acabou.";
        balaoTexto.GetComponent<mudaCor>().BalaoCarlos();
        StartCoroutine(Texto());
    }

    IEnumerator Texto()
    {
        balaoTexto.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        sair.gameObject.SetActive(true);
        sairBool = true;
    }

    IEnumerator FalaCamila()
    {
        balaoTexto.GetComponent<mudaCor>().BalaoCamila();
        balaoTexto.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        sair.gameObject.SetActive(true);
        dialogos++;
    }

    IEnumerator FalaCarlos()
    {
        balaoTexto.GetComponent<mudaCor>().BalaoCarlos();
        balaoTexto.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        sair.gameObject.SetActive(true);
        dialogos = 3;
    }
}
