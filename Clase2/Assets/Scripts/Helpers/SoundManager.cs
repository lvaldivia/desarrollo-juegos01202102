using UnityEngine;

public static class SoundManager 
{
    public static void PlayClipAtPoint(AudioClip clip,Vector3 position){
        if(PlayerPrefs.HasKey("sound")){
            if(PlayerPrefs.GetInt("sound") == 1){
                AudioSource.PlayClipAtPoint(clip,position);
            }
        }else{
            AudioSource.PlayClipAtPoint(clip,position);
        }
        
    }

    public static void PlayAudiosource(AudioSource audioSource){
        audioSource.Play();
        if(PlayerPrefs.HasKey("sound")){
            if(PlayerPrefs.GetInt("sound") == 1){
                audioSource.Play();
            }
        }else{
            
        }
        
    }
}
