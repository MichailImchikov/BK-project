using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class ExitMB : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ExitGame);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
