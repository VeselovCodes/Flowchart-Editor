using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowchartEditorMVP.View
{
    public partial class NewFlowchartView : Form
    {
        public NewFlowchartView()
        {
            InitializeComponent();
            langComboBox.SelectedIndex = 0;
            openFileDialog1.FileName = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(*.cpp)|*.cpp|(*.pas)|*.pas";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo file = new FileInfo(openFileDialog1.FileName);
                filePathLabel.Text = openFileDialog1.FileName;
            }
        }

        int Check(string fcName, string fileName, int lang)
        {
            if (fcName == "")
            {
                return 1;
            }
            else
                if (fileName == "")
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int errID = Check(nameTextBox.Text, openFileDialog1.FileName, langComboBox.SelectedIndex); ;
            if (errID == 1)
            {
                errorLabel.Text = "Некорректное имя блок-схемы";
                errorLabel.Visible = true;
            }
            else
                if (errID == 2)
                {
                    errorLabel.Text = "Не выбран файл с кодом";
                    errorLabel.Visible = true;
                }
            if (errID == 0)
            {
                errorLabel.Visible = false;
                Model.CppCode code = new Model.CppCode();
                code.ToFlowchart(openFileDialog1.FileName);

                openFileDialog1.FileName = "";
                filePathLabel.Text = "...";
                nameTextBox.Text = "";
            }

        }
    }
}
