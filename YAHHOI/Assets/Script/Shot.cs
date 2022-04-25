using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{
    // ���x
    public float Speed;
    // �ړ��x�N�g��
    Vector3 vec;
    // �i�s�����̃x�N�g��
    Vector3 direction;
    // �ړ����邩�ǂ����̃t���O
    bool Move = false;
    // �X�e�B�b�N��|���Ă��邩�̃t���O
    bool stick = false;
    // ��x�������삷��t���O
    bool isFirst = true;
    // ���̎Q��
    GameObject Arrow;
    // PowerMeter�I�u�W�F�N�g�ւ̎Q��
    [SerializeField]
    GameObject powerMeterObject;
    // Slider�R���|�[�l���g�ւ̎Q��
    Slider powerMeterSlider;
    // ���[�^�[�̑���
    [SerializeField]
    float meterSpeed = 0.1f;
    // ���[�^�[���ő�l�ɂȂ������̃f�B���C
    [SerializeField]
    float delayTime = 0.08f;
    float waitTime = 0f;
    // ���[�^�[������������������(true�ő�����)
    bool isMeterIncreasing = true;
    private GameObject target; // �^�[�Q�b�g
    public bool Fit = false; // �͂܂����t���O
    public bool destroy = false; // �j��t���O
    public GameObject Player; // �v���C���[�I�u�W�F�N�g
    Generate generate; // Generate�X�N���v�g
    public Rigidbody2D rb; // Rigidbody2D
    private GameObject nearObj; // �ł��߂��I�u�W�F�N�g
    public static bool fly = false;
    public static int fitCount = 0; // �͂܂�����

    void Start()
    {
        Player = GameObject.Find("Player");
        // �����Q��
        Arrow = Player.transform.GetChild(0).gameObject;
        // ������
        Arrow.SetActive(false);
        // Power�Q��
        powerMeterObject = GameObject.Find("Power");
        // powerMeterSlider�ւ̎Q��
        powerMeterSlider = powerMeterObject.GetComponent<Slider>();
        // �Q�[�W��0�ɏ�����
        powerMeterSlider.value = powerMeterSlider.minValue;
        // �e���ݏo����Q��
        generate = Player.GetComponent<Generate>();
        // Rigitbody2D�Q��
        rb = GetComponent<Rigidbody2D>();
        // TimeController�̒l������
        TimerController.totalTime = 0f;
        TimerController.time = 0f;
        // fly������
        fly = false;
    }

    void Update()
    {
        // �X�e�B�b�N���͊p�x�擾(��)
        var h = Input.GetAxis("R_Horizontal");
        // �X�e�B�b�N���͊p�x�擾(�c)
        var v = Input.GetAxis("R_Vertical");

        if (!fly)
        {
            // ���˂����܂Ńv���C���[�ɂ��Ă���
            transform.position = Player.transform.position;
        }

        // ��x�ڂ��ǂ���
        if (isFirst)
        {
            // �X�e�B�b�N���������ɓ|����Ă��邩
            if (v > 0.9f)
            {
                // ���\��
                Arrow.SetActive(true);
                // powerMeter�𓮂���
                MovePowerMeter();
                // ��]������
                Rotate(v, h);
                // �X�e�B�b�N�t���O��true�ɂ���
                stick = true;
            }
        }
        // �X�e�B�b�N���߂���Ă��邩�Astick==true
        if (v <= 0.9f && stick)
        {
            // ������
            Arrow.SetActive(false);
            // �t���O��false�ɂ���
            isFirst = false;
            stick = false;
            // �t���O��true�ɂ��ē�����
            Move = true;
        }

        // Move��true��
        if (Move)
        {
            // �ړ�����
            rb.AddForce(transform.right * Speed);
            Move = false;
            fly = true;
        }

        if (TimerController.totalTime >= 5.0f)
        {
            // �߂��̌����擾
            nearObj = serchTag(gameObject, "doikun");

            // ���̈ʒu�Ɉړ�����
            transform.position = nearObj.transform.position;

            // �͂܂���
            Fit = true;

            // �����₷
            fitCount++;

            // ������
            Destroy(nearObj);

            // ���𐶐�����
            generate.Clone();

            // �X�N���v�g���I�t�ɂ���
            GetComponent<Shot>().enabled = false;
        }

        // time��7f�𒴂�����
        if (TimerController.time > 7f)
        {
            // �폜
            Destroy(this.gameObject);
        }

        // ���������Ă�����
        if (rb.velocity.x > 0 || rb.velocity.y > 0)
        {
            // ��R��t�^
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
        // �X�e�B�b�N�̊p�x(�x���@)
        float radian = Mathf.Atan2(-v, h) * Mathf.Rad2Deg;
        if (v == 1)
        {
            // z���ɐ������ł����p�x������]
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, radian + 180);
        }
        else
        {
            return;
        }
    }

    void MovePowerMeter()
    {
        // �����΂����烁�[�^�[���~�߂�
        if(Move)
        {
            // Move��true�Ȃ牽�������ɕԂ�
            return;
        }

        // ���E�l(���[�^�[���~�߂�Ƃ��̒l)�̒�`
        float boundaryValue;

        // ���[�^�[���㉺������
        if (isMeterIncreasing)
        {
            // ���[�^�[�𑝂₷
            powerMeterSlider.value += meterSpeed;
            // ���[�^�[�̍ő�l����
            boundaryValue = powerMeterSlider.maxValue;
        }
        else
        {
            // ���[�^�[�����炷
            powerMeterSlider.value -= meterSpeed;
            // ���[�^�[�̍ŏ��l����
            boundaryValue = powerMeterSlider.minValue;
        }

        // ���E�l�ɂȂ����班���~�߂��チ�[�^�[���t�����ɓ�����
        if (Mathf.Approximately(powerMeterSlider.value, boundaryValue))
        {
            // �����~�߂�
            WaitBoundaryValue();
        }

        // �X���C�_�[�̌��ݒl��Speed�Ɋi�[
        Speed = powerMeterSlider.value;
        
    }

    void WaitBoundaryValue()
    {
        // �O�̃t���[�����Ă΂�āA��������������܂łɂ����������Ԃ����Z
        waitTime += Time.deltaTime;

        // waitTime��delayTime�𒴂����瑝���t���O�̔��]
        if (waitTime >= delayTime)
        {
            // �t���O�̔��]
            isMeterIncreasing = !isMeterIncreasing;
            // waitTime��0�ɖ߂�
            waitTime = 0f;
        }
    }

    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0; // �����p�ꎞ�ϐ�
        float nearDis = 0; // �ł��߂��I�u�W�F�N�g�̋���

        GameObject targetObj = null; // �I�u�W�F�N�g

        // �^�O�w�肳�ꂽ�I�u�W�F�N�g��z��Ŏ擾����
        // foreach(�^�� �I�u�W�F�N�g�� in �R���N�V����(�z��))
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            // ���M�Ǝ擾�����I�u�W�F�N�g�̋������擾
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            // �I�u�W�F�N�g�̋������߂����A������0�Ȃ�I�u�W�F�N�g�����擾
            // nearDis��tmpDis���i�[
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;

                targetObj = obs;
            }
        }

        // �ł��߂��I�u�W�F�N�g��Ԃ�
        return targetObj;
    }

    void OnBecameInvisible()
    {
        // ���𐶐�����
        generate.Clone();
        // �J�����O�ɏo����폜
        Destroy(this.gameObject);
    }
}
