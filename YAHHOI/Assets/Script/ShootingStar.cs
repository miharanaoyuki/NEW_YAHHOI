using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootingStar : MonoBehaviour
{
    public GameObject ShootingStarPrefab;
    public int i = 0;
    // Update is called once per frame
    void Update()
    {
        // 30フレーム毎にシーンにプレハブを生成
        if (Time.frameCount % 1 == 0 && i < 70)
        {
            // プレハブの位置をランダムで設定
            float x = Random.Range(-3.0f, 3.0f);
            float y = 5.0f;
            Vector3 pos = new Vector3(x, y, 0.0f);

            // プレハブを生成
            GameObject ball = Instantiate(ShootingStarPrefab, pos, Quaternion.identity);

            Destroy(ball, 10.0f);

            i++;
        }
        if (i == 70)
        {
            StartCoroutine("PachiSceneChange");
        }
    }

    IEnumerator PachiSceneChange()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("NakanoTest");
    }
}