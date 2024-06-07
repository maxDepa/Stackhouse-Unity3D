using UnityEngine;

namespace SH.View {
    public class LaptopMaterialSwitcher : MonoBehaviour
    {
        [SerializeField] private Texture[] working, foolingAround;
        [SerializeField] private MeshRenderer meshRenderer;

        private Texture RandomWorking => working[Random.Range(0, working.Length)];

        private Texture RandomFoolingAround => foolingAround[Random.Range(0, foolingAround.Length)];

        private void Update() {
            //DEBUG: TEST MATERIAL SWITCH
            //if(Input.GetKeyDown(KeyCode.P)) {
            //    SetWorkingMaterial();
            //}
            //else if (Input.GetKeyDown(KeyCode.O)) {
            //    SetFoolingAroundMaterial();
            //}
        }

        private void SetWorkingMaterial() {
            meshRenderer.materials[1].mainTexture = RandomWorking;
        }
        
        private void SetFoolingAroundMaterial() {
            meshRenderer.materials[1].mainTexture = RandomFoolingAround;
        }

    }
}
