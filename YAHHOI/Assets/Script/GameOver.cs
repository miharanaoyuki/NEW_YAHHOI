using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject Basket; // �����I�u�W�F�N�g
    public GameObject Player; // �v���C���[�I�u�W�F�N�g
    ShootingStarCount starCount; // ShootingStarCount�X�N���v�g
    PlayerMovement playerMovement; // PlayerMovement�X�N���v�g
    private int currentScene = 0; // ���݂̃V�[��

    void Start()
    {
        // �����I�u�W�F�N�g�Q��
        Basket = GameObject.Find("Basket");
        // ShootingStarCount�X�N���v�g�Q��
        starCount = Basket.GetComponent<ShootingStarCount>();
        // �v���C���[�I�u�W�F�N�g�Q��
        Player = GameObject.Find("Player");
        // PlayerMovement�X�N���v�g�Q��
        playerMovement = Player.GetComponent<PlayerMovement>();
        // ���݂̃V�[�����擾
        currentScene = TeachCurrentScene();
    }

    void Update()
    {
        // ���ʂ������d���Ȃ�
        if (playerMovement.Speed <= 0)
        {
            // ���݂̃V�[���ɂ���ĕς���
            switch(currentScene)
            {
                // �V�[���ڍs
                case 1:
                    SceneManager.LoadScene("gameover spring");
                    break;

                default:
                    break;
            }
        }

        // �������[�h�Ő���������Ȃ�
        // �V�[���ڍs

        // ������������Ȃ�
        // �V�[���ڍs
    }

    int TeachCurrentScene()
    {
        if (SceneManager.GetActiveScene().name == ("fallmode spring"))
        {
            return 1;
        }
        else
            return 0;
    }
}
