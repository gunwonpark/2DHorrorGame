using UnityEngine;
using UnityEngine.UI;

public class GameEndUI : MonoBehaviour
{
    [SerializeField] private Image _gameEndImage;
    public void Init()
    {
        GameEnd();
    }

    public void GameEnd()
    {
        _gameEndImage.gameObject.SetActive(true);
    }
}
