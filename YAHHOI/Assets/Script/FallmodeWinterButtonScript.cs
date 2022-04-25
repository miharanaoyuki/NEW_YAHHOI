using UnityEngine;
using UnityEngine.SceneManagement;

public class FallmodeWinterButtonScript: MonoBehaviour
{

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("fallmode winter");
    }

}