using DG.Tweening;
using UnityEngine;

namespace DachaSimulator.Ui
{
    public class MenuAnimations : MonoBehaviour
    {
        public void MenuMoveIn(GameObject panel)
        {
            //panel.SetActive(true);
            panel.transform.DOMoveX(0, 1.5f).SetUpdate(true);
        }

        public void MenuMoveOut(GameObject panel)
        {
            panel.transform.DOMoveX(-500, 1.5f) .OnComplete(() =>
            {
                //panel.SetActive(false);
            }).SetUpdate(true);
        }
    }
}