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

    IEnumerator FadeIn()
    {
        fadeInPannel.SetActive(true);

        yield return new WaitForSecondsRealtime(1.0f);

        fadeInPannel.SetActive(false);
    }

    IEnumerator CountDown()
    {
        _animator.SetTrigger("_FadeOut");

        yield return new WaitForSecondsRealtime(1.0f);

        countDown.gameObject.SetActive(true);
        countDown.text = "3";

        yield return new WaitForSecondsRealtime(1.0f);

        countDown.text = "2";

        yield return new WaitForSecondsRealtime(1.0f);

        countDown.text = "1";

        yield return new WaitForSecondsRealtime(1.0f);

        countDown.text = "START !";

        yield return new WaitForSecondsRealtime(1.0f);

        Time.timeScale = 1.0f;
        Destroy(this.gameObject);

    }

	// Use this for initialization
	void Start () {
        _animator = this.GetComponent<Animator>();

        StartCoroutine(FadeIn());
        Time.timeScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CountDown());
        }	
	}
}
