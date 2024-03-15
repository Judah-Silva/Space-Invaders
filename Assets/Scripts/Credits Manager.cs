using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FinishCredits());
    }

    IEnumerator FinishCredits()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("Main Menu");
    }
}
