using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.MemoryMappedFiles;
using System.IO;
namespace MemMapTestA
{
    public partial class frmMemMapTestA : Form
    {
        public frmMemMapTestA()
        {
            InitializeComponent();
        }
        private void frmMemMapTestB_Load(object sender, EventArgs e)
        {

        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            MemoryMappedFile MemoryMapped = MemoryMappedFile.CreateOrOpen("name", 1000, MemoryMappedFileAccess.ReadWrite);
            using (MemoryMappedViewAccessor FileMap = MemoryMapped.CreateViewAccessor())
            {
                Container NewContainer = new Container();
                int num = (int)(numData.Value);
                lblData.Text = num.ToString();
                FileMap.Write<int>(0, ref num);
            }
        }
    }
}
