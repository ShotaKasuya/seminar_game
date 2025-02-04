namespace Domain.IModel.OutGame.SelectSerial
{
    public interface IMutSelectedSerialModel: ISelectedSerialModel
    {
        public void SetSerialPort(string portName);
    }
    
    public interface ISelectedSerialModel
    {
        public string SelectedPortName { get; }
    }
}