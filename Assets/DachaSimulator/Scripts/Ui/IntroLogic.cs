using System;
using System.Collections;
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
        
        /*public void ChangePhrase(int phraseIndex, int phraseBackgroundIndex)
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
        }*/

        private void Start() => StartCoroutine(ShowIntro());

        private IEnumerator ShowIntro()
        {
            foreach (Phrase phrase in introPhrases)
            {
                introImage.sprite = introBackgrounds[phrase.phraseBackgroundIndex];
                yield return StartCoroutine(TypeText(introPhraseTexts[phrase.phraseIndex]));
                yield return new WaitForSeconds(0.5f);
            }
        }
        
        private IEnumerator TypeText(string text)
        {
            introText.text = String.Empty;
            foreach (char c in text.ToCharArray())
            {
                introText.text += c;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }

    [Serializable]
    public struct Phrase
    {
        public int phraseIndex;
        public int phraseBackgroundIndex;
    }
}