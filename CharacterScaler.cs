using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScaler: MonoBehaviour
{
    [Header("缩放设置")]
    public Transform Player;  // 要缩放的人物对象
    public float scaleStep = 0.1f;     // 每次缩放幅度
    public float minScale = 0.5f;     // 最小缩放值
    public float maxScale = 3.0f;      // 最大缩放值

    // 放大方法（绑定到+按钮）
    public void ZoomIn()
    {
        float newScale = Mathf.Clamp(
            Player.localScale.x + scaleStep,
            minScale,
            maxScale
        );
        Player.localScale = Vector3.one * newScale;
    }

    // 缩小方法（绑定到-按钮）
    public void ZoomOut()
    {
        float newScale = Mathf.Clamp(
            Player.localScale.x - scaleStep,
            minScale,
            maxScale
        );
        Player.localScale = Vector3.one * newScale;
    }
}
