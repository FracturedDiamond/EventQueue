using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Audio : MonoBehaviour
{
    static int head;
    static int tail;
    const int MAX_PENDING = 16;
    static PlayMessage[] pending = new PlayMessage[MAX_PENDING];
    static int numPending;


    // Public
    static void Init() {
        head = 0;
        tail = 0;
    }


    static void PlaySound(SoundId id, int volume)
    {
        // Walk the pending requests
        for (int i = head; i != tail; i = (i + 1) % MAX_PENDING)
        {
            if (pending[i].id.soundName == id.soundName)    // Check if the sounds are the same (e.g. two cannon fires)
            {
                // Use the larger of the two volumes.
                pending[i].volume = Math.Max(volume, pending[i].volume);

                // Don't need to enqueue.
                return;
            }
        }

        Debug.Assert((tail + 1) % MAX_PENDING != head, "Fail. Smh");    // Will send a debug statement if false

        // Add to the end of the list
        pending[tail].id = id;
        pending[tail].volume = volume;
        tail = (tail +1) % MAX_PENDING;
    }


    public void StartSound(SoundId resource, int volume)
    {
        Debug.Log("Noise");
    }

    public void Update()
    {
        // If there are no pending requests, do nothing
        if (head == tail) { return; }

        SoundId resource;
        resource.soundName = "Cannon";

        StartSound(resource, pending[head].volume);

        head = (head + 1) % MAX_PENDING;
    }


}
