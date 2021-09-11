using UnityEngine.SceneManagement;
public static class StateManager{

    public static void changeScene(string scene){
        SceneManager.LoadScene(scene);
    }

    public static void changeScene(int scene){
        SceneManager.LoadScene(scene);
    }
}

