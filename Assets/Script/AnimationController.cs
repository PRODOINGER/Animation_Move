using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public Animator animator;  // Animator 컴포넌트를 할당합니다.
    private int animationState = 0;  // 현재 애니메이션 상태를 저장하는 변수

    void Update()
    {
        // 마우스 좌클릭을 감지
        if (Input.GetMouseButtonDown(0))
        {
            // 애니메이션 상태를 순환하면서 전환
            switch (animationState)
            {
                case 0:
                    animator.Play("jump");  // "Jump" 애니메이션 실행
                    animationState = 1;  // 다음 상태로 설정
                    break;
                case 1:
                    animator.Play("attacked");  // "Attacked" 애니메이션 실행
                    animationState = 2;  // 다음 상태로 설정
                    break;
                case 2:
                    animator.Play("idle");  // "Idle" 애니메이션 실행
                    animationState = 0;  // 다시 첫 번째 상태로 설정
                    break;
            }
        }
    }
}
