using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignCountSpring : MonoBehaviour
{
    public Text SignNumText; // �e�L�X�g�Q��

    private int SignComCount = 0; // �������ł�����

    public static bool isFirst = true;// ��񂾂�

    void Start()
    {
        SignComCount = 0; // �������ł�����������
        DontDestroyOnLoad(gameObject); // DontDestroy
    }

    void Update()
    {
        if ((Shot.fitCount == 4f || Shot.fitCount == 9f || Shot.fitCount == 16f ||
            Shot.fitCount == 23f || Shot.fitCount == 31f || Shot.fitCount == 40f ||
            Shot.fitCount == 49f || Shot.fitCount == 69f) && isFirst)
        {
            // �����ł��������₷
            SignComCount++;
            // �t���O��false�ɂ���
            isFirst = false;
        }
        if (Shot.fitCount != 4f && Shot.fitCount != 9f && Shot.fitCount != 16f &&
            Shot.fitCount != 23f && Shot.fitCount != 31f && Shot.fitCount != 40f &&
            Shot.fitCount != 49f && Shot.fitCount != 69f && !isFirst)
        {
            isFirst = true;
        }
        // �e�L�X�g�ɕ\��
        SignNumText.text= "�����̐�:" + SignComCount.ToString();
    }
}