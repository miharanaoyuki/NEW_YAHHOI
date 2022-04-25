using UnityEngine;
using UnityEngine.SceneManagement;

public class scenarioButtonScript : MonoBehaviour
{

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("scenario");
    }

}