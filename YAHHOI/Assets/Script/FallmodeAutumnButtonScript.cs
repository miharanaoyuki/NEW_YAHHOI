using UnityEngine;
using UnityEngine.SceneManagement;

public class FallmodeAutumnButtonScript : MonoBehaviour
{

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("fallmode autumn");
    }

}