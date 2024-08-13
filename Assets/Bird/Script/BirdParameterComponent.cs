using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdParameterComponent : MonoBehaviour
{
    public float startHeight = 10f;  // 初始Y轴高度
    public float endHeight = 0f;  // 最终Y轴高度
    public float startRadius = 10f;  // 初始半径
    public float endRadius = 2f;  // 最终半径
    public float rotationSpeed = 60f;  // 旋转速度
    public float moveDuration = 20f;  // 移动时间
    public float oscillationAmplitude = 1f;  // 上下起伏的振幅
    public float oscillationFrequency = 2f;  // 上下起伏的频率

    public float detectRange;  // 检测范围

    public float elapsedTime = 0f;
}
