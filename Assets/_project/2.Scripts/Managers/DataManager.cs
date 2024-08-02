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
}