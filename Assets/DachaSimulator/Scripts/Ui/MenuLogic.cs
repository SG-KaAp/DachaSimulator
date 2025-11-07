using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace DachaSimulator.Ui
{
    public class MenuLogic : MonoBehaviour
    {
        [SerializeField] private GameObject mainPanel;
        [SerializeField] private MenuAnimations menuAnimations;
        
        public void Awake()
        {
            menuAnimations.MenuMoveIn(mainPanel);
        }

        public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);
        
        public void ApplicationQuit(GameObject panel)
        {
            panel.transform.DOMoveX(-500, 1.5f).OnComplete(() =>
            {
                Application.Quit();
            });
        }
    }
}