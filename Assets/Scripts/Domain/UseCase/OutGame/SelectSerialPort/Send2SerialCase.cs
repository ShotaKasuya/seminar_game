using System;
using Domain.IView.OutGame.SerialTest;
using Module.Serial;
using UnityEngine;

namespace Domain.UseCase.OutGame.SelectSerialPort
{
    public class Send2SerialCase : IDisposable
    {
        public Send2SerialCase
        (
            IPortWritable portWritable,
            ISerialTestView serialTestView
        )
        {
            PortWritable = portWritable;
            SerialTestView = serialTestView;

            serialTestView.OnSend += OnSend;
        }

        private void OnSend(Packet packet)
        {
            var serialized = Convert.ToString(packet.Serialize(), 2).PadLeft(8, '0');
            Debug.Log($"packet: {packet.ToString()}, serialized: {serialized}");
            PortWritable.Write(packet);
        }

        private IPortWritable PortWritable { get; }
        private ISerialTestView SerialTestView { get; }

        public void Dispose()
        {
            SerialTestView.OnSend -= OnSend;
        }
    }
}