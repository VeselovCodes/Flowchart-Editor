using System;
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
    public partial class ChooseFlowchartView : Form , IView
    {
        public ChooseFlowchartView()
        {
            InitializeComponent();
        }

        private void ChooseFlowchartView_Load(object sender, EventArgs e)
        {

        }

        public void Open() { }
        public void Close() { }
    }
}
