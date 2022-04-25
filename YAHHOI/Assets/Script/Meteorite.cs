using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    public GameObject MeteoritePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // 30フレーム毎にシーンにプレハブを生成
        if (Time.frameCount % 60 == 0)
        {
            // プレハブの位置をランダムで設定
            float x = Random.Range(-5.0f, 5.0f);
            float y = 5.0f;
            Vector3 pos = new Vector3(x, y, 0.0f);

            // プレハブを生成
            GameObject ball = Instantiate(MeteoritePrefab, pos, Quaternion.identity);

            Destroy(ball, 1.0f);
        }
    }
}
