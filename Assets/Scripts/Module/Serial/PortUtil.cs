#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
using System.IO.Ports;
#elif UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX
using System.IO;
#endif
using System.Collections.Generic;
using System.Linq;

namespace Module.Serial
{
    public static class PortUtil
    {
        public static List<string> GetSerialPorts()
        {
            var ret =
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
         GetSerialPortsWindows();
#elif UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX
                GetSerialPortsLinux();
#else
        Debug.LogWarning("このプラットフォームではサポートされていません。");
#endif
            return ret;
        }

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        // Windows向け: System.Managementを利用
        private static List<string> GetSerialPortsWindows()
        {
            List<string> ports = SerialPort.GetPortNames().ToList();
            return ports;
        }
#elif UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX

        // Linux向け: /devディレクトリをチェック
        private static List<string> GetSerialPortsLinux()
        {
            List<string> ports = new();
            try
            {
                // Linuxのシリアルポートは通常/dev/tty*に存在
                var devices = Directory.GetFiles("/dev/", "tty*");

                foreach (var device in devices)
                {
                    // Arduinoなど特定のデバイス名で絞り込む
                    if (device.Contains("ttyUSB") || device.Contains("ttyACM"))
                    {
                        ports.Add(device);
                        Debug.Log($"Arduinoが接続されているポート: {device}");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Linuxでポート情報を取得中にエラーが発生しました: {ex.Message}");
            }

            return ports;
        }
#endif
    }
}