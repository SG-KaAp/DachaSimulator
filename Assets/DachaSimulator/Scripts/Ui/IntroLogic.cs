using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

namespace DachaSimulator.Ui
{
    public class IntroLogic : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI introText;
        [SerializeField] private Image introImage;
        [SerializeField] private Phrase[] introPhrases;
        [SerializeField] private string[] introPhraseTexts;
        [SerializeField] private Sprite[] introBackgrounds;
        private Sequence _currentAnimation;
        
        public void ChangePhrase(int phraseIndex, int phraseBackgroundIndex)
        {
            string currentPhrase = introPhraseTexts[phraseIndex];
            Sprite currentPhraseBackground = introBackgrounds[phraseBackgroundIndex];
            _currentAnimation = DOTween.Sequence();
            _currentAnimation
                .Join(introImage.DOFade(0f, 0.5f))
                .AppendCallback(() =>
                {
                    introText.text = currentPhrase;
                    introImage.sprite = currentPhraseBackground;
                })
                .Join(introImage.DOFade(1f, 0.5f));
        }
        
        /*private void Start()
        {
            foreach (Phrase phrase in introPhrases)
            {
                ChangePhrase(phrase.phraseIndex, phrase.phraseBackgroundIndex);
            }
        }*/
    }

    [Serializable]
    public struct Phrase
    {
        public int phraseIndex;
        public int phraseBackgroundIndex;
    }
}