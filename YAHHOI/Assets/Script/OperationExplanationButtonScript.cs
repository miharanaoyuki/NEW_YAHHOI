using UnityEngine;
using UnityEngine.SceneManagement;

public class OperationExplanationButtonScript: MonoBehaviour
{

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Operation explanation");
    }

}