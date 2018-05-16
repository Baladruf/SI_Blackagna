using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Rewired;

public class MenuFlow : MonoBehaviour
{
    [Header("References")]
    public Text PressStart;
    public Text[] PlayerRefStart;
    public GameObject[] PlayerRefReady;

    //--------------------------------------------------------
    private float _pulseValue;
    private bool _isStartScreen = true;

    private void Start()
    {
        _pulseValue = 0.44f;

        StartCoroutine(Pulse());
    }

	public void StartPressed()
    {
        _pulseValue = 0.13f;
    }

    public void ReadyPressed(int playerID)
    {
        PlayerRefStart[playerID].gameObject.SetActive(false);
        PlayerRefReady[playerID].SetActive(true);

        if (PlayerRefReady[0] && PlayerRefReady[1] && PlayerRefReady[2] && PlayerRefReady[3])
            Debug.Log("Start Game");
    }

    IEnumerator Pulse()
    {
        while (true)
        {
            Tween twFdO = PressStart.DOFade(0.2f, _pulseValue);
            yield return new WaitWhile(twFdO.IsPlaying);
            Tween twFdI = PressStart.DOFade(0.8f, _pulseValue);
            yield return new WaitWhile(twFdI.IsPlaying);
        }
    }
}
