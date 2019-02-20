using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using KModkit;

public class TheLombaxCubesScript : MonoBehaviour
{
    public KMBombInfo Bomb;
    public KMBombModule BombModule;
    public KMAudio Audio;

    public KMSelectable Button;

    public Renderer[] Cubes;
    public Renderer[] CubesBases;
    public Renderer button;
    public TextMesh buttonLetter1;
    public TextMesh buttonLetter2;
    public Renderer[] Lights;

    public Material[] buttonColours;

    public TextMesh c1top;
    public TextMesh c1front;
    public TextMesh c1right;
    public TextMesh c1back;
    public TextMesh c1left;
    public TextMesh c1bottom;

    public TextMesh c2top;
    public TextMesh c2front;
    public TextMesh c2right;
    public TextMesh c2back;
    public TextMesh c2left;
    public TextMesh c2bottom;

    public TextMesh c3top;
    public TextMesh c3front;
    public TextMesh c3right;
    public TextMesh c3back;
    public TextMesh c3left;
    public TextMesh c3bottom;

    public TextMesh c4top;
    public TextMesh c4front;
    public TextMesh c4right;
    public TextMesh c4back;
    public TextMesh c4left;
    public TextMesh c4bottom;

    public TextMesh c5top;
    public TextMesh c5front;
    public TextMesh c5right;
    public TextMesh c5back;
    public TextMesh c5left;
    public TextMesh c5bottom;

    public TextMesh c6top;
    public TextMesh c6front;
    public TextMesh c6right;
    public TextMesh c6back;
    public TextMesh c6left;
    public TextMesh c6bottom;

    public String[] Letters;

    int ButtonColour;
    int ButtonLetter1;
    int ButtonLetter2;

    int RedCube;
    int BlueCube;
    int GreenCube;
    int YellowCube;
    int PurpleCube;
    int WhiteCube;

    int C1top;
    int C1front;
    int C1right;
    int C1back;
    int C1left;
    int C1bottom;

    int C2top;
    int C2front;
    int C2right;
    int C2back;
    int C2left;
    int C2bottom;

    int C3top;
    int C3front;
    int C3right;
    int C3back;
    int C3left;
    int C3bottom;

    int C4top;
    int C4front;
    int C4right;
    int C4back;
    int C4left;
    int C4bottom;

    int C5top;
    int C5front;
    int C5right;
    int C5back;
    int C5left;
    int C5bottom;

    int C6top;
    int C6front;
    int C6right;
    int C6back;
    int C6left;
    int C6bottom;

    int SubmitNumber;

    int CubeX;
    int CubeY;
    int CubeXColour;
    int CubeYColour;

    bool correctAnswer;

    static int moduleIdCounter = 1;

    int moduleId;

    private bool moduleSolved;

	void Start()
    {
        CalculateRules();
        StartCoroutine(StartupPart1());
    }

    void Awake()
    {
        moduleId = moduleIdCounter++;
        StartCoroutine(StartupPart2());
        Button.OnInteract += delegate () { StartCoroutine(SubmitAnswer()); return false; };
    }

