using SH.Model;
using UnityEngine;

namespace SH.BusinessLogic {

    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : EntityController, ISceneLoader
    {
        [Header("Player")]
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private Transform cam;
        

        /*
         * Al posto di riferimento al GameManager, sarebbe meglio
         * Non esporre la property ma slegare le cose usando un evento
         */
        private Player _player => GameManager.Instance.Player;


        protected override void Update() {
            base.Update();
            UpdateGravity();
        }

        protected override void InitializeStateMachine() {
            AddState(EntityStateIndex.Move, new EntityState_Move(this,
                new PlayerRigidbodyMovementStrategy(rigidbody, cam, _player.MovementSpeed),
                new PlayerMoveAnimatorAnimationStrategy(animator),
                new PlayerTransformRotationStrategy(transform, cam, _player.RotationSpeed),
                () => {
                    EventManager.Instance.AddListener(MyEventIndex.OnMouseLeftClick, OnMouseLeftClick);
                    EventManager.Instance.AddListener(MyEventIndex.OnLeftCtrl, OnLeftCtrl);
                },
                () => {
                    EventManager.Instance.RemoveListener(MyEventIndex.OnMouseLeftClick, OnMouseLeftClick);
                    EventManager.Instance.RemoveListener(MyEventIndex.OnLeftCtrl, OnLeftCtrl);
                })
            );


            AddState(EntityStateIndex.Attack, new EntityState_Attack(
                this,
                GetAnimationLength("Attack"),
                new AttackAnimationStrategy(animator)
                )
            );

            AddState(EntityStateIndex.Roll, new EntityState_Roll(
                this,
                GetAnimationLength("Roll"),
                new RollAnimationStrategy(animator),
                new ForwardMovementStrategy(rigidbody, _player.RollSpeed)
                )
            );

            stateMachine.ChangeState(EntityStateIndex.Move);
        }


        protected override void InitializeFBX() {
            base.InitializeFBX();
            SpawnWeaponSocket();
        }

        private void SpawnWeaponSocket() {
            foreach (Transform t in fbx.GetComponentsInChildren<Transform>()) {
                if (t.name.Equals("Hand_R"))
                    t.gameObject.AddComponent<WeaponSocket>();
            }
        }

        private void UpdateGravity() {
            rigidbody.AddForce(Vector3.down * _player.Gravity);
        }

        private void OnMouseLeftClick(MyEventArgs arg0)
        {
            GoToAttack();
        }

        private void OnLeftCtrl(MyEventArgs arg0)
        {
            GoToRoll();
        }

        private void OnDestroy()
        {
            EventManager.Instance.RemoveListener(MyEventIndex.OnMouseLeftClick, OnMouseLeftClick);
            EventManager.Instance.RemoveListener(MyEventIndex.OnLeftCtrl, OnLeftCtrl);
        }

    }
}
