﻿// qiita: https://qiita.com/cet-t/private/15ac91b84f74934c1900

using System.Collections.Generic;
using System.Text;
using trrne.Box;
using trrne.Secret;
using UnityEngine;

// Singleton<T>を継承するだけでそのクラスがシングルトンになる
sealed class HowToUse : Singleton<HowToUse>
{
    class DemoClass : MonoBehaviour { }
    // シーン遷移で破壊するか
    protected override bool DontDestroy => true;

    void GOBJECT()
    {
        const string TAG = "tag_name";

        // タグを指定してコンポーネントを取得
        _ = Gobject.GetWithTag<DemoClass>(tag: TAG);

        // タグを指定してオブジェクトを取得
        _ = Gobject.GetWithTag(tag: TAG);

        // 取得できたらtrue, できなかったらfalse
        if (Gobject.TryGetWithTag<DemoClass>(t: out _, tag: TAG)) ;

        // 子供から取得
        // 引数を省略すると0が入る
        _ = transform.GetFromChild<DemoClass>(index: 1);

        // 親、ルートから取得
        _ = transform.GetFromParent<DemoClass>();
        _ = transform.GetFromRoot<DemoClass>();

        DemoClass[] tests = { };

        // 生成する
        tests[0].Instantiate(p: transform.position, r: Quaternion.identity);

        // 配列からランダムで生成
        tests.Instantiate();

        // playersがnullじゃなかったら生成
        tests[0].TryInstantiate();
        tests.TryInstantiate();
    }

    void INPUTS()
    {
        // Input.anyKeyDown と同等
        if (Inputs.down) ;
        if (Inputs.Down()) ;

        // Input.anyKey と同等
        if (Inputs.pressed) ;
        if (Inputs.Pressed()) ;

        // Input.GetMouseButtonDown() と同等
        if (Inputs.Down(click: 0)) ;
        if (Inputs.Pressed(click: 0)) ;
        if (Inputs.Up(click: 0)) ;

        // Input.GetKeyDown() と同等
        if (Inputs.Down(key: KeyCode.Space)) ;
        if (Inputs.Pressed(key: KeyCode.Space)) ;
        if (Inputs.Up(key: KeyCode.Space)) ;

        // Input.GetButtonDown() と同等
        if (Inputs.Down(name: "Horizontal")) ;
        if (Inputs.Pressed(name: "Horizontal")) ;
        if (Inputs.Up(name: "Horizontal")) ;
    }

    enum TestEnum { A, B, C }
    void TYPECASTING()
    {
        // Vector3をVector2にキャスト
        _ = new Vector3().ToV2();

        // Vector2をVector3にキャスト
        _ = new Vector2().ToV3();

        // Vector3をQuaternionにキャスト
        _ = new Vector3().ToQ();

        // intをenumにキャスト
        _ = TypeCasting.ToEnum<TestEnum>(0);
    }

    void STOPWATCH()
    {
        // 引数にtrueを渡すと宣言した瞬間ストップウォッチが開始する
        Stopwatch sw = new(); // new(start: true);

        // 制御
        sw.Start();
        sw.Stop();
        sw.Restart();
        sw.Reset();

        // 経過時間(時間)を取得
        _ = sw.h;
        _ = sw.hour;
        _ = sw.H();
        _ = sw.hf;
        _ = sw.hourf;
        _ = sw.Hf(digit: 3); // floatは桁指定も可能

        // 経過時間(分)を取得
        _ = sw.m;
        _ = sw.minute;
        _ = sw.M();
        _ = sw.mf;
        _ = sw.minutef;
        _ = sw.Mf(digit: 3);

        // 経過時間(秒)を取得
        _ = sw.s;
        _ = sw.second;
        _ = sw.S();
        _ = sw.sf;
        _ = sw.secondf;
        _ = sw.Sf(digit: 3);

        // 経過時間(ミリ秒)を取得
        _ = sw.ms;
        _ = sw.millisecond;
        _ = sw.MS();
        _ = sw.msf;
        _ = sw.millisecondf;
        _ = sw.MSf(digit: 3);
    }

    void RAND()
    {
        // minからmaxまでで乱数を生成する
        // max,minのどちらかだけ指定することも可能
        _ = Rand.Int(min: 0, max: 10);

        // 0.0~10.0までの範囲で生成
        _ = Rand.Float(max: 10);

        // 文字列生成
        // 2~10文字
        _ = Rand.String();

        // ごちゃまぜ10文字
        _ = Rand.String(length: 10);
        _ = Rand.String(length: 10, type: RandStringType.Mixed);

        // アルファベット大文字小文字ごちゃまぜ
        _ = Rand.String(length: 10, type: RandStringType.ABMixed);

        // アルファベット大文字だけ
        _ = Rand.String(length: 10, type: RandStringType.ABUpper);

        // アルファベット小文字だけ
        _ = Rand.String(length: 10, type: RandStringType.ABLower);

        // 数値だけ
        _ = Rand.String(length: 10, type: RandStringType.Number);

        // 配列からランダムに選択
        int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        _ = arr.Choice();

        // リストからランダムに選択
        _ = new List<int>(arr).Choice();
    }

    void LOTTERY()
    {
        // LotteryPairで各要素と、その重みを定義
        LotteryPair<string> pair = new(
            ("tanaka", 10),
            ("matsuda", 90),
            ("yoshino", 11.1)
        );
        _ = Lottery.Weighted(pair);

        // 二分探索木(binary search tree)
        _ = Lottery.Bst(1.2, 0.2, 123.4);
    }

    struct SaveData
    {
        public string name;
        public int age;
    }
    void SAVE()
    {
        SaveData data = new()
        {
            name = "hoge",
            age = 100
        };

        // セーブデータを書き込む
        string password = "パスワード",
            path = "出力先のファイルパス";
        Save.Write(data, password, path);

        // セーブデータを読み取る
        _ = Save.Read<SaveData>(password, path);
    }

    void ENCRYPTION()
    {
        // 上のSaveの内部処理

        string src = "暗号化したい文字列",
            password = "暗号化のパスワード";
        IEncryption encrypt = new RijndaelEncryption(password);
        // 暗号化1: 手動で文字列をバイト配列にしてから暗号化
        byte[] encrypted1 = encrypt.Encrypt(Encoding.UTF8.GetBytes(src));
        // 暗号化2: 自動で文字列をバイト配列にしてから暗号化
        byte[] encrypted2 = encrypt.Encrypt(src);

        // 復号化1: バイト配列の暗号を復号し、バイト配列で返す
        byte[] decrypted1 = encrypt.Decrypt(encrypted1);
        // 復号化2: バイト配列の暗号を復号し、文字列にしてから返す
        string decrypted2 = encrypt.DecryptToString(encrypted1);
    }
}