using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SH.BusinessLogic
{
    public class ProductivityManager: MonoBehaviour
    {
        private List<EnemyController> workingEnemies = new();
        private List<EnemyController> notWorkingEnemies = new();

        private void Start()
        {
            EventManager.Instance.AddListener(MyEventIndex.OnNpcWorking, OnNpcWorking);
            EventManager.Instance.AddListener(MyEventIndex.OnNpcNotWorking, OnNpcNotWorking);
            EventManager.Instance.AddListener(MyEventIndex.OnProductivityCheck, OnProductivityCheck);
        }

        private void OnNpcWorking(MyEventArgs args)
        {
            int enemyId = args.additionalEnemyController.controller.GetInstanceID();
            notWorkingEnemies.RemoveAll(x => x.GetInstanceID() == enemyId); // TODO: Consider using Remove
            workingEnemies.Add(args.additionalEnemyController);
        }

        private void OnNpcNotWorking(MyEventArgs args)
        {
            int enemyId = args.additionalEnemyController.controller.GetInstanceID();
            workingEnemies.RemoveAll(x => x.GetInstanceID() == enemyId); // TODO: Consider using Remove
            notWorkingEnemies.Add(args.additionalEnemyController);
        }

        private void OnDestroy()
        {
            EventManager.Instance.RemoveListener(MyEventIndex.OnNpcWorking, OnNpcWorking);
            EventManager.Instance.RemoveListener(MyEventIndex.OnNpcNotWorking, OnNpcNotWorking);
            EventManager.Instance.RemoveListener(MyEventIndex.OnProductivityCheck, OnProductivityCheck);
        }

        private void OnProductivityCheck(MyEventArgs args)
        {
            int productivity = ComputeProductivityDelta();
            GameManager.Instance.UpdateProductivity(productivity);
        }

        private int ComputeProductivityDelta()
        {
            int positiveValues = (int)workingEnemies.Select(x => x.productivity).ToList().Sum(x => x);
            int negativeValues = (int)notWorkingEnemies.Select(x => x.productivity).ToList().Sum(x => -x);
            int result = positiveValues + negativeValues;
            return result;
        }
    }
}
