using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Siticone.Desktop.UI.WinForms;

namespace tylowprivate
{
	public partial class Form1 : Form
	{
		// Fields
		private bool hToggleClickerThread;
		private bool hHideShowWindowThread;
		private bool hDestructThread;
		private bool hClickerThread;
		private bool hTimerResolution;
		private uint MaximumTime;
		private uint MinimumTime;
		private uint CurrentTime;
		private uint DefaultTime;
		private long delay;

		// Constructor
		public Form1()
		{
			this.InitializeComponent();
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			ApplyDarkTitleBar();
		}

		private void ApplyDarkTitleBar()
		{
			if (!OperatingSystem.IsWindowsVersionAtLeast(10))
			{
				return;
			}

			int useDarkMode = 1;
			if (NativeMethods.DwmSetWindowAttribute(Handle, NativeMethods.DWMWA_USE_IMMERSIVE_DARK_MODE, ref useDarkMode, sizeof(int)) != 0)
			{
				NativeMethods.DwmSetWindowAttribute(Handle, NativeMethods.DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1, ref useDarkMode, sizeof(int));
			}

			if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 22000))
			{
				int captionColor = 0x000F0F0F;
				int textColor = 0x00FFFFFF;
				NativeMethods.DwmSetWindowAttribute(Handle, NativeMethods.DWMWA_CAPTION_COLOR, ref captionColor, sizeof(int));
				NativeMethods.DwmSetWindowAttribute(Handle, NativeMethods.DWMWA_TEXT_COLOR, ref textColor, sizeof(int));
			}
		}

		// Event Handlers
		private void bunifuHScrollBar1_ValueChanged(object sender, BunifuHScrollBar.ValueChangedEventArgs e)
		{
			this.bunifuButton25.Text = (Convert.ToDouble(this.bunifuHScrollBar1.Value) / 100.0).ToString("0.0");
		}

		private void bunifuHScrollBar2_ValueChanged(object sender, BunifuHScrollBar.ValueChangedEventArgs e)
		{
			this.bunifuButton26.Text = (Convert.ToDouble(this.bunifuHScrollBar2.Value) / 100.0).ToString("0.00");
		}

		private void bunifuHScrollBar3_ValueChanged(object sender, BunifuHScrollBar.ValueChangedEventArgs e)
		{
			this.bunifuButton27.Text = (Convert.ToDouble(this.bunifuHScrollBar3.Value) / 100.0).ToString("0.00");
		}

		private void bunifuButton22_Click(object sender, EventArgs e)
		{
			this.bunifuButton22.Text = "...";
			this.hToggleClickerThread = false;
		}

		private void bunifuButton22_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.bunifuButton22.ButtonText == "...")
			{
				this.bunifuButton22.ButtonText = ((e.KeyCode == Keys.Escape) ? (this.bunifuButton22.ButtonText = "none") : (this.bunifuButton22.ButtonText = e.KeyCode.ToString()));
			}
			if (this.bunifuButton22.ButtonText != "none" && this.bunifuButton22.ButtonText != "...")
			{
				Keys vKey = (Keys)new KeysConverter().ConvertFromString(this.bunifuButton22.ButtonText);
				if (NativeMethods.GetAsyncKeyState((int)vKey) != 0)
				{
					while (NativeMethods.GetAsyncKeyState((int)vKey) != 0)
					{
						NativeMethods.Sleep(1U);
					}
					this.hToggleClickerThread = true;
					Task.Run(delegate()
					{
						this.ToggleClickerThread();
					});
					return;
				}
				Thread.Sleep(1);
			}
		}

		private void bunifuButton23_Click(object sender, EventArgs e)
		{
			this.bunifuButton23.Text = "...";
			this.hHideShowWindowThread = false;
		}

		private void bunifuButton23_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.bunifuButton23.ButtonText == "...")
			{
				this.bunifuButton23.ButtonText = ((e.KeyCode == Keys.Escape) ? (this.bunifuButton23.ButtonText = "none") : (this.bunifuButton23.ButtonText = e.KeyCode.ToString()));
			}
			if (this.bunifuButton23.ButtonText != "none" && this.bunifuButton23.ButtonText != "...")
			{
				Keys vKey = (Keys)new KeysConverter().ConvertFromString(this.bunifuButton23.ButtonText);
				if (NativeMethods.GetAsyncKeyState((int)vKey) != 0)
				{
					while (NativeMethods.GetAsyncKeyState((int)vKey) != 0)
					{
						NativeMethods.Sleep(1U);
					}
					this.hHideShowWindowThread = true;
					Task.Run(delegate()
					{
						this.HideShowWindowThread();
					});
					return;
				}
				Thread.Sleep(1);
			}
		}

		private void bunifuButton24_Click(object sender, EventArgs e)
		{
			this.bunifuButton24.Text = "...";
			this.hDestructThread = false;
		}

		private void bunifuButton24_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.bunifuButton24.ButtonText == "...")
			{
				this.bunifuButton24.ButtonText = ((e.KeyCode == Keys.Escape) ? (this.bunifuButton24.ButtonText = "none") : (this.bunifuButton24.ButtonText = e.KeyCode.ToString()));
			}
			if (this.bunifuButton24.ButtonText != "none" && this.bunifuButton24.ButtonText != "...")
			{
				Keys vKey = (Keys)new KeysConverter().ConvertFromString(this.bunifuButton24.ButtonText);
				if (NativeMethods.GetAsyncKeyState((int)vKey) != 0)
				{
					while (NativeMethods.GetAsyncKeyState((int)vKey) != 0)
					{
						NativeMethods.Sleep(1U);
					}
					this.hDestructThread = true;
					Task.Run(delegate()
					{
						this.DestructThread();
					});
					return;
				}
				Thread.Sleep(1);
			}
		}

		private void siticoneCheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.siticoneCheckBox1.Checked)
			{
				this.bunifuHScrollBar1.Minimum = 1200;
				this.bunifuHScrollBar1.Maximum = 10000;
				this.bunifuHScrollBar1.Value = 1200;
				return;
			}
			this.bunifuHScrollBar1.Minimum = 1200;
			this.bunifuHScrollBar1.Maximum = 2000;
			this.bunifuHScrollBar1.Value = 1200;
		}

		private void bunifuButton21_Click(object sender, EventArgs e)
		{
			this.bunifuButton21.Text = ((this.bunifuButton21.Text == "enable") ? "disable" : "enable");
			string text = this.bunifuButton21.Text;
			if (text == "enable")
			{
				this.hClickerThread = true;
				Task.Run(delegate()
				{
					this.ClickerThread();
				});
				return;
			}
			if (!(text == "disable"))
			{
				return;
			}
			this.hClickerThread = false;
		}

		private void siticoneCheckBox5_CheckedChanged(object sender, EventArgs e)
		{
			if (this.siticoneCheckBox5.Checked)
			{
				this.hTimerResolution = true;
				Task.Run(delegate()
				{
					this.TimerResolution();
				});
				return;
			}
			this.hTimerResolution = false;
		}

		private void siticoneCheckBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (this.siticoneCheckBox4.Checked)
			{
				this.siticoneCheckBox4.Checked = false;
			}
		}

		private void siticoneCheckBox4_CheckedChanged(object sender, EventArgs e)
		{
			if (this.siticoneCheckBox2.Checked)
			{
				this.siticoneCheckBox2.Checked = false;
			}
		}

		// Public Methods
		public bool IsCursorVisible()
		{
			NativeMethods.CURSORINFO cursorinfo;
			cursorinfo.cbSize = (uint)Marshal.SizeOf(typeof(NativeMethods.CURSORINFO));
			NativeMethods.GetCursorInfo(out cursorinfo);
			return (int)cursorinfo.hCursor <= 131071;
		}

		public void Jitter(int force)
		{
			Random random = new Random();
			NativeMethods.SetCursorPos(Cursor.Position.X - random.Next(-force, force), Cursor.Position.Y - random.Next(-force, force));
		}

		public int Randomization(int force, double CPS)
		{
			Random random = new Random();
			double num = 0.0;
			double num2 = 0.0;
			if (force == 1)
			{
				num = 0.1 * CPS;
				num2 = 0.1 * CPS;
			}
			else if (force == 2)
			{
				num = 0.2 * CPS;
				num2 = 0.2 * CPS;
			}
			else if (force == 3)
			{
				num = 0.3 * CPS;
				num2 = 0.3 * CPS;
			}
			else if (force == 4)
			{
				num = 0.4 * CPS;
				num2 = 0.4 * CPS;
			}
			else if (force == 5)
			{
				num = 0.5 * CPS;
				num2 = 0.5 * CPS;
			}
			int num3 = random.Next((int)(CPS - num), (int)(CPS + num2));
			return 1050 / num3 * 10000;
		}

		public void LeftClickDown()
		{
			NativeMethods.PostMessageW(NativeMethods.FindWindowW("LWJGL", null), 513U, 0U, 0);
		}

		public void LeftClickUp()
		{
			NativeMethods.PostMessageW(NativeMethods.FindWindowW("LWJGL", null), 514U, 0U, 0);
		}

		public void RightClickDown()
		{
			NativeMethods.PostMessageW(NativeMethods.FindWindowW("LWJGL", null), 516U, 0U, 0);
		}

		public void RightClickUp()
		{
			NativeMethods.PostMessageW(NativeMethods.FindWindowW("LWJGL", null), 517U, 0U, 0);
		}

		private void PreciseSleep(long nanoseconds)
		{
			long num = -1L * nanoseconds;
			NativeMethods.NtDelayExecution(false, out num);
		}

		public void ToggleClickerThread()
		{
			while (this.hToggleClickerThread)
			{
				if (this.bunifuButton22.ButtonText != "none" && this.bunifuButton22.ButtonText != "...")
				{
					Keys vKey = (Keys)new KeysConverter().ConvertFromString(this.bunifuButton22.ButtonText);
					if (NativeMethods.GetAsyncKeyState((int)vKey) != 0)
					{
						while (NativeMethods.GetAsyncKeyState((int)vKey) != 0)
						{
							NativeMethods.Sleep(1U);
						}
						base.Invoke(new MethodInvoker(delegate()
						{
							this.bunifuButton21.Text = ((this.bunifuButton21.Text == "enable") ? "disable" : "enable");
							string text = this.bunifuButton21.Text;
							if (text == "enable")
							{
								this.hClickerThread = true;
								Task.Run(delegate()
								{
									this.ClickerThread();
								});
								return;
							}
							if (!(text == "disable"))
							{
								return;
							}
							this.hClickerThread = false;
						}));
					}
					else
					{
						Thread.Sleep(1);
					}
				}
			}
		}

		public void HideShowWindowThread()
		{
			while (this.hHideShowWindowThread)
			{
				if (this.bunifuButton23.ButtonText != "none" && this.bunifuButton23.ButtonText != "...")
				{
					Keys vKey = (Keys)new KeysConverter().ConvertFromString(this.bunifuButton23.ButtonText);
					if (NativeMethods.GetAsyncKeyState((int)vKey) != 0)
					{
						while (NativeMethods.GetAsyncKeyState((int)vKey) != 0)
						{
							NativeMethods.Sleep(1U);
						}
						if (NativeMethods.IsWindowVisible(base.Handle))
						{
							NativeMethods.ShowWindow(base.Handle, 0);
						}
						else
						{
							NativeMethods.ShowWindow(base.Handle, 5);
						}
					}
					else
					{
						Thread.Sleep(1);
					}
				}
			}
		}

		public void DestructThread()
		{
			while (this.hDestructThread)
			{
				if (this.bunifuButton24.ButtonText != "none" && this.bunifuButton24.ButtonText != "...")
				{
					Keys vKey = (Keys)new KeysConverter().ConvertFromString(this.bunifuButton24.ButtonText);
					if (NativeMethods.GetAsyncKeyState((int)vKey) != 0)
					{
						while (NativeMethods.GetAsyncKeyState((int)vKey) != 0)
						{
							NativeMethods.Sleep(1U);
						}
						base.Invoke(new MethodInvoker(delegate()
						{
							for (int i = base.Controls.Count - 1; i >= 0; i--)
							{
								Control value = base.Controls[i];
								base.Controls.Remove(value);
							}
							Label label = new Label();
							label.AutoSize = true;
							label.Font = new Font("Calibri", 16.25f, FontStyle.Bold);
							label.ForeColor = Color.SlateBlue;
							label.Location = new Point(220, 118);
							label.Name = "label1";
							label.Size = new Size(129, 26);
							label.TabIndex = 0;
							label.Text = "Destructing...";
							base.Controls.Add(label);
						}));
						Thread.Sleep(5000);
						Environment.Exit(0);
					}
					else
					{
						Thread.Sleep(1);
					}
				}
			}
		}

		public void ClickerThread()
		{
			while (this.hClickerThread)
			{
				NativeMethods.timeBeginPeriod(1U);
				if (NativeMethods.GetForegroundWindow() == NativeMethods.FindWindowW("LWJGL", null))
				{
					if (NativeMethods.GetAsyncKeyState(1) != 0)
					{
						if (this.bunifuButton21.Text == "enable")
						{
							if (this.siticoneCheckBox2.Checked)
							{
								if (this.siticoneCheckBox6.Checked)
								{
									if (!this.IsCursorVisible())
									{
										if (this.siticoneCheckBox3.Checked)
										{
											this.Jitter(this.bunifuHScrollBar3.Value / 100);
										}
										if (this.siticoneCheckBox7.Checked)
										{
											this.delay = (long)this.Randomization(this.bunifuHScrollBar2.Value / 100, (double)this.bunifuHScrollBar1.Value / 100.0);
										}
										else
										{
											this.delay = (long)(1050.0 / ((double)this.bunifuHScrollBar1.Value / 100.0) * 10000.0);
										}
										this.LeftClickDown();
										this.PreciseSleep(this.delay);
										this.LeftClickUp();
									}
									else if (this.IsCursorVisible() && NativeMethods.GetAsyncKeyState(160) != 0)
									{
										this.RightClickDown();
										this.RightClickUp();
										this.PreciseSleep(525000L);
									}
								}
								else
								{
									if (this.siticoneCheckBox3.Checked)
									{
										this.Jitter(this.bunifuHScrollBar3.Value / 100);
									}
									if (this.siticoneCheckBox7.Checked)
									{
										this.delay = (long)this.Randomization(this.bunifuHScrollBar2.Value / 100, (double)this.bunifuHScrollBar1.Value / 100.0);
									}
									else
									{
										this.delay = (long)(1050.0 / ((double)this.bunifuHScrollBar1.Value / 100.0) * 10000.0);
									}
									this.LeftClickDown();
									this.PreciseSleep(this.delay);
									this.LeftClickUp();
								}
							}
							else if (this.siticoneCheckBox4.Checked)
							{
								if (this.siticoneCheckBox6.Checked)
								{
									if (!this.IsCursorVisible())
									{
										if (this.siticoneCheckBox3.Checked)
										{
											this.Jitter(this.bunifuHScrollBar3.Value / 100);
										}
										if (this.siticoneCheckBox7.Checked)
										{
											this.delay = (long)this.Randomization(this.bunifuHScrollBar2.Value / 100, (double)this.bunifuHScrollBar1.Value / 100.0);
										}
										else
										{
											this.delay = (long)(1050.0 / ((double)this.bunifuHScrollBar1.Value / 100.0) * 10000.0);
										}
										this.LeftClickDown();
										this.LeftClickUp();
										this.PreciseSleep(this.delay);
									}
									else if (this.IsCursorVisible() && NativeMethods.GetAsyncKeyState(160) != 0)
									{
										this.RightClickDown();
										this.RightClickUp();
										this.PreciseSleep(525000L);
									}
								}
								else
								{
									if (this.siticoneCheckBox3.Checked)
									{
										this.Jitter(this.bunifuHScrollBar3.Value / 100);
									}
									if (this.siticoneCheckBox7.Checked)
									{
										this.delay = (long)this.Randomization(this.bunifuHScrollBar2.Value / 100, (double)this.bunifuHScrollBar1.Value / 100.0);
									}
									else
									{
										this.delay = (long)(1050.0 / ((double)this.bunifuHScrollBar1.Value / 100.0) * 10000.0);
									}
									this.LeftClickDown();
									this.LeftClickUp();
									this.PreciseSleep(this.delay);
								}
							}
							else if (this.siticoneCheckBox6.Checked)
							{
								if (!this.IsCursorVisible())
								{
									if (this.siticoneCheckBox3.Checked)
									{
										this.Jitter(this.bunifuHScrollBar3.Value / 100);
									}
									if (this.siticoneCheckBox7.Checked)
									{
										this.delay = (long)this.Randomization(this.bunifuHScrollBar2.Value / 100, (double)this.bunifuHScrollBar1.Value / 100.0);
									}
									else
									{
										this.delay = (long)(1050.0 / ((double)this.bunifuHScrollBar1.Value / 100.0) * 10000.0);
									}
									this.PreciseSleep(this.delay);
									this.LeftClickDown();
									this.LeftClickUp();
								}
								else if (this.IsCursorVisible() && NativeMethods.GetAsyncKeyState(160) != 0)
								{
									this.RightClickDown();
									this.RightClickUp();
									this.PreciseSleep(525000L);
								}
							}
							else
							{
								if (this.siticoneCheckBox3.Checked)
								{
									this.Jitter(this.bunifuHScrollBar3.Value / 100);
								}
								if (this.siticoneCheckBox7.Checked)
								{
									this.delay = (long)this.Randomization(this.bunifuHScrollBar2.Value / 100, (double)this.bunifuHScrollBar1.Value / 100.0);
								}
								else
								{
									this.delay = (long)(1050.0 / ((double)this.bunifuHScrollBar1.Value / 100.0) * 10000.0);
								}
								this.PreciseSleep(this.delay);
								this.LeftClickDown();
								this.LeftClickUp();
							}
						}
						else
						{
							Thread.Sleep(1);
						}
					}
					else
					{
						Thread.Sleep(1);
					}
				}
				else
				{
					Thread.Sleep(1);
				}
				NativeMethods.timeEndPeriod(1U);
			}
		}

		public void TimerResolution()
		{
			NativeMethods.NtQueryTimerResolution(out this.MaximumTime, out this.MinimumTime, out this.DefaultTime);
			while (this.hTimerResolution)
			{
				NativeMethods.NtQueryTimerResolution(out this.MaximumTime, out this.MinimumTime, out this.CurrentTime);
				if (this.CurrentTime == this.DefaultTime)
				{
					NativeMethods.NtSetTimerResolution(this.MinimumTime, true, out this.CurrentTime);
				}
				else if (this.CurrentTime == this.MaximumTime)
				{
					NativeMethods.NtSetTimerResolution(this.MinimumTime, true, out this.CurrentTime);
				}
				else
				{
					Thread.Sleep(1);
				}
			}
			NativeMethods.NtQueryTimerResolution(out this.MaximumTime, out this.MinimumTime, out this.CurrentTime);
			if (this.CurrentTime == this.MinimumTime)
			{
				NativeMethods.NtSetTimerResolution(this.DefaultTime, true, out this.CurrentTime);
			}
		}
	}
}

// bro what a shit XDD - im going to make it more portable without those paid libraries (they look shitty & laggy)
// reversed, orderded & fixed by @ky.aa :3