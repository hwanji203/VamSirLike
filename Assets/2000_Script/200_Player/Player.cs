using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int Hp { get; private set; }


    public Dictionary<AtkReason, int> AtkReasonDictionary = new Dictionary<AtkReason, int>();
    private int mAtk;
    public int Atk
    {
        get
        {
            mAtk = 0;
            foreach (var atkValue in AtkReasonDictionary)
            {
                mAtk += atkValue.Value;
            }

            return mAtk;
        }
    }

    public Dictionary<MoveSpeedReason, int> MoveSpeedReasonDictionary = new Dictionary<MoveSpeedReason, int>();
    private int mMoveSpeed;
    public int MoveSpeed
    {
        get
        {
            mMoveSpeed = 0;
            foreach (var atkValue in MoveSpeedReasonDictionary)
            {
                mMoveSpeed += atkValue.Value;
            }

            return mMoveSpeed;
        }
    }

    private void Update()
    {
        PlayerMoveInput();
    }

    private void PlayerMoveInput()
    {
        // Ű �Է�
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            transform.position += (Vector3.up * Time.deltaTime) * MoveSpeed;
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            transform.position += Vector3.down * Time.deltaTime * MoveSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            transform.position += Vector3.left * Time.deltaTime * MoveSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            transform.position += Vector3.right * Time.deltaTime * MoveSpeed;
        }
    }

    public void AddAtkReason(AtkReason reason, int value)
    {
        if (AtkReasonDictionary.TryAdd(reason, value) == false)
        {
            // Dic�� �ִ� �Ϳ� �����ߴ� => �̹� �ش� Key ���� ����
            AtkReasonDictionary[reason] = value;

        }

#if Log
        Log.Message(LogType.StatAtk, $"���ݷ� ��ġ ��ȭ {value}");
#endif
    }

    public void AddMoveSpeedReason(MoveSpeedReason reason, int value)
    {
        if (MoveSpeedReasonDictionary.TryAdd(reason, value) == false)
        {
            // Dic�� �ִ� �Ϳ� �����ߴ� => �̹� �ش� Key ���� ����
            MoveSpeedReasonDictionary[reason] = value;

        }

        SceneManager.LoadScene("sdf", LoadSceneMode.Additive);

#if Log
        Log.Message(LogType.StatMoveSpeed, $"�̵��ӵ� ��ġ ��ȭ {value}");
#endif
    }
}