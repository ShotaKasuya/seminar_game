namespace Domain.IModel.InGame
{
    public interface IGameStateModel
    {
        public bool IsPlaying();
    }
    
    public interface IMutGameStateModel: IGameStateModel
    {
        public void SetPlaying();
        public void SetFailStun();
        public void SetPause();
    }

    public enum GameStateType
    {
        /// <summary>
        /// 通常の入力待機状態
        /// </summary>
        Playing,
        /// <summary>
        /// タイプミスをした際の硬直状態
        /// </summary>
        FailStun,
        /// <summary>
        /// ポーズ状態
        /// </summary>
        Pause,
    }
}