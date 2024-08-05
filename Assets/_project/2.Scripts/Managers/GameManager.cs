using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private DataManager _dataManager;
    [SerializeField] private SoundManager _soundManager;
    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _dataManager.Init();
        _soundManager.Init();
    }
}