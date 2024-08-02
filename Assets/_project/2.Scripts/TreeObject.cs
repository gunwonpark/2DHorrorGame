using UnityEngine;

public class TreeObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _body;

    public void Init()
    {
        _body.sortingOrder = -(int)this.transform.position.y;
    }

    private void Reset()
    {
        _body = GetComponentInChildren<SpriteRenderer>();
    }
}
