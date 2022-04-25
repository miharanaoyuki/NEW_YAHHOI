using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRangeRandomPosition : MonoBehaviour
{
    [SerializeField]
    [Tooltip("生成するGameObject")]
    private GameObject createPrefab;
    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;

    public float falltime;
    // 経過時間
    private float time;

    // Update is called once per frame
    void Update()
    {
        // 前フレームからの時間を加算していく
        time = time + Time.deltaTime;

        // 約3秒置きにランダムに生成されるようにする。
        if (time > falltime)
        {
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            float y = Random.Range(rangeA.position.y, rangeB.position.y);

            //// rangeAとrangeBのz座標の範囲内でランダムな数値を作成
            //float z = Random.Range(rangeA.position.z, rangeB.position.z);

            // GameObjectを上記で決まったランダムな場所に生成
            GameObject ball =Instantiate(createPrefab, new Vector3(x, y, 0), createPrefab.transform.rotation);

            //// 経過時間リセット
            time = 1f;

            ////8秒後に削除する
            Destroy(ball, 8.0f);
        }
    }
}