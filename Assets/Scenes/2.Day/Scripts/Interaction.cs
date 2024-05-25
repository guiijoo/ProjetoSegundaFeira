using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public TextMeshProUGUI missionText;
    public TextMeshProUGUI mensagemInteracao;
    public TextMeshProUGUI mensagemSair;

    public GameObject portaCasa;
    public GameObject portaBanco;
    public GameObject portaMercado;
    public GameObject portaIgreja;
    public GameObject portaAcademia;
    public GameObject casaDaia;
    public GameObject casaNovaDaia;
    public GameObject portaWesley;
    public GameObject cartaCpfl;
    public GameObject daiaTetao;
    public GameObject gordao;

    public GameObject jaula;

    public GameObject player;

    public bool podeSair;

    void Start()
    {
        float playerPosX = PlayerPrefs.GetFloat("playerPosX");
        float playerPosY = PlayerPrefs.GetFloat("playerPosY");
        float playerPosZ = PlayerPrefs.GetFloat("playerPosZ");
        if(playerPosX != 0)
        {
            Vector3 playerPosition = new Vector3(playerPosX, playerPosY, playerPosZ);
            player.transform.position = playerPosition;
        }
        if(GetComponent<MissionController>().praca == true)
        {
            SceneManager.LoadScene("Night");
        }
    }

    void Update()
    {
        if(GetComponent<MissionController>().academia == true)
        {
            jaula.gameObject.SetActive(true);
        }else{
            jaula.gameObject.SetActive(false);
        }

        if(Vector3.Distance(portaCasa.transform.position, player.transform.position) < 2f) //interagindo com a porta da casa
        {

            
            if(GetComponent<MissionController>().praCasa == false)
            {
                mensagemInteracao.text = "Aperte 'E' para entrar!";
                mensagemInteracao.gameObject.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("apertou");
                    Vector3 playerPosition = player.transform.position;
                    
                    PlayerPrefs.SetFloat("playerPosX", playerPosition.x);
                    PlayerPrefs.SetFloat("playerPosY", playerPosition.y);
                    PlayerPrefs.SetFloat("playerPosZ", playerPosition.z);
                    SceneManager.LoadScene("CasaCarlos");

                }

            }else if(GetComponent<MissionController>().praCasa == true){

                Debug.Log("voce ja fez essa missao");
                missionText.text = ("Você ja fez esta missão!");
                missionText.gameObject.SetActive(true);

            }

        }else if(Vector3.Distance(portaBanco.transform.position, player.transform.position) < 2f){ //interagindo com o banco

            if(GetComponent<MissionController>().praCasa == true && GetComponent<MissionController>().banco == false)
            {
                mensagemInteracao.text = "Aperte 'E' para entrar!";
                mensagemInteracao.gameObject.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("apertou");
                    Vector3 playerPosition = player.transform.position;
                    
                    PlayerPrefs.SetFloat("playerPosX", playerPosition.x);
                    PlayerPrefs.SetFloat("playerPosY", playerPosition.y);
                    PlayerPrefs.SetFloat("playerPosZ", playerPosition.z);
                    SceneManager.LoadScene("Banco");

                }
            }else if(GetComponent<MissionController>().banco == true)
            {
                Debug.Log("voce ja fez essa missao");
                missionText.text = ("Você ja fez esta missão!");
                missionText.gameObject.SetActive(true);
            }else{
                missionText.text = ("Você deve cumprir as outras missões antes!");
                missionText.gameObject.SetActive(true);
            }

        }else if(Vector3.Distance(portaMercado.transform.position, player.transform.position) < 2f){ //interagindo com o mercado

            if(GetComponent<MissionController>().banco == true && GetComponent<MissionController>().zebu == false)
            {
                mensagemInteracao.text = "Aperte 'E' para entrar!";
                mensagemInteracao.gameObject.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("apertou");
                    Vector3 playerPosition = player.transform.position;
                    
                    PlayerPrefs.SetFloat("playerPosX", playerPosition.x);
                    PlayerPrefs.SetFloat("playerPosY", playerPosition.y);
                    PlayerPrefs.SetFloat("playerPosZ", playerPosition.z);
                    SceneManager.LoadScene("InternoZebu");

                }
            }else if(GetComponent<MissionController>().zebu == true)
            {
                Debug.Log("voce ja fez essa missao");
                missionText.text = ("Você ja fez esta missão!");
                missionText.gameObject.SetActive(true);
            }else{
                missionText.text = ("Você deve cumprir as outras missões antes!");
                missionText.gameObject.SetActive(true);
            }

        }else if(Vector3.Distance(portaIgreja.transform.position, player.transform.position) < 2f){ //interagindo com a igreja

            if(GetComponent<MissionController>().zebu == true && GetComponent<MissionController>().igreja == false)
            {
                mensagemInteracao.text = "Aperte 'E' para entrar!";
                mensagemInteracao.gameObject.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    player.GetComponent<controleBaloesMissoes>().Igreja();
                    GetComponent<MissionController>().igreja = true;
                    mensagemInteracao.gameObject.SetActive(false);
                    PlayerPrefs.SetInt("igreja", 1); 
                }
            }else if(GetComponent<MissionController>().igreja == true)
            {
                Debug.Log("voce ja fez essa missao");
                missionText.text = "Pretos não são bem vindos aqui!";
                missionText.gameObject.SetActive(true);
            }else{
                missionText.text = ("Você deve cumprir as outras missões antes!");
                missionText.gameObject.SetActive(true);
            }

        }else if(Vector3.Distance(portaAcademia.transform.position, player.transform.position) < 2f){ //interagindo com a academia

            if(GetComponent<MissionController>().igreja == true && GetComponent<MissionController>().academia == false)
            {
                mensagemInteracao.text = "Aperte 'E' para entrar!";
                mensagemInteracao.gameObject.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("apertou");
                    Vector3 playerPosition = player.transform.position;
                    
                    PlayerPrefs.SetFloat("playerPosX", playerPosition.x);
                    PlayerPrefs.SetFloat("playerPosY", playerPosition.y);
                    PlayerPrefs.SetFloat("playerPosZ", playerPosition.z);
                    SceneManager.LoadScene("Academia");

                }
            }else if(GetComponent<MissionController>().academia == true)
            {
                missionText.text = ("Você ja fez esta missão!");
                missionText.gameObject.SetActive(true);
            }else{
                missionText.text = ("Você deve cumprir as outras missões antes!");
                missionText.gameObject.SetActive(true);
            }

        }else if(Vector3.Distance(jaula.transform.position, player.transform.position) < 5f){ //interagindo com a jaula

            if(GetComponent<MissionController>().academia == true && GetComponent<MissionController>().praca == false)
            {
                mensagemInteracao.text = "Aperte 'E' para inspecionar!";
                mensagemInteracao.gameObject.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    Vector3 playerPosition = player.transform.position;
                    PlayerPrefs.SetInt("jaula",1);
                    GetComponent<MissionController>().praca = true;
                    PlayerPrefs.SetFloat("playerPosX", playerPosition.x);
                    PlayerPrefs.SetFloat("playerPosY", playerPosition.y);
                    PlayerPrefs.SetFloat("playerPosZ", playerPosition.z);
                    SceneManager.LoadScene("Night");
                }
            }else if(GetComponent<MissionController>().praca == true)
            {
                Debug.Log("voce ja fez essa missao");
                missionText.text = ("Você ja fez esta missão!");
                missionText.gameObject.SetActive(true);
            }

        }else if(Vector3.Distance(casaDaia.transform.position, player.transform.position) < 15f) // casa da daia
        {
            mensagemInteracao.text = "Aperte 'E' para inspecionar!";
            mensagemInteracao.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                Vector3 posicaoPlayer = casaNovaDaia.transform.position;
                player.transform.position = posicaoPlayer;
                daiaTetao.GetComponent<AudioSource>().Play();
            }

        }else if(portaWesley.gameObject.activeSelf && Vector3.Distance(portaWesley.transform.position, player.transform.position) < 2f){ //interagindo com wesley
                mensagemInteracao.text = "Aperte 'E' para entrar!";
                mensagemInteracao.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Vector3 playerPosition = player.transform.position;
                    
                    PlayerPrefs.SetFloat("playerPosX", playerPosition.x);
                    PlayerPrefs.SetFloat("playerPosY", playerPosition.y);
                    PlayerPrefs.SetFloat("playerPosZ", playerPosition.z);
                    SceneManager.LoadScene("WesleyLavacar");
                }
        }else if(cartaCpfl.activeSelf && Vector3.Distance(cartaCpfl.transform.position, player.transform.position)<1.5){ // interagindo com a carta da CPFL

            if(podeSair == true)
            {
                mensagemSair.text = "Aperte 'E' para sair"; 
                mensagemSair.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    cartaCpfl.GetComponent<CartaCPFL>().FechaCarta();
                    player.GetComponent<controleBaloesMissoes>().Carta();
                    mensagemSair.gameObject.SetActive(false);
                    podeSair = false;
                }

            }else{
                mensagemInteracao.text = "Aperte 'E' para ver!";
                mensagemInteracao.gameObject.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {                
                    mensagemInteracao.gameObject.SetActive(false);    
                    cartaCpfl.GetComponent<CartaCPFL>().CartaAberta();
                    podeSair = true;
                }

            }

        }else if(gordao.activeSelf && Vector3.Distance(gordao.transform.position, player.transform.position)<2f){
            mensagemInteracao.text = "'E' para cutucar o Gordo!";
            mensagemInteracao.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                player.GetComponent<controleBaloesMissoes>().Gordao();
                mensagemInteracao.gameObject.SetActive(false);
            }
        }else{
                missionText.gameObject.SetActive(false);
                mensagemInteracao.gameObject.SetActive(false);
                mensagemSair.gameObject.SetActive(false);
        }
    }
}