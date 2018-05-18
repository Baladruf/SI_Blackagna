using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Rewired;

public class MenuFlow : MonoBehaviour
{
    [Header("Start Menu")]
    public Image TitleLogo;
    public Text TitleText;
    public Text PressStart;
    public Text CreditText;

    [Header("Player Menu")]
    public GameObject PlayerMenu;
    public Text[] PlayerRefStart;
    public GameObject[] PlayerRefReady;

    //--------------------------------------------------------
    private float _pulseValue;
    private bool _pulsing;
    private bool _isStartScreen = true;

    private void Start()
    {
        _pulseValue = 0.44f;
        _pulsing = true;
        StartCoroutine(Pulse());
    }

	public void StartPressed()
    {
        _pulseValue = 0.13f;
        StartCoroutine(StartToPlayer());
    }

    public void ReadyPressed(int playerID)
    {
        PlayerRefStart[playerID].gameObject.SetActive(false);
        PlayerRefReady[playerID].SetActive(true);

        if (PlayerRefReady[0].activeSelf && PlayerRefReady[1].activeSelf && PlayerRefReady[2].activeSelf && PlayerRefReady[3].activeSelf)
        {
            SceneManager.LoadScene("Scenes/FINAL_SCENE_SAVE");
        }
            //Debug.Log("Start Game");
    }

    IEnumerator Pulse()
    {
        while (_pulsing)
        {
            Tween twFdI = PressStart.DOFade(0.8f, _pulseValue);
            yield return new WaitWhile(twFdI.IsPlaying);
            Tween twFdO = PressStart.DOFade(0.0f, _pulseValue);
            yield return new WaitWhile(twFdO.IsPlaying);
        }
        PressStart.DOFade(0.0f, 0.15f);

    }

    IEnumerator StartToPlayer()
    {
        yield return new WaitForSeconds(0.1f);
        _pulsing = false;
        DOTween.Clear();

        Tween twTLO = TitleLogo.DOFade(0.0f, 0.15f);
        TitleText.DOFade(0.0f, 0.15f);
        CreditText.DOFade(0.0f, 0.15f);
        yield return new WaitWhile(twTLO.IsPlaying);

        PlayerMenu.SetActive(true);
    }
}
