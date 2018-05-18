using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public static bool gameStarted = false;
    public Transform playersControllers;
    public Cadavre cadavre;
    public PlayerController[] players;
    private int countRuche = 4;
    //[SerializeField] Text textVictoire;
    [SerializeField] float delayVictory = 3;
    [SerializeField] Image[] wonPlayer;
    [SerializeField] float delayFade = 0.5f;
    [SerializeField] Image[] destroyRuche;
    private List<int> idRucheDestroy;
    private bool isDestroyRucheAnime = false;
    [SerializeField] float delayFadeRucheDestroy = 0.5f;
    [SerializeField] float delayPrintDestroyRuche = 0.5f;
    private bool transitionWin = false;

    private void Awake()
    {
        Instance = this;
        players = new PlayerController[4];
        for(int i = 0; i < 4; i++)
        {
            players[i] = playersControllers.GetChild(i).GetComponent<PlayerController>();
        }
        cadavre = playersControllers.GetChild(4).GetComponent<Cadavre>();
        idRucheDestroy = new List<int>();
    }

    private void Start()
    {
        gameStarted = true;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if(countRuche <= 1 && !transitionWin){
            int monsterRestant = 0;
            int rank = 0;
            for(int i = 0; i < players.Length; i++){
                if(!players[i].isDead){
                    rank = i;
                    monsterRestant++;
                }
            }
            if(monsterRestant == 1){
                transitionWin = true;
                StartCoroutine(ChangeScene(rank));
            }
        }

        if(!isDestroyRucheAnime && idRucheDestroy.Count > 0)
        {
            isDestroyRucheAnime = true;
            StartCoroutine(PrintDestroyRuche());
        }
    }

    public void RucheCount(){
        countRuche--;
    }

    private IEnumerator ChangeScene(int rank)
    {
        wonPlayer[rank].DOFade(1, delayFade);
        wonPlayer[rank].transform.GetChild(0).GetComponent<Image>().DOFade(1, delayFade);
        yield return new WaitForSeconds(delayVictory + delayFade);
        wonPlayer[rank].transform.GetChild(0).GetComponent<Image>().DOFade(0, delayFade);
        wonPlayer[rank].DOFade(0, delayFade).OnComplete(() =>
        {
            //SceneManager.LoadScene("Scenes/");
        });
    }

    private IEnumerator PrintDestroyRuche()
    {
        destroyRuche[idRucheDestroy[0]].DOFade(1, delayFadeRucheDestroy);
        destroyRuche[idRucheDestroy[0]].transform.GetChild(0).GetComponent<Image>().DOFade(1, delayFadeRucheDestroy);
        yield return new WaitForSeconds(delayPrintDestroyRuche + delayFadeRucheDestroy);
        destroyRuche[idRucheDestroy[0]].transform.GetChild(0).GetComponent<Image>().DOFade(0, delayFadeRucheDestroy);
        destroyRuche[idRucheDestroy[0]].DOFade(0, delayFadeRucheDestroy).OnComplete(() =>
        {
            idRucheDestroy.RemoveAt(0);
            isDestroyRucheAnime = false;
        });
    }

    public void AddIdDestroyRuche(int id)
    {
        idRucheDestroy.Add(id);
    }
}
