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
        // 30�t���[�����ɃV�[���Ƀv���n�u�𐶐�
        if (Time.frameCount % 1 == 0 && i < 70)
        {
            // �v���n�u�̈ʒu�������_���Őݒ�
            float x = Random.Range(-3.0f, 3.0f);
            float y = 5.0f;
            Vector3 pos = new Vector3(x, y, 0.0f);

            // �v���n�u�𐶐�
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