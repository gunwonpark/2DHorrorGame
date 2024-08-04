using UnityEngine;

[CreateAssetMenu(fileName = "Datas", menuName = "Datas")]
public class DataManager : ScriptableObject
{
    public static DataManager Instance { get; private set; }
    public void Init()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    [Header("Player")]
    public float playerMoveSpeed = 5f;

    [Header("Monster")]
    public float monsterMoveSpeed = 3f;
    public Monster monsterPrefab;

    [Tooltip("추후 Addressable로 변경할 예정")]
    [Header("UI")]
    public GameEndUI gameEndUI;
}