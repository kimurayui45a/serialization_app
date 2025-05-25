using System;
using System.Text.Json;  // JSONのシリアル化／逆シリアル化に関する機能を提供

namespace SerializationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 3つの FileObject を作成してリストに追加
            //var renameData = new RenameData
            //{
            //    Datas = new List<FileObject>
            //    {
            //        new FileObject { Path = "Text1.txt", RenamePath = "NewText1.txt" },
            //        new FileObject { Path = "Text2.txt", RenamePath = "NewText2.txt" },
            //        new FileObject { Path = "Text3.txt", RenamePath = "NewText3.txt" }
            //    }

            //};


            //// コマンドライン引数から出力ファイルパスを取得
            //if (args.Length == 0)
            //{
            //    Console.WriteLine("出力先のファイルパスをコマンドライン引数で指定してください。");
            //    return;
            //}

            // コマンドライン引数から出力ファイルパスを取得
            //string outputPath = args[0];

            // JSON にシリアル化時に読みやすく改行する
            //var options = new JsonSerializerOptions { WriteIndented = true };

            //// renameDataオブジェクトをJSON文字列に変換（シリアル化）
            //string json = JsonSerializer.Serialize(renameData, options);


            //// コマンドライン引数で指定したファイルに書き出し
            //File.WriteAllText(outputPath, json);

            //Console.WriteLine($"JSONを書き出しました: {outputPath}");


            //// 表示
            //Console.WriteLine(json);


            // 宿題2
            // JSONファイルを読み込む
            string json = File.ReadAllText(args[0]);

            // 逆シリアル化してオブジェクトに戻す
            var renameData = JsonSerializer.Deserialize<RenameData>(json);

            // 中身を表示（ループで1件ずつ）、nullの可能性を考慮
            //if (renameData?.Datas != null)
            //{
            //    foreach (var file in renameData.Datas)
            //    {
            //        Console.WriteLine($"Path: {file.Path}, RenamePath: {file.RenamePath}");
            //    }
            //}

            // コンソールアプリのディレクトリ内に「Text1.txt」を置く場合
            //if (renameData?.Datas != null) 
            //{
            //    // 各ファイルをリネーム
            //    foreach (var file in renameData.Datas)
            //    {
            //        if (File.Exists(file.Path))
            //        {
            //            File.Move(file.Path, file.RenamePath); // ← リネーム処理
            //            Console.WriteLine($"{file.Path} → {file.RenamePath} にリネームしました");
            //        }
            //        else
            //        {
            //            Console.WriteLine($"{file.Path} が存在しません");
            //        }
            //    }
            //}



            // コマンドライン引数で指定したJsonと同じディレクトリ内に「Text1.txt」を置く場合
            string jsonPath = args[0];
            string baseDir = Path.GetDirectoryName(jsonPath)!;


            if (renameData?.Datas != null)
            {
                // 各ファイルをリネーム
                foreach (var file in renameData.Datas)
                {
                    string oldPath = Path.Combine(baseDir, file.Path);
                    string newPath = Path.Combine(baseDir, file.RenamePath);

                    if (File.Exists(oldPath))
                    {
                        File.Move(oldPath, newPath);
                        Console.WriteLine($"{oldPath} を {newPath} にリネームしました");
                    }
                    else
                    {
                        Console.WriteLine($"{oldPath} が存在しません");
                    }
                }
            }







            //---------公式リファレンスの内容------------------------

            //var weatherForecast = new WeatherForecast
            //{
            //    Date = DateTime.Parse("2019-08-01"),
            //    TemperatureCelsius = 25,
            //    Summary = "Hot"
            //};

            // 出力するJSONファイルのファイル名を指定
            //string fileName = "WeatherForecast.json";

            //// weatherForecastオブジェクトをJSON文字列に変換（シリアル化）
            //string jsonString = JsonSerializer.Serialize(weatherForecast);

            //// JSON文字列を指定したファイル名でファイルに書き込む
            //File.WriteAllText(fileName, jsonString);

            //// 書き込んだファイルを読み込み、内容をコンソールに表示
            //Console.WriteLine(File.ReadAllText(fileName));


            // 【デスクトップに出力する場合】
            //// デスクトップパスの取得
            //string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            //// デスクトップパスとJSONファイルのファイル名を繋ぐ
            //// Path.Combine：複数のパス要素（フォルダ名やファイル名）を安全につなげるためのメソッド
            //string fullPath = Path.Combine(desktopPath, fileName);

            //// JSONにシリアル化して保存
            //string jsonString2 = JsonSerializer.Serialize(weatherForecast, new JsonSerializerOptions { WriteIndented = true });

            //// JSON文字列を指定したファイル名でファイルに書き込む
            //File.WriteAllText(fullPath, jsonString2);


        }
    }
}