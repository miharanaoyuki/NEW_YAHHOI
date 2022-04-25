using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject Basket; // かごオブジェクト
    public GameObject Player; // プレイヤーオブジェクト
    ShootingStarCount starCount; // ShootingStarCountスクリプト
    PlayerMovement playerMovement; // PlayerMovementスクリプト
    private int currentScene = 0; // 現在のシーン

    void Start()
    {
        // かごオブジェクト参照
        Basket = GameObject.Find("Basket");
        // ShootingStarCountスクリプト参照
        starCount = Basket.GetComponent<ShootingStarCount>();
        // プレイヤーオブジェクト参照
        Player = GameObject.Find("Player");
        // PlayerMovementスクリプト参照
        playerMovement = Player.GetComponent<PlayerMovement>();
        // 現在のシーンを取得
        currentScene = TeachCurrentScene();
    }

    void Update()
    {
        // 一定量かごが重くなる
        if (playerMovement.Speed <= 0)
        {
            // 現在のシーンによって変える
            switch(currentScene)
            {
                // シーン移行
                case 1:
                    SceneManager.LoadScene("gameover spring");
                    break;

                default:
                    break;
            }
        }

        // 落下モードで星を一つも取れない
        // シーン移行

        // 星座を一つも作れない
        // シーン移行
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
