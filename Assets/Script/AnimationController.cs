using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public Animator animator;  // Animator ������Ʈ�� �Ҵ��մϴ�.
    private int animationState = 0;  // ���� �ִϸ��̼� ���¸� �����ϴ� ����

    void Update()
    {
        // ���콺 ��Ŭ���� ����
        if (Input.GetMouseButtonDown(0))
        {
            // �ִϸ��̼� ���¸� ��ȯ�ϸ鼭 ��ȯ
            switch (animationState)
            {
                case 0:
                    animator.Play("jump");  // "Jump" �ִϸ��̼� ����
                    animationState = 1;  // ���� ���·� ����
                    break;
                case 1:
                    animator.Play("attacked");  // "Attacked" �ִϸ��̼� ����
                    animationState = 2;  // ���� ���·� ����
                    break;
                case 2:
                    animator.Play("idle");  // "Idle" �ִϸ��̼� ����
                    animationState = 0;  // �ٽ� ù ��° ���·� ����
                    break;
            }
        }
    }
}
