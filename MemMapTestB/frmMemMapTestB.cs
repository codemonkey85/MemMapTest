using System;
using System.Windows.Forms;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using PKMDS_CS;
namespace MemMapTestB
{
    public partial class frmMemMapTestB : Form
    {
        PKMDS.Pokemon frmpkm = new PKMDS.Pokemon();
        public frmMemMapTestB()
        {
            try
            {
                PKMDS.SQL.OpenDB("veekun-pokedex.sqlite");
            }
            catch (Exception ex)
            {

            }
            InitializeComponent();
        }
        private void frmMemMapTestB_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                PKMDS.SQL.CloseDB();
            }
            catch (Exception ex)
            {

            }
        }
        private void frmMemMapTestA_Load(object sender, EventArgs e)
        {
            ((Control)(pbSprite)).AllowDrop = true;
            frmpkm = PKMDS.ReadPokemonFile("C:\\Users\\codem_000\\Desktop\\2760882E_Dragonite.pkm");
            Random rnd = new Random(DateTime.Now.Millisecond);
            frmpkm.SpeciesID = (UInt16)(rnd.Next(1, 649));
            lblData.Text = frmpkm.SpeciesName;
            pbSprite.Image = frmpkm.Sprite;
        }
        private void pbSprite_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }
        private void pbSprite_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pb = (PictureBox)(sender);
            DataObject data = new DataObject();
            data = new DataObject(DataFormats.Serializable, frmpkm);
            pb.DoDragDrop(data, DragDropEffects.Move);
            MemoryMappedFile MemoryMapped = MemoryMappedFile.CreateOrOpen("name", 1000, MemoryMappedFileAccess.ReadWrite);
            using (MemoryMappedViewAccessor FileMap = MemoryMapped.CreateViewAccessor())
            {
                PKMDS.Pokemon otherpkm = new PKMDS.Pokemon();
                for (int i = 0; i < Marshal.SizeOf(otherpkm); i++)
                {
                    FileMap.Read<byte>(i, out otherpkm.Data[i]);
                }
                frmpkm.Data = otherpkm.Data;
                lblData.Text = frmpkm.SpeciesName;
                pbSprite.Image = frmpkm.Sprite;
            }
        }
        private void pbSprite_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                PictureBox pb = (PictureBox)(sender);
                PKMDS.Pokemon otherpkm = (PKMDS.Pokemon)e.Data.GetData(DataFormats.Serializable);
                MemoryMappedFile MemoryMapped = MemoryMappedFile.CreateOrOpen("name", 1000, MemoryMappedFileAccess.ReadWrite);
                using (MemoryMappedViewAccessor FileMap = MemoryMapped.CreateViewAccessor())
                {
                    for (int i = 0; i < Marshal.SizeOf(frmpkm); i++)
                    {
                        FileMap.Write<byte>(i, ref frmpkm.Data[i]);
                    }
                }
                frmpkm.Data = otherpkm.Data;
                lblData.Text = frmpkm.SpeciesName;
                pbSprite.Image = frmpkm.Sprite;
            }
        }
    }
}
