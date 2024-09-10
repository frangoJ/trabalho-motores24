using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI hud, msgvitoria;
    public int restantes;
    public AudioClip clipmoeda, clipvitoria;

    private AudioSource sources;
    void Start()
    {
        TryGetComponent(out sources);
        restantes = FindObjectsOfType<Moeda>().Length;

        hud.text = $"moedas restantes : {restantes}";
        
    }
    
    public void subtraimoedas(int valor)

    {
        restantes -= valor;
        hud.text = $"moedas restantes: {restantes}";
        sources.PlayOneShot(clipmoeda);

        if (restantes <= 0)
        {
            //ganhou o game ne pai
            msgvitoria.text = "parabéns";
            sources.Stop();
            sources.PlayOneShot(clipvitoria);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
