using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator animator;
    private float moveSpeed = 5f;

    enum EnemyState
    {
        Idle,
        Walk,
        Attack,
        Hit
    }

    private EnemyState currentState;
    private bool isFacingRight = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentState = EnemyState.Idle;
    }

    void Update()
    {
        // 根据当前状态执行相应的行为
        switch (currentState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Walk:
                Walk();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Hit:
                Hit();
                break;
        }

        // 设置Animator的参数，以控制动画
        SetAnimationParameters();
    }

    void Idle()
    {
        // 在这里执行Idle状态的逻辑，例如播放Idle动画
        // 可以是一个空方法，如果没有特定的逻辑
    }

    void Walk()
    {
        // 在这里执行Moving状态的逻辑，例如移动敌人
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void Attack()
    {
        // 在这里执行Attacking状态的逻辑，例如执行攻击行为
        // 可以是一个空方法，如果没有特定的逻辑
    }

    void Hit()
    {
        // 在这里执行Injured状态的逻辑，例如播放受伤动画
        // 可以是一个空方法，如果没有特定的逻辑
    }

    void SetAnimationParameters()
    {
        // 根据当前状态设置Animator的参数
        animator.SetFloat("Horizontal", 0f);
        animator.SetFloat("Vertical", 0f);
        animator.SetFloat("Speed", 0f);

        switch (currentState)
        {
            case EnemyState.Idle:
                // 设置Idle状态的动画参数
                break;
            case EnemyState.Walk:
                // 设置Moving状态的动画参数
                animator.SetFloat("Vertical", 1f); // 1表示向前移动
                animator.SetFloat("Speed", 1f); // 1表示最大速度
                break;
            case EnemyState.Attack:
                // 设置Attacking状态的动画参数
                break;
            case EnemyState.Hit:
                // 设置Injured状态的动画参数
                break;
        }
    }

    void Flip(float horizontalInput)
    {
        // 根据水平输入方向来翻转动画
        if ((horizontalInput > 0 && !isFacingRight) || (horizontalInput < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;

            // 翻转敌人的Scale
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

}