    void CalculateRules()
    {
        ButtonLetter1 = UnityEngine.Random.Range(0, 26);
        ButtonLetter2 = UnityEngine.Random.Range(0, 26);
        ButtonColour = UnityEngine.Random.Range(0, 6);

        C1top = UnityEngine.Random.Range(0, 26);
        C1front = UnityEngine.Random.Range(0, 26);
        C1right = UnityEngine.Random.Range(0, 26);
        C1back = UnityEngine.Random.Range(0, 26);
        C1left = UnityEngine.Random.Range(0, 26);
        C1bottom = UnityEngine.Random.Range(0, 26);
        C2top = UnityEngine.Random.Range(0, 26);
        C2front = UnityEngine.Random.Range(0, 26);
        C2right = UnityEngine.Random.Range(0, 26);
        C2back = UnityEngine.Random.Range(0, 26);
        C2left = UnityEngine.Random.Range(0, 26);
        C2bottom = UnityEngine.Random.Range(0, 26);
        C3top = UnityEngine.Random.Range(0, 26);
        C3front = UnityEngine.Random.Range(0, 26);
        C3right = UnityEngine.Random.Range(0, 26);
        C3back = UnityEngine.Random.Range(0, 26);
        C3left = UnityEngine.Random.Range(0, 26);
        C3bottom = UnityEngine.Random.Range(0, 26);
        C4top = UnityEngine.Random.Range(0, 26);
        C4front = UnityEngine.Random.Range(0, 26);
        C4right = UnityEngine.Random.Range(0, 26);
        C4back = UnityEngine.Random.Range(0, 26);
        C4left = UnityEngine.Random.Range(0, 26);
        C4bottom = UnityEngine.Random.Range(0, 26);
        C5top = UnityEngine.Random.Range(0, 26);
        C5front = UnityEngine.Random.Range(0, 26);
        C5right = UnityEngine.Random.Range(0, 26);
        C5back = UnityEngine.Random.Range(0, 26);
        C5left = UnityEngine.Random.Range(0, 26);
        C5bottom = UnityEngine.Random.Range(0, 26);
        C6top = UnityEngine.Random.Range(0, 26);
        C6front = UnityEngine.Random.Range(0, 26);
        C6right = UnityEngine.Random.Range(0, 26);
        C6back = UnityEngine.Random.Range(0, 26);
        C6left = UnityEngine.Random.Range(0, 26);
        C6bottom = UnityEngine.Random.Range(0, 26);

        c1top.text = Letters[C1top];
        c1front.text = Letters[C1front];
        c1right.text = Letters[C1right];
        c1back.text = Letters[C1back];
        c1left.text = Letters[C1left];
        c1bottom.text = Letters[C1bottom];
        c2top.text = Letters[C2top];
        c2front.text = Letters[C2front];
        c2right.text = Letters[C2right];
        c2back.text = Letters[C2back];
        c2left.text = Letters[C2left];
        c2bottom.text = Letters[C2bottom];
        c3top.text = Letters[C3top];
        c3front.text = Letters[C3front];
        c3right.text = Letters[C3right];
        c3back.text = Letters[C3back];
        c3left.text = Letters[C3left];
        c3bottom.text = Letters[C3bottom];
        c4top.text = Letters[C4top];
        c4front.text = Letters[C4front];
        c4right.text = Letters[C4right];
        c4back.text = Letters[C4back];
        c4left.text = Letters[C4left];
        c4bottom.text = Letters[C4bottom];
        c5top.text = Letters[C5top];
        c5front.text = Letters[C5front];
        c5right.text = Letters[C5right];
        c5back.text = Letters[C5back];
        c5left.text = Letters[C5left];
        c5bottom.text = Letters[C5bottom];
        c6top.text = Letters[C6top];
        c6front.text = Letters[C6front];
        c6right.text = Letters[C6right];
        c6back.text = Letters[C6back];
        c6left.text = Letters[C6left];
        c6bottom.text = Letters[C6bottom];

        button.material = buttonColours[ButtonColour];
        buttonLetter1.text = Letters[ButtonLetter1];
        buttonLetter2.text = Letters[ButtonLetter2];

        //Making the values for each cube
        RedCube = RedCube + (((C1top + 1) + (C1front + 1) + (C1right + 1)) - (C1back + 1)) * (C1left + 1) - (C1bottom + 1);
        BlueCube = BlueCube + (((C2top + 1) + (C2front + 1) + (C2right + 1)) - (C2back + 1)) * (C2left + 1) - (C2bottom + 1);
        GreenCube = GreenCube + (((C3top + 1) + (C3front + 1) + (C3right + 1)) - (C3back + 1)) * (C3left + 1) - (C3bottom + 1);
        YellowCube = YellowCube + (((C4top + 1) + (C4front + 1) + (C4right + 1)) - (C4back + 1)) * (C4left + 1) - (C4bottom + 1);
        PurpleCube = PurpleCube + (((C5top + 1) + (C5front + 1) + (C5right + 1)) - (C5back + 1)) * (C5left + 1) - (C5bottom + 1);
        WhiteCube = WhiteCube + (((C6top + 1) + (C6front + 1) + (C6right + 1)) - (C6back + 1)) * (C6left + 1) - (C6bottom + 1);
        if (RedCube < 0)
        {
            RedCube = RedCube * -1;
        }
        if (BlueCube < 0)
        {
            BlueCube = BlueCube * -1;
        }
        if (GreenCube < 0)
        {
            GreenCube = GreenCube * -1;
        }
        if (YellowCube < 0)
        {
            YellowCube = YellowCube * -1;
        }
        if (PurpleCube < 0)
        {
            PurpleCube = PurpleCube * -1;
        }
        if (WhiteCube < 0)
        {
            WhiteCube = WhiteCube * -1;
        }
        Debug.LogFormat("[The Lombax Cubes #{0}] The values of the letters on the red cube are: {1}, {2}, {3}, {4}, {5}, {6}.", moduleId, (C1top + 1), (C1front + 1), (C1right + 1), (C1back + 1), (C1left + 1), (C1bottom + 1));
        Debug.LogFormat("[The Lombax Cubes #{0}] The values of the letters on the blue cube are: {1}, {2}, {3}, {4}, {5}, {6}.", moduleId, (C2top + 1), (C2front + 1), (C2right + 1), (C2back + 1), (C2left + 1), (C2bottom + 1));
        Debug.LogFormat("[The Lombax Cubes #{0}] The values of the letters on the green cube are: {1}, {2}, {3}, {4}, {5}, {6}.", moduleId, (C3top + 1), (C3front + 1), (C3right + 1), (C3back + 1), (C3left + 1), (C3bottom + 1));
        Debug.LogFormat("[The Lombax Cubes #{0}] The values of the letters on the yellow cube are: {1}, {2}, {3}, {4}, {5}, {6}.", moduleId, (C4top + 1), (C4front + 1), (C4right + 1), (C4back + 1), (C4left + 1), (C4bottom + 1));
        Debug.LogFormat("[The Lombax Cubes #{0}] The values of the letters on the purple cube are: {1}, {2}, {3}, {4}, {5}, {6}.", moduleId, (C5top + 1), (C5front + 1), (C5right + 1), (C5back + 1), (C5left + 1), (C5bottom + 1));
        Debug.LogFormat("[The Lombax Cubes #{0}] The values of the letters on the white cube are: {1}, {2}, {3}, {4}, {5}, {6}.", moduleId, (C6top + 1), (C6front + 1), (C6right + 1), (C6back + 1), (C6left + 1), (C6bottom + 1));
        Debug.LogFormat("[The Lombax Cubes #{0}] The total value of the red cube is {1}.", moduleId, RedCube);
        Debug.LogFormat("[The Lombax Cubes #{0}] The total value of the blue cube is {1}.", moduleId, BlueCube);
        Debug.LogFormat("[The Lombax Cubes #{0}] The total value of the green cube is {1}.", moduleId, GreenCube);
        Debug.LogFormat("[The Lombax Cubes #{0}] The total value of the yellow cube is {1}.", moduleId, YellowCube);
        Debug.LogFormat("[The Lombax Cubes #{0}] The total value of the purple cube is {1}.", moduleId, PurpleCube);
        Debug.LogFormat("[The Lombax Cubes #{0}] The total value of the white cube is {1}.", moduleId, WhiteCube);
        if (ButtonColour == 0)
        {
            Debug.LogFormat("[The Lombax Cubes #{0}] The colour of the button is red.", moduleId);
        }
        if (ButtonColour == 1)
        {
            Debug.LogFormat("[The Lombax Cubes #{0}] The colour of the button is blue.", moduleId);
        }
        if (ButtonColour == 2)
        {
            Debug.LogFormat("[The Lombax Cubes #{0}] The colour of the button is green.", moduleId);
        }
        if (ButtonColour == 3)
        {
            Debug.LogFormat("[The Lombax Cubes #{0}] The colour of the button is yellow.", moduleId);
        }
        if (ButtonColour == 4)
        {
            Debug.LogFormat("[The Lombax Cubes #{0}] The colour of the button is purple.", moduleId);
        }
        if (ButtonColour == 5)
        {
            Debug.LogFormat("[The Lombax Cubes #{0}] The colour of the button is white.", moduleId);
        }
        ButtonLetter1 = ButtonLetter1 + 1;
        ButtonLetter2 = ButtonLetter2 + 1;
        if (ButtonLetter1 == ButtonLetter2)
        {
            ButtonLetter2 = ButtonLetter2 + 2;
        }        
        if (ButtonLetter1 > 6)
        {
            ButtonLetter1 = ButtonLetter1 % 6;
        }
        if (ButtonLetter2 > 6)
        {
            ButtonLetter2 = ButtonLetter2 % 6;
        }
        if (ButtonLetter1 == 0)
        {
            ButtonLetter1 = 6;
        }
        if (ButtonLetter2 == 0)
        {
            ButtonLetter2 = 6;
        }
        if (ButtonLetter1 == ButtonLetter2)
        {
            if (ButtonLetter1 < 6)
            {
                ButtonLetter1 = ButtonLetter1 + 1;
            }
            else
            {
                ButtonLetter1 = ButtonLetter1 - 1;
            }
        }
        Debug.LogFormat("[The Lombax Cubes #{0}] The value of the left letter on the button is {1}.", moduleId, (ButtonLetter1));
        Debug.LogFormat("[The Lombax Cubes #{0}] The value of the right letter on the button is {1}.", moduleId, (ButtonLetter2));
        
        //Finding cube X
        if (ButtonLetter1 == 1)
        {
            CubeX = RedCube;
            Debug.LogFormat("[The Lombax Cubes #{0}] Cube X is the red cube.", moduleId);
            CubeXColour = 0;
        }
        if (ButtonLetter1 == 2)
        {
            CubeX = BlueCube;
            Debug.LogFormat("[The Lombax Cubes #{0}] Cube X is the blue cube.", moduleId);
            CubeXColour = 1;
        }
        if (ButtonLetter1 == 3)
        {
            CubeX = GreenCube;
            Debug.LogFormat("[The Lombax Cubes #{0}] Cube X is the green cube.", moduleId);
            CubeXColour = 2;
        }
        if (ButtonLetter1 == 4)
        {
            CubeX = YellowCube;
            Debug.LogFormat("[The Lombax Cubes #{0}] Cube X is the yellow cube.", moduleId);
            CubeXColour = 3;
        }
        if (ButtonLetter1 == 5)
        {
            CubeX = PurpleCube;
            Debug.LogFormat("[The Lombax Cubes #{0}] Cube X is the purple cube.", moduleId);
            CubeXColour = 4;
        }
        if (ButtonLetter1 == 6)
        {
            CubeX = WhiteCube;
            Debug.LogFormat("[The Lombax Cubes #{0}] Cube X is the white cube.", moduleId);
            CubeXColour = 5;
        }

        //Finding cube Y
        if (ButtonLetter2 == 1)
        {
            CubeY = RedCube;
            Debug.LogFormat("[The Lombax Cubes #{0}] Cube Y is the red cube.", moduleId);
            CubeYColour = 0;
        }
        if (ButtonLetter2 == 2)
        {
            CubeY = BlueCube;
            Debug.LogFormat("[The Lombax Cubes #{0}] Cube Y is the blue cube.", moduleId);
            CubeYColour = 1;
        }
        if (ButtonLetter2 == 3)
        {
            CubeY = GreenCube;
            Debug.LogFormat("[The Lombax Cubes #{0}] Cube Y is the green cube.", moduleId);
            CubeYColour = 2;
        }
        if (ButtonLetter2 == 4)
        {
            CubeY = YellowCube;
            Debug.LogFormat("[The Lombax Cubes #{0}] Cube Y is the yellow cube.", moduleId);
            CubeYColour = 3;
        }
        if (ButtonLetter2 == 5)
        {
            CubeY = PurpleCube;
            Debug.LogFormat("[The Lombax Cubes #{0}] Cube Y is the purple cube.", moduleId);
            CubeYColour = 4;
        }
        if (ButtonLetter2 == 6)
        {
            CubeY = WhiteCube;
            Debug.LogFormat("[The Lombax Cubes #{0}] Cube Y is the white cube.", moduleId);
            CubeYColour = 5;
        }

        //RULES:

        //Cube X + cube Y is greater than 999
        if (CubeX + CubeY > 999)
        {
            SubmitNumber = (WhiteCube % 10);
            Debug.LogFormat("[The Lombax Cubes #{0}] The value of cube X + cube Y ({1} + {2}) is greater than 999. Expected last digit in the timer is {3}.", moduleId, CubeX, CubeY, SubmitNumber);
        }

        //Cube Y is greater than 50
        else if (CubeY < 50)
        {
            SubmitNumber = (RedCube % 10);
            Debug.LogFormat("[The Lombax Cubes #{0}] The value of cube Y is less than 50. Expected last digit in the timer is {1}.", moduleId, SubmitNumber);
        }

        //Cube X - cube Y is greater than 100
        else if (CubeX - CubeY > 100)
        {
            SubmitNumber = (YellowCube % 10);
            Debug.LogFormat("[The Lombax Cubes #{0}] The value of cube X - cube Y is greater than 100. Expected last digit in the timer is {1}.", moduleId, SubmitNumber);
        }

        //Button and cube X or Y share colour
        else if (ButtonColour == CubeXColour || ButtonColour == CubeYColour)
        {
            SubmitNumber = (BlueCube % 10);
            if (ButtonColour == CubeXColour)
            {
                Debug.LogFormat("[The Lombax Cubes #{0}] The button shares its colour with cube X. Expected last digit in the timer is {1}.", moduleId, SubmitNumber);
            }
            else
            {
                Debug.LogFormat("[The Lombax Cubes #{0}] The button shares its colour with cube Y. Expected last digit in the timer is {1}.", moduleId, SubmitNumber);
            }
        }
             
        //Cube X is red cube or cube Y is yellow cube
        else if (CubeX == RedCube || CubeY == YellowCube)
        {
            SubmitNumber = (PurpleCube % 10);
            if (CubeX == RedCube)
            {
                Debug.LogFormat("[The Lombax Cubes #{0}] The red cube is cube X. Expected last digit in the timer is {1}.", moduleId, SubmitNumber);
            }
            else
            {
                Debug.LogFormat("[The Lombax Cubes #{0}] The yellow cube is cube Y. Expected last digit in the timer is {1}.", moduleId, SubmitNumber);
            }
            
        }

        //If nothing applied
        else
        {
            SubmitNumber = (GreenCube % 10);
            Debug.LogFormat("[The Lombax Cubes #{0}] None of the rules applied. Expected last digit in the timer is {1}.", moduleId, SubmitNumber);
        }
    }

