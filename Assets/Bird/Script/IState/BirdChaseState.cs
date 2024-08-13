using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdChaseState : IState
{
    public Transform target;  // 目标点
    public float startHeight = 10f;  // 初始Y轴高度
    public float endHeight = 0f;  // 最终Y轴高度
    public float startRadius = 10f;  // 初始半径
    public float endRadius = 2f;  // 最终半径
    public float rotationSpeed = 60f;  // 旋转速度
    public float moveDuration = 20f;  // 移动时间
    public float oscillationAmplitude = 1f;  // 上下起伏的振幅
    public float oscillationFrequency = 2f;  // 上下起伏的频率

    private float elapsedTime = 0f;

    private BirdActionComponent birdActionComponent;

    public void StateEnter(Object @object)
    {
        birdActionComponent = (BirdActionComponent)@object;
        target = birdActionComponent.target;
    }

    public void StateExit()
    {
        
    }

    public void StateUpdate()
    {
        if (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;

            // 计算时间进度
            float t = elapsedTime / moveDuration;

            // 线性插值计算当前高度和半径
            float baseHeight = Mathf.Lerp(startHeight, endHeight, t);
            float currentRadius = Mathf.Lerp(startRadius, endRadius, t);

            // 添加正弦波来实现上下起伏
            float oscillation = Mathf.Sin(elapsedTime * oscillationFrequency) * oscillationAmplitude;
            float currentHeight = baseHeight + oscillation;

            // 计算鸟的旋转角度
            float angle = rotationSpeed * elapsedTime;
            float radian = angle * Mathf.Deg2Rad;

            // 计算鸟的当前位置
            Vector3 offset = new Vector3(Mathf.Cos(radian) * currentRadius, currentHeight, Mathf.Sin(radian) * currentRadius);
            birdActionComponent.transform.position = Vector3.Lerp(birdActionComponent.transform.position, target.position + offset, Time.deltaTime);

            // 保持鸟的朝向
            birdActionComponent.transform.LookAt(target);
        }
        else
        {
            birdActionComponent.ChangeState(new BirdDestructState());
        }
    }    
}
