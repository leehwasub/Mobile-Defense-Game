using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateCharacter : MonoBehaviour
{
    public GameObject characterPrefab1;
    public GameObject characterPrefab2;

    private GameObject characterPrefab;
    private GameObject character;
    private AudioSource audioSource;
    private CharacterStat characterStat;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        // 마우스 : -1, 모바일: 0 이상
        if (EventSystem.current.IsPointerOverGameObject(-1) == true) return;
        if (EventSystem.current.IsPointerOverGameObject(0) == true) return;
        if (GameManager.instance.nowSelect == 1)
        {
            characterPrefab = characterPrefab1;
            characterStat = characterPrefab.GetComponent<CharacterStat>();
        }
        else if (GameManager.instance.nowSelect == 2)
        {
            characterPrefab = characterPrefab2;
            characterStat = characterPrefab.GetComponent<CharacterStat>();
        }
        if (character == null)
        {
            CharacterStat characterStat = characterPrefab.GetComponent<CharacterStat>();
            if (characterStat.canCreate(GameManager.instance.seed))
            {
                character = (GameObject)Instantiate(characterPrefab, transform.position, Quaternion.identity);
                GameManager.instance.characterAddCount++;
                audioSource.PlayOneShot(audioSource.clip);
                GameManager.instance.seed -= character.GetComponent<CharacterStat>().cost;
                GameManager.instance.updateText();
            }
        }
    }

}
