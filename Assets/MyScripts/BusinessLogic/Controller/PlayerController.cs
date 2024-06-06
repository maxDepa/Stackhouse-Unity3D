using SH.Model;
using UnityEngine;

namespace SH.BusinessLogic {
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour, ISceneLoader
    {
        [Header("FBX")]
        [SerializeField] public GameObject fbx;
        [SerializeField] public RuntimeAnimatorController controller;

        [Header("Components")]
        [SerializeField] private Transform cam;
        [SerializeField] private new Rigidbody rigidbody;
        private Animator anim;

        private StateMachine<PlayerStateIndex> stateMachine;

        /*
         * Al posto di riferimento al GameManager, sarebbe meglio
         * Non esporre la property ma slegare le cose usando un evento
         */

        private Player _player => GameManager.Instance.Player;

        private void Start() {
            InitializeFBX();
            InitializeAnimator();
            InitializeStateMachine();
        }

        private void InitializeStateMachine() {
            stateMachine = new StateMachine<PlayerStateIndex>();
            stateMachine.AddState(PlayerStateIndex.Move, new PlayerState_Move(this,
                new PlayerRigidbodyMovementStrategy(rigidbody, cam, _player.MovementSpeed),
                new PlayerTransformRotationStrategy(transform, cam, _player.RotationSpeed),
                new PlayerMoveAnimatorAnimationStrategy(anim)
                )
            );
            stateMachine.AddState(PlayerStateIndex.Attack, new PlayerState_Attack(
                this,
                GetAnimationLength("Attack"),
                new AttackAnimationStrategy(anim)
                )
            );
            stateMachine.AddState(PlayerStateIndex.Roll, new PlayerState_Roll(
                this,
                GetAnimationLength("Roll"),
                new RollAnimationStrategy(anim),
                new ForwardMovementStrategy(rigidbody, _player.RollSpeed)
                )
            );
            stateMachine.ChangeState(PlayerStateIndex.Move);
        }

        private void InitializeFBX() {
            fbx.transform.parent = transform;
            fbx.transform.localPosition = Vector3.zero;
            fbx.transform.localRotation = Quaternion.identity;

            foreach(Transform t in fbx.GetComponentsInChildren<Transform>()) {
                if (t.name.Equals("Hand_R"))
                    t.gameObject.AddComponent<WeaponSocket>();
            }
        }

        private void InitializeAnimator() {
            if (fbx.TryGetComponent(out Animator animator)) {
                anim = animator;
            }
            else {
                anim = fbx.AddComponent<Animator>();
            }
            anim.runtimeAnimatorController = controller;
            anim.applyRootMotion = false;
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

        public void GoToAttack() {
            stateMachine.ChangeState(PlayerStateIndex.Attack);
        }

        public void GoToMove() {
            stateMachine.ChangeState(PlayerStateIndex.Move);
        }

        public void GoToRoll() {
            stateMachine.ChangeState(PlayerStateIndex.Roll);
        }

        public float GetAnimationLength(string clipName) {
            foreach(AnimationClip clip in anim.runtimeAnimatorController.animationClips) {
                if(clip.name.Equals(clipName))
                    return clip.length / anim.speed;
            }
            return 0f;
        }

    }
}
