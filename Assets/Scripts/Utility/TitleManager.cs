using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    [SerializeField]
    private GameObject fadePannel;

    public void StartGame(string sceneName)
    {
        StartCoroutine(SceneTransition(sceneName));
    }

    private IEnumerator SceneTransition(string sceneName)
    {
        fadePannel.SetActive(true);

        fadePannel.GetComponent<Animator>().SetTrigger("_isStart");

        SoundManager.Instance.PlaySe("button");

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(sceneName);
    }

    // Use this for initialization
    void Start () {
        SoundManager.Instance.PlayBgm("title");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
