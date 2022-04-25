using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonScript : MonoBehaviour
{

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("title");
    }

}