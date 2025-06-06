using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
public static AudioManager Instance;

[SerializeField] private AudioClip KilledEnemy;
[SerializeField] private AudioClip jumpsound;
[SerializeField] private AudioClip shoot;

private AudioSource source;
   private void Awake(){
          if(Instance == null){
                Instance = this;
          }
          else{
                Destroy(gameObject);
          }
          DontDestroyOnLoad(gameObject);
   }

   void Start(){
          source = GetComponent<AudioSource>();
   }
   public void playjumpsound(){ 
          source.PlayOneShot(jumpsound);
   }

    // Update is called once per frame
    void Update()
    {
        
    }
}
