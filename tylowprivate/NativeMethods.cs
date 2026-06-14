using System;
using System.Runtime.InteropServices;

namespace tylowprivate
{
	internal static class NativeMethods
	{
		[DllImport("user32.dll")]
		public static extern bool GetCursorInfo(out CURSORINFO pci);

		[DllImport("user32.dll")]
		public static extern bool SetCursorPos(int x, int y);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr PostMessageW(IntPtr hWnd, uint Msg, UIntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr FindWindowW(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		public static extern short GetAsyncKeyState(int vKey);

		[DllImport("kernel32.dll")]
		public static extern void Sleep(uint dwMilliseconds);

		[DllImport("user32.dll")]
		public static extern bool IsWindowVisible(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		[DllImport("ntdll.dll")]
		public static extern uint NtDelayExecution(bool Alertable, out long DelayInterval);

		[DllImport("winmm.dll")]
		public static extern uint timeBeginPeriod(uint uPeriod);

		[DllImport("winmm.dll")]
		public static extern uint timeEndPeriod(uint uPeriod);

		[DllImport("ntdll.dll")]
		public static extern uint NtQueryTimerResolution(out uint MaximumTime, out uint MinimumTime, out uint CurrentTime);

		[DllImport("ntdll.dll")]
		public static extern uint NtSetTimerResolution(uint RequestedTime, bool Set, out uint ActualTime);

		[DllImport("dwmapi.dll")]
		public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attribute, ref int pvAttribute, int cbAttribute);

		public const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
		public const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
		public const int DWMWA_CAPTION_COLOR = 35;
		public const int DWMWA_TEXT_COLOR = 36;

		[StructLayout(LayoutKind.Sequential)]
		public struct CURSORINFO
		{
			public uint cbSize;
			public int flags;
			public IntPtr hCursor;
			public Point ptScreenPos;
		}
	}
}