    IEnumerator SubmitAnswer()
    {
        if (!moduleSolved)
        {
            GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
            moduleSolved = true;
            float timeOfPress = (Bomb.GetTime() % 60) % 10;
            timeOfPress = Mathf.FloorToInt(timeOfPress);
            Debug.LogFormat("[The Lombax Cubes #{0}] Pressed the button when the last digit in the timer was {1}.", moduleId, timeOfPress);
            if (timeOfPress == SubmitNumber)
            {
                correctAnswer = true;
            }
            yield return new WaitForSeconds(1f);
            StartCoroutine(CubesDown());
            Lights[0].material = buttonColours[6];
            Lights[1].material = buttonColours[6];
            Lights[2].material = buttonColours[6];
            Lights[3].material = buttonColours[6];
            Lights[4].material = buttonColours[6];
            Lights[5].material = buttonColours[6];
            Lights[6].material = buttonColours[6];
            Lights[7].material = buttonColours[6];
            Lights[8].material = buttonColours[6];
            Lights[9].material = buttonColours[6];
            Lights[10].material = buttonColours[6];
            Lights[11].material = buttonColours[6];
            yield return new WaitForSeconds(1.5f);
            Lights[0].material = buttonColours[5];
            Lights[1].material = buttonColours[5];
            Audio.PlaySoundAtTransform("sound1", transform);
            yield return new WaitForSeconds(0.2f);
            Lights[2].material = buttonColours[5];
            Lights[3].material = buttonColours[5];
            Audio.PlaySoundAtTransform("sound2", transform);
            yield return new WaitForSeconds(0.2f);
            Lights[4].material = buttonColours[5];
            Lights[5].material = buttonColours[5];
            Audio.PlaySoundAtTransform("sound3", transform);
            yield return new WaitForSeconds(0.2f);
            Lights[6].material = buttonColours[5];
            Lights[7].material = buttonColours[5];
            Audio.PlaySoundAtTransform("sound4", transform);
            yield return new WaitForSeconds(0.2f);
            Lights[8].material = buttonColours[5];
            Lights[9].material = buttonColours[5];
            Audio.PlaySoundAtTransform("sound5", transform);
            yield return new WaitForSeconds(0.2f);
            Lights[10].material = buttonColours[5];
            Lights[11].material = buttonColours[5];
            Audio.PlaySoundAtTransform("sound6", transform);
            yield return new WaitForSeconds(0.2f);
            if (correctAnswer)
            {
                Debug.LogFormat("[The Lombax Cubes #{0}] Correct! Module disarmed!", moduleId);
                GetComponent<KMBombModule>().HandlePass();
                Lights[0].material = buttonColours[2];
                Lights[1].material = buttonColours[2];
                Lights[2].material = buttonColours[2];
                Lights[3].material = buttonColours[2];
                Lights[4].material = buttonColours[2];
                Lights[5].material = buttonColours[2];
                Lights[6].material = buttonColours[2];
                Lights[7].material = buttonColours[2];
                Lights[8].material = buttonColours[2];
                Lights[9].material = buttonColours[2];
                Lights[10].material = buttonColours[2];
                Lights[11].material = buttonColours[2];
                Audio.PlaySoundAtTransform("victory", transform);
            }
            else
            {
                Debug.LogFormat("[The Lombax Cubes #{0}] Strike! Incorrect. Resetting module.", moduleId);
                GetComponent<KMBombModule>().HandleStrike();
                Lights[0].material = buttonColours[0];
                Lights[1].material = buttonColours[0];
                Lights[2].material = buttonColours[0];
                Lights[3].material = buttonColours[0];
                Lights[4].material = buttonColours[0];
                Lights[5].material = buttonColours[0];
                Lights[6].material = buttonColours[0];
                Lights[7].material = buttonColours[0];
                Lights[8].material = buttonColours[0];
                Lights[9].material = buttonColours[0];
                Lights[10].material = buttonColours[0];
                Lights[11].material = buttonColours[0];
                yield return new WaitForSeconds(0.5f);
                CalculateRules();
                yield return new WaitForSeconds(1f);
                StartCoroutine(CubesUp());
                yield return new WaitForSeconds(1.5f);
                Lights[0].material = buttonColours[0];
                Lights[1].material = buttonColours[0];
                Lights[2].material = buttonColours[1];
                Lights[3].material = buttonColours[1];
                Lights[4].material = buttonColours[2];
                Lights[5].material = buttonColours[2];
                Lights[6].material = buttonColours[3];
                Lights[7].material = buttonColours[3];
                Lights[8].material = buttonColours[4];
                Lights[9].material = buttonColours[4];
                Lights[10].material = buttonColours[5];
                Lights[11].material = buttonColours[5];
                moduleSolved = false;
                StartCoroutine(CubeStartup());
            }
        }
    }

