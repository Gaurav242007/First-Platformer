using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
public class BlockDodgeLoader : MonoBehaviour
{
    
    public GameObject loadingScreen;
    public Slider slider;
    public TMP_Text progressText;
    private AudioSource source;
    public void LoadLevel (int sceneIndex)  
    {
        source = FindObjectOfType<AudioSource>();
        StartCoroutine(LoadAsyncronously(sceneIndex));
    }
    
    IEnumerator LoadAsyncronously (int sceneIndex) 
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        source.Play();
        
        while (!operation.isDone)
        {
            // unity loading go from 0 - 0.9
            //  if the loading end at .9 then
            // divide by .9 to set the loading to full .9/.9 => 1
            // return between 0 and 1
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }
}
