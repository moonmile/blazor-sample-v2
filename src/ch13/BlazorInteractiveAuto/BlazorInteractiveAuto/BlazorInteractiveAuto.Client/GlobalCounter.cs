namespace BlazorInteractiveAuto.Client
{
    /// <summary>
    /// アプリケーション全体で共通化するカウンタークラス
    /// </summary>
    public class GlobalCounter
    {
        public GlobalCounter() { }
        public int Value { get; set; }
        public void Increment() {
            Value++;
        }

        /// <summary>
        /// シングルトンオブジェクトを取得
        /// </summary>
        public static GlobalCounter Instance { get; private set; } = new GlobalCounter();
    }
}
