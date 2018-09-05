using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vizualizer : MonoBehaviour {
    public GameObject line;
    //public Color color;
    private const int SampleSize = 1024;
    public float dbValue;
    public float rmsValue;
    public float pitchvalue;
    public float VisualModifier = 50.0f;
    public float smoothspeed = 10.0f;
    public float maxVisualScale = 25.0f;
    public float KeepPercentage = 0.5f;

    private AudioSource source;
    private float[] samples;
    private float[] spectrum;
    private float Srate;
    private Transform[] visualList;
    private float[] VisualScale;
    public int amountVisual = 256;

    void Start()
    {
        source = GetComponent<AudioSource>();
        samples = new float[SampleSize];
        spectrum = new float[SampleSize];
        Srate = AudioSettings.outputSampleRate;
        SpawnCircle();
        //SpawnLine();

    }
    private void SpawnLine()
    {
        VisualScale = new float[amountVisual];
        visualList = new Transform[amountVisual];
        for (int i = 0; i < amountVisual; i++)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;
            visualList[i] = go.transform;
            visualList[i].position = Vector3.right * i;
        }
    }
    private void UpdateVisual()
    {
        int visualIndex = 0;
        int spectrumIndex = 0;
        int averageSize = (int)((SampleSize * KeepPercentage) / amountVisual);
        while (visualIndex < amountVisual)
        {
            int j = 0;
            float sum = 0;
            while (j < averageSize)
            {
                sum += spectrum[spectrumIndex];
                spectrumIndex++;
                j++;
            }
            float ScaleY = sum / averageSize * VisualModifier;
            VisualScale[visualIndex] -= Time.deltaTime * smoothspeed;
            if (VisualScale[visualIndex] < ScaleY)
                VisualScale[visualIndex] = ScaleY;
            
                if (VisualScale[visualIndex] > maxVisualScale)
                    VisualScale[visualIndex] = maxVisualScale;

            //visualList[visualIndex].localScale = Vector3.one + Vector3.up * VisualScale[visualIndex];
            visualList[visualIndex].localScale = new Vector3(0.2F, 0.25F, 0) + Vector3.up * VisualScale[visualIndex];
            visualIndex++;

        }
    }
    private void SpawnCircle()
    {
        VisualScale = new float[amountVisual];
        visualList = new Transform[amountVisual];

        Vector3 center = Vector3.zero;
        float radius = 1f;
        for (int i = 0; i < amountVisual; i++)
        {
            float angle = i * 1.0f / amountVisual;
            angle = angle * Mathf.PI * 2;// * 2;
            float x = center.x + Mathf.Cos(angle) * radius;
            float y = center.x + Mathf.Sin(angle) * radius;
            Vector3 pos = center + new Vector3(x,y,60);
            GameObject go = GameObject.Instantiate(line, line.transform.position, line.transform.rotation) as GameObject;
            line.transform.localScale = new Vector3(0.2f, 0.2f, 0);
            go.transform.rotation = Quaternion.LookRotation(Vector3.forward ,pos);
            visualList[i] = go.transform;
        }

    }
        void Update()
        {
            AnalyzeSound();
            UpdateVisual();
        }
        private void AnalyzeSound()
        {
            source.GetOutputData(samples, 0);
            //Достаємо RMS
            int i = 0;
            float sum = 0;
            for (i = 0; i < SampleSize; i++)
            {
                sum += samples[i] * samples[i];
            }
            rmsValue = Mathf.Sqrt(sum / SampleSize);
            //Достаємо ДБ 
            dbValue = 20 * Mathf.Log10(rmsValue / 0.1f); //tut
            //Достаємо спектрум
            source.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
            //Знаходимо pitch
            float maxV = 0;
            var maxN = 0;
            for (i = 0; i < SampleSize; i++)
            {

                if (!(spectrum[i] > maxV) || !(spectrum[i] > 0.0f))

                    continue;

                maxV = spectrum[i];
                maxN = i;
            }
            float freqN = maxN;
            if (maxN > 0 && maxN < SampleSize - 1)
            {

                var dL = spectrum[maxN - 1] / spectrum[maxN];
                var dR = spectrum[maxN + 1] / spectrum[maxN];
                freqN += 0.5f * (dR * dR - dL * dL); // 0.5 na 0.1
        }
            pitchvalue = freqN * (Srate / 2) / SampleSize; //z 2 na 20



        }
    }
