using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPannel : MonoBehaviour {

    private Animator _animator;

    [SerializeField]
    private Text countDown;
    [SerializeField]
    private GameObject fadeInPannel;

    [SerializeField]
    private StockData _stockData;

    private bool _isCountDowm = false;

    IEnumerator FadeIn()
    {
        fadeInPannel.SetActive(true);

        yield return new WaitForSecondsRealtime(1.0f);

        fadeInPannel.SetActive(false);
    }

    IEnumerator CountDown()
    {
        _isCountDowm = true;
        _animator.SetTrigger("_FadeOut");

        yield return new WaitForSecondsRealtime(1.0f);

        countDown.gameObject.SetActive(true);
        countDown.text = "3";
        //SoundManager.Instance.PlaySe();

        yield return new WaitForSecondsRealtime(1.0f);

        countDown.text = "2";
        //SoundManager.Instance.PlaySe();

        yield return new WaitForSecondsRealtime(1.0f);

        countDown.text = "1";
        //SoundManager.Instance.PlaySe();

        yield return new WaitForSecondsRealtime(1.0f);

        countDown.text = "START !";

        yield return new WaitForSecondsRealtime(1.0f);

        Time.timeScale = 1.0f;
        GameManager.isPlaying = true;
        TimeManager.isCountUp = true;
        Destroy(this.gameObject);
        
    }

	// Use this for initialization
	void Start () {
        _animator = this.GetComponent<Animator>();
        _isCountDowm = false;

        StartCoroutine(FadeIn());
        Time.timeScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.Space) || _stockData.Button == 1) && !_isCountDowm)
        {
            SoundManager.Instance.PlaySe("fire");
            StartCoroutine(CountDown());
        }	
	}
}