    IEnumerator StartupPart1()
    {
        moduleSolved = true;
        Lights[0].material = buttonColours[6];
        Lights[1].material = buttonColours[6];
        Lights[2].material = buttonColours[6];
        Lights[3].material = buttonColours[6];
        Lights[4].material = buttonColours[6];
        Lights[5].material = buttonColours[6];
        Lights[6].material = buttonColours[6];
        Lights[7].material = buttonColours[6];
        Lights[8].material = buttonColours[6];
        Lights[9].material = buttonColours[6];
        Lights[10].material = buttonColours[6];
        Lights[11].material = buttonColours[6];
        Cubes[0].transform.localPosition = Cubes[0].transform.localPosition + Vector3.up * -0.06f;
        CubesBases[0].transform.localPosition = CubesBases[0].transform.localPosition + Vector3.up * -0.06f;
        Cubes[1].transform.localPosition = Cubes[1].transform.localPosition + Vector3.up * -0.06f;
        CubesBases[1].transform.localPosition = CubesBases[1].transform.localPosition + Vector3.up * -0.06f;
        Cubes[2].transform.localPosition = Cubes[2].transform.localPosition + Vector3.up * -0.06f;
        CubesBases[2].transform.localPosition = CubesBases[2].transform.localPosition + Vector3.up * -0.06f;
        Cubes[3].transform.localPosition = Cubes[3].transform.localPosition + Vector3.up * -0.06f;
        CubesBases[3].transform.localPosition = CubesBases[3].transform.localPosition + Vector3.up * -0.06f;
        Cubes[4].transform.localPosition = Cubes[4].transform.localPosition + Vector3.up * -0.06f;
        CubesBases[4].transform.localPosition = CubesBases[4].transform.localPosition + Vector3.up * -0.06f;
        Cubes[5].transform.localPosition = Cubes[5].transform.localPosition + Vector3.up * -0.06f;
        CubesBases[5].transform.localPosition = CubesBases[5].transform.localPosition + Vector3.up * -0.06f;
        button.transform.localPosition = button.transform.localPosition + Vector3.up * -0.06f;
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator StartupPart2()
    {
        yield return new WaitForSeconds(6f);
        Lights[0].material = buttonColours[0];
        Lights[1].material = buttonColours[0];
        Lights[2].material = buttonColours[1];
        Lights[3].material = buttonColours[1];
        Lights[4].material = buttonColours[2];
        Lights[5].material = buttonColours[2];
        Lights[6].material = buttonColours[3];
        Lights[7].material = buttonColours[3];
        Lights[8].material = buttonColours[4];
        Lights[9].material = buttonColours[4];
        Lights[10].material = buttonColours[5];
        Lights[11].material = buttonColours[5];
        yield return new WaitForSeconds(1f);
        int movement = 0;
        GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.WireSequenceMechanism, transform);
        while (movement != 60)
        {
            yield return new WaitForSeconds(0.015f);
            Cubes[0].transform.localPosition = Cubes[0].transform.localPosition + Vector3.up * 0.001f;
            CubesBases[0].transform.localPosition = CubesBases[0].transform.localPosition + Vector3.up * 0.001f;
            Cubes[1].transform.localPosition = Cubes[1].transform.localPosition + Vector3.up * 0.001f;
            CubesBases[1].transform.localPosition = CubesBases[1].transform.localPosition + Vector3.up * 0.001f;
            Cubes[2].transform.localPosition = Cubes[2].transform.localPosition + Vector3.up * 0.001f;
            CubesBases[2].transform.localPosition = CubesBases[2].transform.localPosition + Vector3.up * 0.001f;
            Cubes[3].transform.localPosition = Cubes[3].transform.localPosition + Vector3.up * 0.001f;
            CubesBases[3].transform.localPosition = CubesBases[3].transform.localPosition + Vector3.up * 0.001f;
            Cubes[4].transform.localPosition = Cubes[4].transform.localPosition + Vector3.up * 0.001f;
            CubesBases[4].transform.localPosition = CubesBases[4].transform.localPosition + Vector3.up * 0.001f;
            Cubes[5].transform.localPosition = Cubes[5].transform.localPosition + Vector3.up * 0.001f;
            CubesBases[5].transform.localPosition = CubesBases[5].transform.localPosition + Vector3.up * 0.001f;
            button.transform.localPosition = button.transform.localPosition + Vector3.up * 0.001f;
            movement++;
        }
        moduleSolved = false;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(CubeStartup());
    }

