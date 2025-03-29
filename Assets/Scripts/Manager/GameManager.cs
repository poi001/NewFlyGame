using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton
    /////////////////////////////////////////////////////////////////////////////////////////////////
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (instance == null) Debug.LogError("No GameManager");
            }

            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////


    //Player
    [HideInInspector] public PlayerCharacter Player;

    //Object
    [Header("Player")]
    [SerializeField] private GameObject PlayerObject;
    [Header("UI")]
    [SerializeField] private GameObject UICanavas;
    [Header("Tilemap")]
    [SerializeField] private GameObject Grid;

    public UIManager UIManager_ = new UIManager();

    private void Start()
    {
        //생성 순서 지켜야 함 ( 플레이어가 먼저 )
        Instantiate(PlayerObject, Vector2.zero, Quaternion.identity);   //Player
        UIManager_.Init(Instantiate(UICanavas));                        //UI
        Instantiate(Grid, Vector2.zero, Quaternion.identity);           //Grid
    }
}
