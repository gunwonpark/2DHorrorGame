using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct MoveLimitList
{
    //单捞磐肺 包府矫 vector2肺 包府
    public Transform moveMaxLimit;
    public Transform moveMinLimit;
}

public class MonsterSpawner : MonoBehaviour
{
    private List<Monster> _monsters = new List<Monster>();
    [SerializeField] private MoveLimitList[] _moveLimitList;

    private void Start()
    {
        Init();
    }
    public void Init()
    {
        SpawnMonster();
    }

    public void SpawnMonster(int _count = 1)
    {

        for (int i = 0; i < _count; i++)
        {
            Monster _monster = Instantiate(DataManager.Instance.monsterPrefab);
            if (_monster == null)
            {
                Debug.LogError("Monster is null");
                return;
            }

            int _randomIndex = UnityEngine.Random.Range(0, _moveLimitList.Length);

            _monster.Init(_moveLimitList[_randomIndex].moveMaxLimit.position, _moveLimitList[_randomIndex].moveMinLimit.position);
            _monsters.Add(_monster);


        }
    }

}
