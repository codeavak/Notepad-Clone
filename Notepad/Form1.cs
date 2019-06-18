using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public string FileName { get; set; }

        public Form1()
        {
           
            InitializeComponent();
            this.Text = "Untitled";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileName = null;
            richTextBox.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (fileDialog.ShowDialog()== DialogResult.OK)
            {
                richTextBox.LoadFile(fileDialog.FileName, RichTextBoxStreamType.PlainText);
                FileName = fileDialog.FileName;
                this.Text = FileName;
                
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (this.Text != "Untitled")
            {
                richTextBox.SaveFile(this.Text, RichTextBoxStreamType.PlainText);
            }else
                if(saveDialog.ShowDialog()==DialogResult.OK)
            { richTextBox.SaveFile(saveDialog.FileName, RichTextBoxStreamType.PlainText);
                this.Text = saveDialog.FileName;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SaveFile(saveDialog.FileName, RichTextBoxStreamType.PlainText);
                this.Text = saveDialog.FileName;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                richTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                richTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Redo();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = richTextBox.Font;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.Font = fontDialog.Font;
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = richTextBox.BackColor;
            if(cd.ShowDialog()==DialogResult.OK)
            { richTextBox.BackColor = cd.Color; }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Help will be displayed here!");
        }
    }
}
