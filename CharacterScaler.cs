using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScaler: MonoBehaviour
{
    [Header("��������")]
    public Transform Player;  // Ҫ���ŵ��������
    public float scaleStep = 0.1f;     // ÿ�����ŷ���
    public float minScale = 0.5f;     // ��С����ֵ
    public float maxScale = 3.0f;      // �������ֵ

    // �Ŵ󷽷����󶨵�+��ť��
    public void ZoomIn()
    {
        float newScale = Mathf.Clamp(
            Player.localScale.x + scaleStep,
            minScale,
            maxScale
        );
        Player.localScale = Vector3.one * newScale;
    }

    // ��С�������󶨵�-��ť��
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
