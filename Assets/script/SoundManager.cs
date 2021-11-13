using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
///�����Ǘ��N���X
/// </summary>
public class SoundManager : MonoBehaviour
{


    public static SoundManager soundInstance;

    public enum  bgm_Types
    {
        //BGM��
        
    }
    //SE�Ǘ�
    public enum se_Types
    {
        fire,
    }
    //AudioClip
    [SerializeField]
    AudioClip[] m_bgmClips;
    [SerializeField]
    AudioClip[] m_seClips;

    //SEAudioMixer
    [SerializeField]
    AudioMixer audioMixer;


    //AudioSource
    private AudioSource[] m_BgmSources = new AudioSource[2];
    private AudioSource[] m_SeSources = new AudioSource[16];

    // Start is called before the first frame update
    private void Awake()
    {
        //�V���O���g�����V�[���J�ڂ��Ă��j������Ȃ�
        if (soundInstance==null)
        {
            soundInstance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
        //BGM�p AudioSource��ǉ�
        m_BgmSources[0] = gameObject.AddComponent<AudioSource>();
        m_BgmSources[1] = gameObject.AddComponent<AudioSource>();
        
        //SE�pAudioSource�ǉ�
        for (int i = 0; i < m_SeSources.Length; i++)
        {
            m_SeSources[i] = gameObject.AddComponent<AudioSource>();

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySE(se_Types se_Types)
    {
        int index = (int)se_Types;
        if (index<0||m_seClips.Length<=index)
        {
            return;
        }
        foreach (AudioSource source in m_SeSources)
        {
            if(false==source.isPlaying)
            {
                source.clip = m_seClips[index];
                source.Play();
                return;
            }
        }
    }
}
