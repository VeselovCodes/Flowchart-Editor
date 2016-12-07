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
    public partial class MasterView : Form , IView
    {
        public MasterView()
        {
            InitializeComponent();
        }

        private void MasterView_Load(object sender, EventArgs e)
        {

        }
        public void Open() { }
        public void Close() { }
    }
}
