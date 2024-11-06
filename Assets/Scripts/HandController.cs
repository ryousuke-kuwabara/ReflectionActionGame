using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField] private Transform center;
    [SerializeField] private float speed;
    [SerializeField] private FixedJoystick joyStick;
    [SerializeField] private int _reflectScore;

    // �ړ�����
    void Update()
    {
        float horizontalInput = Mathf.Clamp(Input.GetAxisRaw("Horizontal") + joyStick.Horizontal, -1f, 1f);
        transform.RotateAround(center.transform.position, transform.forward, speed * horizontalInput * Time.deltaTime);

        Vector3 lookDirection = center.position - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);
    }

    // �Ԃ����ڐG���̏��� TODO : �ڐG���ɐԂ�����speed���Q�Ƃ��ĉ��������� IReflectable�C���^�[�t�F�[�X�������p���Ĉˑ����t�]�����悤
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 ballPos = collision.transform.position;

        Vector2 playerPos = this.transform.position;
        Vector2 direction = (ballPos - playerPos).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
        collision.transform.rotation = targetRotation;

        ScoreManager.Instance.AddScore(_reflectScore);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
