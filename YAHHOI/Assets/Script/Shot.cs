using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{
    // 速度
    public float Speed;
    // 移動ベクトル
    Vector3 vec;
    // 進行方向のベクトル
    Vector3 direction;
    // 移動するかどうかのフラグ
    bool Move = false;
    // スティックを倒しているかのフラグ
    bool stick = false;
    // 一度だけ動作するフラグ
    bool isFirst = true;
    // 矢印の参照
    GameObject Arrow;
    // PowerMeterオブジェクトへの参照
    [SerializeField]
    GameObject powerMeterObject;
    // Sliderコンポーネントへの参照
    Slider powerMeterSlider;
    // メーターの速さ
    [SerializeField]
    float meterSpeed = 0.1f;
    // メーターが最大値になった時のディレイ
    [SerializeField]
    float delayTime = 0.08f;
    float waitTime = 0f;
    // メーターが増加中か減少中か(trueで増加中)
    bool isMeterIncreasing = true;
    private GameObject target; // ターゲット
    public bool Fit = false; // はまったフラグ
    public bool destroy = false; // 破壊フラグ
    public GameObject Player; // プレイヤーオブジェクト
    Generate generate; // Generateスクリプト
    public Rigidbody2D rb; // Rigidbody2D
    private GameObject nearObj; // 最も近いオブジェクト
    public static bool fly = false;
    public static int fitCount = 0; // はまった数

    void Start()
    {
        Player = GameObject.Find("Player");
        // 矢印を参照
        Arrow = Player.transform.GetChild(0).gameObject;
        // 矢印消す
        Arrow.SetActive(false);
        // Power参照
        powerMeterObject = GameObject.Find("Power");
        // powerMeterSliderへの参照
        powerMeterSlider = powerMeterObject.GetComponent<Slider>();
        // ゲージを0に初期化
        powerMeterSlider.value = powerMeterSlider.minValue;
        // 弾生み出すやつ参照
        generate = Player.GetComponent<Generate>();
        // Rigitbody2D参照
        rb = GetComponent<Rigidbody2D>();
        // TimeControllerの値初期化
        TimerController.totalTime = 0f;
        TimerController.time = 0f;
        // fly初期化
        fly = false;
    }

    void Update()
    {
        // スティック入力角度取得(横)
        var h = Input.GetAxis("R_Horizontal");
        // スティック入力角度取得(縦)
        var v = Input.GetAxis("R_Vertical");

        if (!fly)
        {
            // 発射されるまでプレイヤーについていく
            transform.position = Player.transform.position;
        }

        // 一度目かどうか
        if (isFirst)
        {
            // スティックが下方向に倒されているか
            if (v > 0.9f)
            {
                // 矢印表示
                Arrow.SetActive(true);
                // powerMeterを動かす
                MovePowerMeter();
                // 回転させる
                Rotate(v, h);
                // スティックフラグをtrueにする
                stick = true;
            }
        }
        // スティックが戻されているかつ、stick==true
        if (v <= 0.9f && stick)
        {
            // 矢印消す
            Arrow.SetActive(false);
            // フラグをfalseにする
            isFirst = false;
            stick = false;
            // フラグをtrueにして動かす
            Move = true;
        }

        // Moveがtrueか
        if (Move)
        {
            // 移動する
            rb.AddForce(transform.right * Speed);
            Move = false;
            fly = true;
        }

        if (TimerController.totalTime >= 5.0f)
        {
            // 近くの穴を取得
            nearObj = serchTag(gameObject, "doikun");

            // 穴の位置に移動する
            transform.position = nearObj.transform.position;

            // はまった
            Fit = true;

            // 数増やす
            fitCount++;

            // 穴消す
            Destroy(nearObj);

            // 星を生成する
            generate.Clone();

            // スクリプトをオフにする
            GetComponent<Shot>().enabled = false;
        }

        // timeが7fを超えたら
        if (TimerController.time > 7f)
        {
            // 削除
            Destroy(this.gameObject);
        }

        // 星が動いていたら
        if (rb.velocity.x > 0 || rb.velocity.y > 0)
        {
            // 抵抗を付与
            rb.drag = 1.0f;
        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("doikun"))
        {
            TimerController.doikun = true;
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("doikun"))
        {
            TimerController.doikun = false;

            TimerController.totalTime = 0f;
        }
    }

    void Rotate(float v, float h)
    {
        // スティックの角度(度数法)
        float radian = Mathf.Atan2(-v, h) * Mathf.Rad2Deg;
        if (v == 1)
        {
            // z軸に星が飛んでいく角度だけ回転
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, radian + 180);
        }
        else
        {
            return;
        }
    }

    void MovePowerMeter()
    {
        // 星を飛ばしたらメーターを止める
        if(Move)
        {
            // Moveがtrueなら何もせずに返す
            return;
        }

        // 境界値(メーターを止めるときの値)の定義
        float boundaryValue;

        // メーターを上下させる
        if (isMeterIncreasing)
        {
            // メーターを増やす
            powerMeterSlider.value += meterSpeed;
            // メーターの最大値を代入
            boundaryValue = powerMeterSlider.maxValue;
        }
        else
        {
            // メーターを減らす
            powerMeterSlider.value -= meterSpeed;
            // メーターの最小値を代入
            boundaryValue = powerMeterSlider.minValue;
        }

        // 境界値になったら少し止めた後メーターを逆向きに動かす
        if (Mathf.Approximately(powerMeterSlider.value, boundaryValue))
        {
            // 少し止める
            WaitBoundaryValue();
        }

        // スライダーの現在値をSpeedに格納
        Speed = powerMeterSlider.value;
        
    }

    void WaitBoundaryValue()
    {
        // 前のフレームが呼ばれて、処理が完了するまでにかかった時間を加算
        waitTime += Time.deltaTime;

        // waitTimeがdelayTimeを超えたら増加フラグの反転
        if (waitTime >= delayTime)
        {
            // フラグの反転
            isMeterIncreasing = !isMeterIncreasing;
            // waitTimeを0に戻す
            waitTime = 0f;
        }
    }

    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0; // 距離用一時変数
        float nearDis = 0; // 最も近いオブジェクトの距離

        GameObject targetObj = null; // オブジェクト

        // タグ指定されたオブジェクトを配列で取得する
        // foreach(型名 オブジェクト名 in コレクション(配列名))
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            // 自信と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            // オブジェクトの距離が近いか、距離が0ならオブジェクト名を取得
            // nearDisにtmpDisを格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;

                targetObj = obs;
            }
        }

        // 最も近いオブジェクトを返す
        return targetObj;
    }

    void OnBecameInvisible()
    {
        // 星を生成する
        generate.Clone();
        // カメラ外に出たら削除
        Destroy(this.gameObject);
    }
}
