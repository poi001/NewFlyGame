using UnityEngine;
using System.Collections;

public enum EParticleType
{
    ITEM = 0,
    CRASH = 1
}

[System.Serializable]
public class ParticleClass
{
    [field: SerializeField] public GameObject GetItemParticle { get; private set; }
    [field: SerializeField] public GameObject CrashParticle { get; private set; }
}

public class GameManager : MonoBehaviour
{
    //Singleton
    /////////////////////////////////////////////////////////////////////////////////////////////////
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
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
    [Header("UI")]
    public GameObject OptionsUICanavas;
    [Header("Tilemap")]
    [SerializeField] private GameObject Grid;
    [Header("Item")]
    [SerializeField] private GameObject Item;
    [Header("Particle")]
    public ParticleClass Particles;

    public UIManager UIManager_ = new UIManager();

    public void StartStage1()
    {
        //���� ���� ���Ѿ� �� ( �÷��̾ ����, Stage�� �� �� UIManager�� �ִ� UI�� ���� �Ǵµ�, �� �� �÷��̾� ������ �ʿ��� )
        Instantiate(PlayerObject, Vector2.zero, Quaternion.identity);   //Player
        UIManager_.Init(Instantiate(UICanavas));                        //UI
        Instantiate(Grid, Vector2.zero, Quaternion.identity);           //Grid
        Instantiate(Item, Vector2.zero, Quaternion.identity);           //Item
    }

    public void ActiveParticle(EParticleType _particleType, Vector2 _pos)
    {
        GameObject returnObject_ = null;

        switch (_particleType)
        {
            case EParticleType.ITEM:
                returnObject_ = Instantiate(Particles.GetItemParticle, _pos, Quaternion.identity);
                break;
            case EParticleType.CRASH:
                returnObject_ = Instantiate(Particles.CrashParticle, _pos, Quaternion.identity);
                break;
            default:
                break;
        }

        StartCoroutine(Coroutine_DeleteParticle(returnObject_));
    }

    IEnumerator Coroutine_DeleteParticle(GameObject _go)
    {
        ParticleSystem ps_ = _go.GetComponent<ParticleSystem>();

        yield return new WaitUntil(() => !(ps_.IsAlive()));
        Destroy(_go);
    }
}
