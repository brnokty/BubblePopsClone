using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BubbleType
{
    _2,
    _4,
    _8,
    _16,
    _32,
    _64,
    _128,
    _256,
    _512,
    _1024,
    _2048
}

[Serializable]
public struct BubbleConfig
{
    public BubbleType _BubbleType;
    public Color _Color;
}

public class BubbleManager : MonoBehaviour
{
    #region Singleton

    public static BubbleManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    [Header("Bubbles")] [SerializeField] private List<BubbleConfig> _bubbleConfigs = new List<BubbleConfig>();

    [Header("Bubble Poses")] [SerializeField]
    private Transform bubblePos;

    [SerializeField] private Transform nextBubblePos;

    public Transform BubblePos => bubblePos;
    public Transform NextBubblePos => nextBubblePos;


    public Color GetColorForBubbleType(BubbleType bubbleType)
    {
        foreach (BubbleConfig config in _bubbleConfigs)
        {
            if (config._BubbleType == bubbleType)
            {
                return config._Color;
            }
        }


        return Color.white;
    }
}