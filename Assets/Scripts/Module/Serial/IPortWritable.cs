using System.IO.Ports;

namespace Module.Serial
{
    public interface IPortWritable
    {
        public void RenamePort(string name);
        public void Write(Finger finger);
    }

    public interface IPortInitializable
    {
        public void InitializePort(SerialPort serialPort);
    }

    /// <summary>
    /// 手の指を表す列挙型。
    /// </summary>
    public enum Finger
    {
        /// <summary>
        /// 親指。
        /// </summary>
        Thumb,

        /// <summary>
        /// 人差し指。
        /// </summary>
        Index,

        /// <summary>
        /// 中指。
        /// </summary>
        Middle,

        /// <summary>
        /// 薬指。
        /// </summary>
        Ring,

        /// <summary>
        /// 小指。
        /// </summary>
        Little,
    }
}