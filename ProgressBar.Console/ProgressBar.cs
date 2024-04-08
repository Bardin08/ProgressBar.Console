using System;
using System.Diagnostics;
using System.Text;

namespace ProgressBar.Console
{
    public class ProgressBar
    {
        private readonly int _barWidth;
        private readonly string _prefix;
        private readonly char _arrowChar;
        private readonly char _fillerChar;
        private readonly long _totalTicks;
        private readonly ConsoleColor? _barColor;

        private readonly StringBuilder _bar;
        private readonly Stopwatch _stopwatch;

        private int _currentTick;
        private string _lastRender = string.Empty;

        public ProgressBar(long totalTicks, ProgressBarOptions barOptions)
        {
            if (barOptions is null)
            {
                barOptions = new ProgressBarOptions();
            }

            _totalTicks = totalTicks;
            _currentTick = 0;

            _barWidth = barOptions.Width;
            _prefix = barOptions.Prefix;
            _fillerChar = barOptions.Filler;
            _arrowChar = barOptions.Arrow;
            _barColor = barOptions.Color; 
            _bar = new StringBuilder(new string(' ', barOptions.Width));

            if (barOptions.DisplayElapsedTime)
            {
                _stopwatch = new Stopwatch();
                _stopwatch.Start();
            }
        }

        public void Update(int ticks)
        {
            _currentTick += ticks;
            var percentComplete = (double)_currentTick / _totalTicks;
            var ticksToShow = (int)(percentComplete * _barWidth);

            _bar.Clear();
            _bar.Append(new string(_fillerChar, ticksToShow));
            _bar.Append(_arrowChar);
            _bar.Append(new string(' ', _barWidth - ticksToShow));

            Render();
        }

        private void Render()
        {
            System.Console.CursorLeft = 0;

            var barState = GetProgressBarState();
            if (_barColor.HasValue)
            {
                System.Console.ForegroundColor = _barColor.Value;
                System.Console.Write(barState);
                System.Console.ResetColor();
            }
            else
            {
                System.Console.Write(barState);
            }


            if (_lastRender.Length > System.Console.CursorLeft)
            {
                System.Console.Write(new string(' ', _lastRender.Length - System.Console.CursorLeft));
            }

            _lastRender = System.Console.CursorLeft.ToString();
        }

        private string GetProgressBarState()
        {
            string barState;
            if (!(_stopwatch is null))
            {
                var elapsed = _stopwatch.Elapsed;
                var elapsedTime =
                    $"{elapsed.Hours:00}:{elapsed.Minutes:00}:{elapsed.Seconds:00}.{elapsed.Milliseconds / 10:00}";

                barState = $"{_prefix}[{_bar}] {_currentTick}/{_totalTicks} " +
                           $"({_currentTick * 100.0 / _totalTicks:0.00}%)" +
                           $" - Time: {elapsedTime}";
            }
            else
            {
                barState = $"{_prefix}[{_bar}] {_currentTick}/{_totalTicks} " +
                           $"({_currentTick * 100.0 / _totalTicks:0.00}%)";
            }

            return barState;
        }

        public void Finish()
        {
            _stopwatch.Stop();
            System.Console.WriteLine();
        }
    }
}