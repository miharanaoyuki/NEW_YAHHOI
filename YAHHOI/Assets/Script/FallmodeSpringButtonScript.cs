using UnityEngine;
using UnityEngine.SceneManagement;

public class FallmodeSpringButtonScript: MonoBehaviour
{

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("fallmode spring");
    }

}