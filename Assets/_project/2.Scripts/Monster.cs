using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float maxX = 30f;
    public float maxY = 30f;
    public float minX = -30f;
    public float minY = -30f;

    private Vector2 _nextPos;

    private void Start()
    {
        // 추후 다른곳에서 실행해 줘야 된다.
        Init();
    }
    public void Init()
    {
        Move();
    }

    void DeActive()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }

    private void Move()
    {
        StartCoroutine(C_Move());
    }

    private IEnumerator C_Move()
    {
        _nextPos = GetRandomPos();
        while (true)
        {
            Vector2 _curPosition = this.transform.position;

            if (Vector2.Distance(_curPosition, _nextPos) < 0.1f)
            {
                _nextPos = GetRandomPos();
            }

            Vector2 _moveDir = (_nextPos - _curPosition).normalized;
            _moveDir *= Time.deltaTime * DataManager.Instance.monsterMoveSpeed;
            this.transform.Translate(_moveDir);

            yield return null;
        }
    }

    private Vector2 GetRandomPos()
    {
        return new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }
}
