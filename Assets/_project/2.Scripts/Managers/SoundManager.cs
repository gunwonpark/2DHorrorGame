using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _Bgm = null;
    [SerializeField] private AudioSource[] _Sfx = null;

    private int sfxID;

    public void Init()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        this.sfxID = 0;
    }

    public void PlayBgm(BgmType _bgmType)
    {
        DataManager.BgmData _bgmData = DataManager.Instance.GetBGMData(_bgmType);
        this._Bgm.clip = _bgmData.clip;
        this._Bgm.volume = _bgmData.volume;
        this._Bgm.Play();
    }
    public void StopBgm()
    {
        this._Bgm.Stop();
    }

    public void PlaySfx(SfxType _sfxType)
    {
        DataManager.SfxData _sfxData = DataManager.Instance.GetSfxData(_sfxType);

        AudioSource _sfx = this._Sfx[this.sfxID];
        _sfx.volume = _sfxData.volume;
        _sfx.PlayOneShot(_sfxData.clip);

        if (this.sfxID + 1 < this._Sfx.Length)
            this.sfxID++;
        else
            this.sfxID = 0;
    }

    private void Reset()
    {
        if (this._Bgm == null)
        {
            GameObject _bgmObj = new GameObject("Bgm");
            _bgmObj.transform.SetParent(this.transform);
            this._Bgm = _bgmObj.AddComponent<AudioSource>();
        }

        if (this._Sfx == null)
        {
            this._Sfx = new AudioSource[DataManager.Instance.maxSfxCount];

            for (int i = 0; i < DataManager.Instance.maxSfxCount; i++)
            {
                GameObject _sfxObj = new GameObject("Sfx" + i);
                _sfxObj.transform.SetParent(this.transform);
                this._Sfx[i] = _sfxObj.AddComponent<AudioSource>();
            }
        }

        this.gameObject.name = typeof(SoundManager).Name;
    }
}

