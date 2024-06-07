using SH.Model;
using UnityEngine;

namespace SH.BusinessLogic {
    [RequireComponent(typeof(CapsuleCollider))]
    public abstract class EntityController : MonoBehaviour
    {
        [Header("Entity")]
        [SerializeField] public GameObject fbx;
        [SerializeField] public RuntimeAnimatorController controller;

        protected Animator animator;

        protected StateMachine<EntityStateIndex> stateMachine = new StateMachine<EntityStateIndex>();

        public EntityStateIndex currentState;

        protected virtual void Start() {
            InitializeFBX();
            InitializeAnimator();
            InitializeStateMachine();
        }

        protected virtual void Update() {
            float delta = Time.deltaTime;
            stateMachine.Execute(delta);
        }

        private void LateUpdate() {
            stateMachine.LateExecute();
        }

        protected virtual void InitializeFBX() {
            fbx.transform.parent = transform;
            fbx.transform.localPosition = Vector3.zero;
            fbx.transform.localRotation = Quaternion.identity;
        }


        private void InitializeAnimator() {
            if (fbx.TryGetComponent(out Animator animator)) {
                this.animator = animator;
            }
            else {
                this.animator = fbx.AddComponent<Animator>();
            }
            this.animator.runtimeAnimatorController = controller;
            this.animator.applyRootMotion = false;
        }

        protected abstract void InitializeStateMachine();

  
        public void AddState(EntityStateIndex state, EntityState playerState)
        {
              stateMachine.AddState(state, playerState);
        }

        public void GoToAttack()
        {
            currentState = EntityStateIndex.Attack;
            stateMachine.ChangeState(EntityStateIndex.Attack);
        }

        public void GoToMove() {
            currentState = EntityStateIndex.Move;
            stateMachine.ChangeState(EntityStateIndex.Move);
        }

        public void GoToRoll() {
            currentState = EntityStateIndex.Roll;
            stateMachine.ChangeState(EntityStateIndex.Roll);
        }

        public float GetAnimationLength(string clipName) {
            foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips) {
                if (clip.name.Equals(clipName))
                    return clip.length / animator.speed;
            }
            return 0f;
        }

    }
}