    IEnumerator CubeStartup()
    {
        yield return new WaitForSeconds(0.1f);
        if (!moduleSolved)
        {
            StartCoroutine(CubeSpin());
        }
    }

    IEnumerator CubesDown()
    {
        yield return new WaitForSeconds(0.1f);
        int movement = 0;
        GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.WireSequenceMechanism, transform);
        while (movement != 60)
        {
            yield return new WaitForSeconds(0.015f);
            Cubes[0].transform.localPosition = Cubes[0].transform.localPosition + Vector3.up * -0.001f;
            CubesBases[0].transform.localPosition = CubesBases[0].transform.localPosition + Vector3.up * -0.001f;
            Cubes[1].transform.localPosition = Cubes[1].transform.localPosition + Vector3.up * -0.001f;
            CubesBases[1].transform.localPosition = CubesBases[1].transform.localPosition + Vector3.up * -0.001f;
            Cubes[2].transform.localPosition = Cubes[2].transform.localPosition + Vector3.up * -0.001f;
            CubesBases[2].transform.localPosition = CubesBases[2].transform.localPosition + Vector3.up * -0.001f;
            Cubes[3].transform.localPosition = Cubes[3].transform.localPosition + Vector3.up * -0.001f;
            CubesBases[3].transform.localPosition = CubesBases[3].transform.localPosition + Vector3.up * -0.001f;
            Cubes[4].transform.localPosition = Cubes[4].transform.localPosition + Vector3.up * -0.001f;
            CubesBases[4].transform.localPosition = CubesBases[4].transform.localPosition + Vector3.up * -0.001f;
            Cubes[5].transform.localPosition = Cubes[5].transform.localPosition + Vector3.up * -0.001f;
            CubesBases[5].transform.localPosition = CubesBases[5].transform.localPosition + Vector3.up * -0.001f;
            button.transform.localPosition = button.transform.localPosition + Vector3.up * -0.001f;
            movement++;
        }
    }

    IEnumerator CubesUp()
    {
        yield return new WaitForSeconds(0.1f);
        int movement = 0;
        GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.WireSequenceMechanism, transform);
        while (movement != 60)
        {
            yield return new WaitForSeconds(0.015f);
            Cubes[0].transform.localPosition = Cubes[0].transform.localPosition + Vector3.up * 0.001f;
            CubesBases[0].transform.localPosition = CubesBases[0].transform.localPosition + Vector3.up * 0.001f;
            Cubes[1].transform.localPosition = Cubes[1].transform.localPosition + Vector3.up * 0.001f;
            CubesBases[1].transform.localPosition = CubesBases[1].transform.localPosition + Vector3.up * 0.001f;
            Cubes[2].transform.localPosition = Cubes[2].transform.localPosition + Vector3.up * 0.001f;
            CubesBases[2].transform.localPosition = CubesBases[2].transform.localPosition + Vector3.up * 0.001f;
            Cubes[3].transform.localPosition = Cubes[3].transform.localPosition + Vector3.up * 0.001f;
            CubesBases[3].transform.localPosition = CubesBases[3].transform.localPosition + Vector3.up * 0.001f;
            Cubes[4].transform.localPosition = Cubes[4].transform.localPosition + Vector3.up * 0.001f;
            CubesBases[4].transform.localPosition = CubesBases[4].transform.localPosition + Vector3.up * 0.001f;
            Cubes[5].transform.localPosition = Cubes[5].transform.localPosition + Vector3.up * 0.001f;
            CubesBases[5].transform.localPosition = CubesBases[5].transform.localPosition + Vector3.up * 0.001f;
            button.transform.localPosition = button.transform.localPosition + Vector3.up * 0.001f;
            movement++;
        }
    }

    IEnumerator CubeSpin()
    {
        yield return new WaitForSeconds(0.1f);
        int rotation = 0;
        Renderer cube = Cubes[UnityEngine.Random.Range(0, 6)];
        {
            int rotationChoice = UnityEngine.Random.Range(0, 6);
            while (rotation != 180)
            {
                if (rotationChoice == 0)
                {
                    yield return new WaitForSeconds(0.005f);
                    cube.transform.localRotation = Quaternion.Euler(-0.50f, 0.0f, 0.0f) * cube.transform.localRotation; ;
                    rotation++;
                }
                else if (rotationChoice == 1)
                {
                    yield return new WaitForSeconds(0.005f);
                    cube.transform.localRotation = Quaternion.Euler(0.50f, 0.0f, 0.0f) * cube.transform.localRotation; ;
                    rotation++;
                }
                else if (rotationChoice == 2)
                {
                    yield return new WaitForSeconds(0.005f);
                    cube.transform.localRotation = Quaternion.Euler(0.0f, -0.50f, 0.0f) * cube.transform.localRotation; ;
                    rotation++;
                }
                else if (rotationChoice == 3)
                {
                    yield return new WaitForSeconds(0.005f);
                    cube.transform.localRotation = Quaternion.Euler(0.0f, 0.50f, 0.0f) * cube.transform.localRotation; ;
                    rotation++;
                }
                else if (rotationChoice == 4)
                {
                    yield return new WaitForSeconds(0.005f);
                    cube.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -0.50f) * cube.transform.localRotation; ;
                    rotation++;
                }
                else if (rotationChoice == 5)
                {
                    yield return new WaitForSeconds(0.005f);
                    cube.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.50f) * cube.transform.localRotation; ;
                    rotation++;
                }
            }
        }
        StartCoroutine(CubeStartup());
    }
}
