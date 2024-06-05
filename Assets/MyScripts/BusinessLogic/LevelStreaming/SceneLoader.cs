using UnityEngine;
using UnityEngine.SceneManagement;

namespace SH.BusinessLogic {
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private string sceneToLoad;

        private void OnTriggerEnter(Collider other) {
            if (other.GetComponent<ISceneLoader>() != null) {
                LoadScene();
            }
        }

        private void OnTriggerExit(Collider other) { 
            if(other.GetComponent<ISceneLoader>() != null) {
                UnloadScene();
            }
        }

        private void OnDrawGizmos() {
            Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
            Gizmos.DrawCube(transform.position, transform.localScale);
        }

        private void LoadScene() {
            SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
        }

        private void UnloadScene() {
            SceneManager.UnloadSceneAsync(sceneToLoad);
        }
    }

}