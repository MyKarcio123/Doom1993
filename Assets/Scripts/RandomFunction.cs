using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFunction : MonoBehaviour
{
    public float randomNumberThreeSigma(float minValue,float maxValue)
    {
        float u, v, S;
        do
        {
            u = 2.0f * Random.value - 1.0f;
            v = 2.0f * Random.value - 1.0f;
            S = u * u + v * v;
        } while (S >= 1.0f);
        float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);
        float mean = (minValue + maxValue) / 2.0f;
        float sigma = (maxValue - mean) / 3.0f;
        return Mathf.Clamp(std * sigma + mean, minValue, maxValue);
    }
}
