using SH.Dto;
using SH.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace SH.BusinessLogic {
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [Header("FBX")]
        [SerializeField] public GameObject fbx;
        [SerializeField] public AnimatorController controller;

        [Header("Components")]
        [SerializeField] private Transform cam;
        [SerializeField] private new Rigidbody rigidbody;
        private Animator anim;

        [Header("Data")]
        [SerializeField] private PlayerData data;

        private Player _player;

        private StateMachine<PlayerStateIndex> stateMachine;

        private void Start() {
            InitializePlayer();
            InitializeFBX();
            InitializeAnimator();
            InitializeStateMachine();
        }

        private void InitializePlayer() {
            _player = new Player(data);
        }

        private void InitializeStateMachine() {
            stateMachine = new StateMachine<PlayerStateIndex>();
            stateMachine.AddState(PlayerStateIndex.Move, new PlayerState_Move(this,
                new PlayerRigidbodyMovementStrategy(rigidbody, cam, _player.MovementSpeed),
                new PlayerTransformRotationStrategy(transform, cam, _player.RotationSpeed),
                new PlayerMoveAnimatorAnimationStrategy(anim)
                )
            );
            stateMachine.ChangeState(PlayerStateIndex.Move);
        }

        private void InitializeFBX() {
            fbx.transform.parent = transform;
            fbx.transform.localPosition = Vector3.zero;
            fbx.transform.localRotation = Quaternion.identity;

            if (fbx.TryGetComponent(out Animator animator)) {
                anim = animator;
                anim.runtimeAnimatorController = controller;
            }
            else {
                anim = fbx.AddComponent<Animator>();
                anim.runtimeAnimatorController = controller;
            }
        }

        private void InitializeAnimator() {
            anim = fbx.GetComponent<Animator>();
        }

        private void Update() {
            float delta = Time.deltaTime;
            stateMachine.Execute(delta);
            UpdateGravity(delta);
        }

        private void LateUpdate() {
            stateMachine.LateExecute();
        }

        private void UpdateGravity(float delta) {
            rigidbody.AddForce(Vector3.down * _player.Gravity);
        }
    }
}
