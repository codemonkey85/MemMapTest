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
namespace MemMapTestB
{
    public partial class frmMemMapTestB : Form
    {
        public frmMemMapTestB()
        {
            InitializeComponent();
        }
        private void frmMemMapTestA_Load(object sender, EventArgs e)
        {

        }
        private void btnReceive_Click(object sender, EventArgs e)
        {
            MemoryMappedFile MemoryMapped = MemoryMappedFile.CreateOrOpen("name", 1000, MemoryMappedFileAccess.ReadWrite);
            using (MemoryMappedViewAccessor FileMap = MemoryMapped.CreateViewAccessor())
            {
                Container NewContainer = new Container();
                int num = 0;
                FileMap.Read<int>(0, out num);
                lblData.Text = num.ToString();
            }
        }
    }
}
