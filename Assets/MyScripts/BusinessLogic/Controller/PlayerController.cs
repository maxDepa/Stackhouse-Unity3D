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
            stateMachine.AddState(PlayerStateIndex.Move, new PlayerState_Move(this,
                new PlayerRigidbodyMovementStrategy(rigidbody, cam, _player.MovementSpeed),
                new PlayerTransformRotationStrategy(transform, cam, _player.RotationSpeed),
                new PlayerMoveAnimatorAnimationStrategy(animator)
                )
            );

            stateMachine.AddState(PlayerStateIndex.Attack, new PlayerState_Attack(
                this,
                GetAnimationLength("Attack"),
                new AttackAnimationStrategy(animator)
                )
            );

            stateMachine.AddState(PlayerStateIndex.Roll, new PlayerState_Roll(
                this,
                GetAnimationLength("Roll"),
                new RollAnimationStrategy(animator),
                new ForwardMovementStrategy(rigidbody, _player.RollSpeed)
                )
            );

            stateMachine.ChangeState(PlayerStateIndex.Move);
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

    }
}
