using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    //void Update()
    //{

    //    //左矢印キーを押した時左フリッパーを動かす
    //    if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
    //    {
    //        SetAngle(this.flickAngle);
    //    }
    //    //右矢印キーを押した時右フリッパーを動かす
    //    if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
    //    {
    //        SetAngle(this.flickAngle);
    //    }

    //    //矢印キー離された時フリッパーを元に戻す
    //    if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
    //    {
    //        SetAngle(this.defaultAngle);
    //    }
    //    if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
    //    {
    //        SetAngle(this.defaultAngle);
    //    }
    //}

    void Update()
    {
        //左側をタッチで動かす
        if (IsLeftDisplayTouch() && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //左側タッチ離したら元に戻す
        if (!IsLeftDisplayTouch() && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        //右側をタッチで動かす
        if (IsRightDisplayTouch() && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右側タッチ離したら元に戻す
        if (!IsRightDisplayTouch() && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }


//参考
//https://qiita.com/WisteriaWave/items/b5eafb7069db09a363e3

    //画面左側がタッチされているか(少なくとも1つ以上)
    private bool IsLeftDisplayTouch()
    {
        // Unityエディターの場合
        if (Application.isEditor)
        {
            // マウスで左クリックされているか
            if (Input.GetMouseButton(0) && (Input.mousePosition.x < Screen.width / 2.0f))
            {
                return true;
            }
        }
        // そうでない場合
        else
        {
            // タッチ入力に対応している場合
            if (Input.touchSupported)
            {
                Debug.Log("IsLeftDisplayTouch:Screen.width:" + Screen.width);

                // 各タッチについてそのx座標がスクリーン幅/2よりも小さいものがあるならば画面左側タッチ判定
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Debug.Log("IsLeftDisplayTouch:position.x[" + i + "]:" + Input.touches[i].position.x);
                    if (Input.touches[i].position.x < Screen.width / 2.0f)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    //画面右側がタッチされているか(少なくとも1つ以上)
    private bool IsRightDisplayTouch()
    {

        // Unityエディターの場合
        if (Application.isEditor)
        {
            // マウスで左クリックされているか
            if (Input.GetMouseButton(0) && (Input.mousePosition.x >= Screen.width / 2.0f))
            {
                return true;
            }
            Debug.Log("isEditor:true");
        }
        // そうでない場合
        else
        {
            // タッチ入力に対応している場合
            if (Input.touchSupported)
            {
                Debug.Log("IsRightDisplayTouch:Screen.width:" + Screen.width);
                // 各タッチについてそのx座標がスクリーン幅/2よりも小さいものがあるならば画面左側タッチ判定
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Debug.Log("IsRightDisplayTouch:position.x[" + i + "]:" + Input.touches[i].position.x);
                    if (Input.touches[i].position.x >= Screen.width / 2.0f)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

//参考ここまで

}