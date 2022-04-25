using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim = null;
    //��Animator�̃C���X�^���X���擾
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    [SerializeField] Transform CenterOfBalance;  // �d�S
    public float Speed = 3.0f; // �ړ����x
    void Update()
    {
         //�E�ɐi��
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position =
                transform.position +
                (transform.right * Speed * Time.deltaTime);
            //����A�j���[�V����
            transform.localScale = new Vector3(-0.17f, 0.17f, 1);//����

            anim.SetBool("run", true);//�A�j���[�V����
        }
        //���ɐi��
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position =
                transform.position -
                (transform.right * Speed * Time.deltaTime);
            //����A�j���[�V����
            transform.localScale = new Vector3(0.17f, 0.17f, 1);//����
            anim.SetBool("run", true);//�A�j���[�V����
        }
        //�~�܂��Ă���
        else
        {
            anim.SetBool("run", false);//run�A�j���[�V�������I���
        }

        //����������
        RaycastHit2D hit = Physics2D.Raycast(
                    CenterOfBalance.position,
                    -transform.up, 
                    float.PositiveInfinity);

        // Transform�̐^���̒n�`�̖@���𒲂ׂ�
        if (hit.collider != null) 
        {
            string name = hit.collider.gameObject.name; // �Փ˂�������I�u�W�F�N�g�̖��O���擾

            if (name == "Earth (1)")
            {
                // �X���̍������߂�
                Quaternion q = Quaternion.FromToRotation(
                            transform.up,
                            hit.normal);

                // ��������]������
                transform.rotation *= q;

                //�n�ʂ����苗������Ă����痎��
                if (hit.distance > 0.05f)
                {
                    transform.position =
                        transform.position +
                        (-transform.up * Physics2D.gravity.magnitude * Time.deltaTime);
                }
            }
        }
    }
}