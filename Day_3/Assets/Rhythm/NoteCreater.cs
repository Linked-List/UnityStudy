using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NoteCreater : MonoBehaviour
{
    private StreamReader fileRead = null;
    private AudioSource aud=null;
    [SerializeField]
    private GameObject notePrefab=null;
    [SerializeField]
    private float sync=0.0f;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
        //fileRead = new StreamReader("Assets/Rhythm/Pattern.txt");
        fileRead = new StreamReader("Pattern.txt");
        while (!fileRead.EndOfStream)
        {
            string[] s = fileRead.ReadLine().Split(' ');
            Instantiate(notePrefab, new Vector3(-3.0f + float.Parse(s[0]) * 2, 16.25f + 2.5f*float.Parse(s[1])), Quaternion.identity);
        }
        fileRead.Close();
        aud.PlayDelayed(sync);
        //aud.Play();
    }
}
