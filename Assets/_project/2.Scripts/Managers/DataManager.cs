using System;
using System.Collections.Generic;
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

        SoundDataInit();
    }

    [Header("Player")]
    public float playerMoveSpeed = 5f;
    public float stepSFXInterval = 0.3f;
    public SfxType[] stepSfxTypes;

    [Header("Monster")]
    public float monsterMoveSpeed = 3f;
    public Monster monsterPrefab;

    [Tooltip("추후 Addressable로 변경할 예정")]
    [Header("UI")]
    public GameEndUI gameEndUI;


    // 사운드가 많아 진다면 추후 딕셔너리로 전환 예정
    [Header("Sound")]
    public int maxSfxCount = 7;
    [SerializeField] private BgmData[] _bgmDats;
    [SerializeField] private SfxData[] _sfxDatas;
    private Dictionary<BgmType, BgmData> _bgmDataDic;
    private Dictionary<SfxType, SfxData> _sfxDataDic;

    public void SoundDataInit()
    {
        this._bgmDataDic = new Dictionary<BgmType, BgmData>();
        foreach (BgmData _bgmData in this._bgmDats)
            this._bgmDataDic.Add(_bgmData.bgmType, _bgmData);

        this._sfxDataDic = new Dictionary<SfxType, SfxData>();
        foreach (SfxData _sfxData in this._sfxDatas)
            this._sfxDataDic.Add(_sfxData.sfxType, _sfxData);
    }

    public BgmData GetBGMData(BgmType _type)
    {
        return _bgmDataDic[_type];
    }

    public SfxData GetSfxData(SfxType _type)
    {
        return _sfxDataDic[_type];
    }

    [Serializable]
    public class SoundData
    {
        public AudioClip clip;
        public float volume;
    }

    [Serializable]
    public class BgmData : SoundData
    {
        public BgmType bgmType;
    }

    [Serializable]
    public class SfxData : SoundData
    {
        public SfxType sfxType;
    }
}

