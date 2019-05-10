using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;
    [SerializeField] private SettingPopup settingPopup;
    private int score;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    private void Start()
    {
        score = 0;
        scoreLabel.text = score.ToString();
        settingPopup.Close();
    }

    private void OnEnemyHit()
    {
        score++;
        scoreLabel.text = score.ToString();
    }

    public void OnOpenSettings()
    {
        settingPopup.Open();
    }

    public void OnPointerDown()
    {
        Debug.Log("POINTER DOWN");
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }
}
