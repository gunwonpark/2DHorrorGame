using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    [SerializeField] private Transform[] _lightPosition;
    [SerializeField] private Light2D _light;
    private int _curIndex = 3;
    public void Init()
    {
        _light.transform.SetParent(_lightPosition[_curIndex].transform);
    }
    public void RePosition(Vector2 _dir)
    {
        int _index = 0;
        if (_dir == Vector2.left)
        {
            _index = 0;
        }
        else if (_dir == Vector2.right)
        {
            _index = 1;
        }
        else if (_dir == Vector2.up)
        {
            _index = 2;
        }
        else if (_dir == Vector2.down)
        {
            _index = 3;
        }
        if (_curIndex != _index)
        {
            _curIndex = _index;
            _light.transform.SetParent(_lightPosition[_curIndex].transform);
            _light.transform.localPosition = Vector3.zero;
            _light.transform.localRotation = Quaternion.identity;
        }
    }
    public void Reset()
    {
        this._lightPosition = new Transform[4];

        GameObject gameObject = new GameObject("leftPosition");
        gameObject.transform.SetParent(this.transform);
        GameObject gameObject2 = new GameObject("rightPosition");
        gameObject2.transform.SetParent(this.transform);
        GameObject gameObject3 = new GameObject("upPosition");
        gameObject3.transform.SetParent(this.transform);
        GameObject gameObject4 = new GameObject("downPosition");
        gameObject4.transform.SetParent(this.transform);

        _lightPosition[0] = gameObject.transform;
        _lightPosition[1] = gameObject2.transform;
        _lightPosition[2] = gameObject3.transform;
        _lightPosition[3] = gameObject4.transform;
    }
}
