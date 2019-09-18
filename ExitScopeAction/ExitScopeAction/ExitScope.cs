using System;
using System.Diagnostics;

namespace ExitScope
{
    /// <summary>
    /// 執行時間測量範圍(自動使用 Stopwatch 計時並寫 Log)
    /// </summary>
    public class TimeMeasureScope : IDisposable
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private readonly Action<long, string> _action = null;
        private readonly string _title;

        /// <summary>
        /// 如果設為 true 就停止所有測量工作
        /// </summary>
        public static bool Disabled = false;

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="title">範圍標題</param>
        public TimeMeasureScope(Action<long, string> action, string title)
        {
            if (Disabled)
            {
                return;
            }
            _title = title;
            _action = action;
            _stopwatch.Start();//開始計時
        }

        public void Dispose()
        {
            if (Disabled)
            {
                return;
            }
            _stopwatch.Stop();//停止計時
            if (_action != null)
            {
                _action.Invoke(_stopwatch.ElapsedMilliseconds, _title);
            }
        }
    }

    /// <summary>
    /// 離開 Scope 執行指定 Action
    /// </summary>
    public class ExitScopeAction : IDisposable
    {
        private readonly Action _action = null;
        private readonly string _title;

        /// <summary>
        /// 關閉功能
        /// </summary>
        public static bool Disabled = false;

        public ExitScopeAction(Action action, string title)
        {
            _action = action;
            _title = title;
        }

        public void Dispose()
        {
            if (Disabled)
            {
                return;
            }

            if (_action != null)
            {
                _action.Invoke();
            }
        }
    }
}
