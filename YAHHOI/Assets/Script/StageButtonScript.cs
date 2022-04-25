using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButtonScript : MonoBehaviour
{

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("stage select");
    }

}