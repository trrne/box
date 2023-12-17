using System;
using System.Collections.Generic;
using trrne.Box;
using trrne.Core;
using trrne.Secret;
using UnityEngine;

// Singletonを継承するだけでどこからでも参照できるようになる
sealed class HowToUse : Singleton<HowToUse>
{
    // シーン遷移で破壊するか
    protected override bool DontDestroyOnLoad => true;

    void Gobject_()
    {
        string tag = "Player";

        // タグを指定してコンポーネントを取得
        _ = Gobject.GetWithTag<Player>(tag: tag);

        // タグを指定してオブジェクトを取得
        _ = Gobject.GetWithTag(tag: tag);

        // 取得できたらtrue, できなかったらfalse
        if (Gobject.TryGetWithTag<Player>(t: out _, tag: tag))
        {
        }

        // 子供から取得
        // 引数を省略すると0が入る
        _ = transform.GetFromChild<Player>(index: 1);

        // 親、ルートから取得
        _ = transform.GetFromParent<Player>();
        _ = transform.GetFromRoot<Player>();

        Player[] players = { };

        // 生成する
        players[0].Instantiate(p: transform.position, r: Quaternion.identity);

        // 配列からランダムで生成
        players.Instantiate();

        // playersがnullじゃなかったら生成
        players[0].TryInstantiate();
        players.TryInstantiate();
    }

    void Inputs_()
    {
        // Input.anyKeyDown と同等
        if (Inputs.down) { }
        if (Inputs.Down()) { }

        if (Inputs.pressed) { }
        if (Inputs.Pressed()) { }

        // Input.GetMouseButtonDown() と同等
        if (Inputs.Down(click: 0)) { }
        if (Inputs.Pressed(click: 0)) { }
        if (Inputs.Up(click: 0)) { }

        // Input.GetKeyDown() と同等
        if (Inputs.Down(key: KeyCode.Space)) { }
        if (Inputs.Pressed(key: KeyCode.Space)) { }
        if (Inputs.Up(key: KeyCode.Space)) { }

        // Input.GetButtonDown() と同等
        if (Inputs.Down(name: "Horizontal")) { }
        if (Inputs.Pressed(name: "Horizontal")) { }
        if (Inputs.Up(name: "Horizontal")) { }
    }

    enum Test { A, B, C }
    void TypeCasting_()
    {
        // Vector3をVector2にキャスト
        _ = new Vector3().ToV2();

        // Vector2をVector3にキャスト
        _ = new Vector2().ToV3();

        // Vector3をQuaternionにキャスト
        _ = new Vector3().ToQ();

        // intをenumにキャスト
        _ = TypeCasting.ToEnum<Test>(0);
    }

    void Stopwatch_()
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
        _ = sw.H();
        _ = sw.hf;
        _ = sw.Hf(digit: 3); // floatは桁指定も可能

        // 経過時間(分)を取得
        _ = sw.m;
        _ = sw.M();
        _ = sw.mf;
        _ = sw.Mf(digit: 3);

        // 経過時間(秒)を取得
        _ = sw.s;
        _ = sw.S();
        _ = sw.sf;
        _ = sw.Sf(digit: 3);

        // 経過時間(ミリ秒)を取得
        _ = sw.ms;
        _ = sw.MS();
        _ = sw.msf;
        _ = sw.MSf(digit: 3);
    }

    void Rand_()
    {
        // minからmaxまでで乱数を生成する
        // max,minのどちらかだけ指定することも可能
        _ = Rand.Int(min: 0, max: 10);

        // 0.0~10.0までの範囲で生成
        _ = Rand.Float(max: 10);

        // 文字列生成
        // 2~10文字
        _ = Rand.String();

        // 10文字
        _ = Rand.String(length: 10);

        // ごちゃまぜ
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
        List<int> list = new(arr);
        _ = list.Choice();
    }

    void Lottery_()
    {
        // LotteryPairで各要素と、その重みを定義
        LotteryPair<string, float> pair = new(
            ("tanaka", 10),
            ("matsuda", 90),
            ("yoshino", 11.1f)
        );
        _ = Lottery.Weighted(pair);

        // 二分探索木(binary search tree)
        _ = Lottery.Bst(1.2f, 0.2f, 123.4f);
    }

    struct SaveData { public string name; public int age; }
    void Save_()
    {
        SaveData data = new SaveData
        {
            name = "hoge",
            age = 100
        };

        // セーブデータを書き込む
        string pw = "foobar", path = "./../../../Assets/savedata.sav";
        Save.Write(data: data, password: pw, path: path);

        // セーブデータを読み取る
        _ = Save.Read<SaveData>(password: pw, path: path);
    }
}