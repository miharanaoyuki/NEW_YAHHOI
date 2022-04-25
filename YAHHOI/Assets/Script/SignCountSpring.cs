using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignCountSpring : MonoBehaviour
{
    public Text SignNumText; // テキスト参照

    private int SignComCount = 0; // 星座ができた数

    public static bool isFirst = true;// 一回だけ

    void Start()
    {
        SignComCount = 0; // 星座ができた数初期化
        DontDestroyOnLoad(gameObject); // DontDestroy
    }

    void Update()
    {
        if ((Shot.fitCount == 4f || Shot.fitCount == 9f || Shot.fitCount == 16f ||
            Shot.fitCount == 23f || Shot.fitCount == 31f || Shot.fitCount == 40f ||
            Shot.fitCount == 49f || Shot.fitCount == 69f) && isFirst)
        {
            // 星座できた数増やす
            SignComCount++;
            // フラグをfalseにする
            isFirst = false;
        }
        if (Shot.fitCount != 4f && Shot.fitCount != 9f && Shot.fitCount != 16f &&
            Shot.fitCount != 23f && Shot.fitCount != 31f && Shot.fitCount != 40f &&
            Shot.fitCount != 49f && Shot.fitCount != 69f && !isFirst)
        {
            isFirst = true;
        }
        // テキストに表示
        SignNumText.text= "星座の数:" + SignComCount.ToString();
    }
}