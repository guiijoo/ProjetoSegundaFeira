using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virarCpfl : MonoBehaviour
{
    public Transform player;
    public float velocidadeRotacao = 5f;

    void Update()
    {
        Vector3 direcaoDoPlayer = player.position - transform.position;
        direcaoDoPlayer.y = 0f;

        Quaternion rotacaoAlvo = Quaternion.LookRotation(direcaoDoPlayer);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAlvo, velocidadeRotacao * Time.deltaTime);
        
    }
}
