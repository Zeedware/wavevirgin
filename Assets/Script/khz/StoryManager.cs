using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour {

    public Text textObject;

	// Use this for initialization
	void Start () {
        textObject.text = "xxxxx";
        
        StartCoroutine(StartAnimation());


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator StartAnimation()
    {
        textObject.text = "ssssssssssssss";
        AudioManagerStory.Instance.playStory(1);
        changeText("Joni adalah anak dari seorang dukun terkemuka di desanya");
        yield return new WaitForSeconds(5);
        changeText("Dukun tersebut bertugas untuk memberikan persembahan pada dewa-dewa");
        AudioManagerStory.Instance.playStory(2);
        yield return new WaitForSeconds(5);
        changeText("Tetapi karena dukun itu tidak mampu memberikan persembahan yang cukup,");
        AudioManagerStory.Instance.playStory(3);
        yield return new WaitForSeconds(5);
        changeText("Joni dikutuk agar hanya bisa mempunyai pasangan yang virgin");
        AudioManagerStory.Instance.playStory(4);
        yield return new WaitForSeconds(5);
        changeText("Setelah dewasa, Joni pergi mencari pasangan ke jakarta");
        AudioManagerStory.Instance.playStory(5);
        yield return new WaitForSeconds(5);
        changeText("Terkutuklah Joni karena dia dilahirkan di era dimana virgin lebih langka daripada panda");
        AudioManagerStory.Instance.playStory(8);
        yield return new WaitForSeconds(5);
        changeText("Akhirnya, berbekal alat pencari jodoh virgin bernama vinder");
        AudioManagerStory.Instance.playStory(7);
        yield return new WaitForSeconds(5);
        changeText("dan kekuatan untuk memanggil gempa di ketika dia berdoa");
        AudioManagerStory.Instance.playStory(8);
        yield return new WaitForSeconds(5);
        changeText("Mulailah perjalanan Joni mencari anak dara di tengah <color=#ff0000ff>gelombang</color> manusia jakarta");
        AudioManagerStory.Instance.playStory(9);
        yield return new WaitForSeconds(9);
        Application.LoadLevel(1);
    }

    void changeText(string put)
    {
        textObject.text = put;
    }
}
