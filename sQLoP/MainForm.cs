using System;
using System.Windows.Forms;
using sQLoP.Core;

namespace sQLoP
{
    public partial class MainForm : Form
    {
        private readonly ILogConverter _converter;
        private readonly ILogReader _reader;
        private bool _stop;

        public MainForm(ILogReader reader, ILogConverter converter)
        {
            _reader = reader;
            _converter = converter;
            InitializeComponent();
            _reader.LogFile = textBox1.Text;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            var line = _reader.ReadNextLineFromLog();
            var access = _converter.ParseLogRecord(line);

            richTextBox1.Text += access + "\n";
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            _stop = false;

            while (!_stop)
            {
                var line = _reader.ReadNextLineFromLogAsync();
                await line;

                Application.DoEvents();

                if (line.Result == null)
                    return;

                var access = _converter.ParseLogRecord(line.Result);

                richTextBox1.Text += access + "\n";
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _stop = true;
        }
    }
}