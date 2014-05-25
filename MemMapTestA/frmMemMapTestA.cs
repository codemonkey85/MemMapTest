using System;
using System.Windows.Forms;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using PKMDS_CS;
namespace MemMapTestA
{
    public partial class frmMemMapTestA : Form
    {
        PKMDS.Pokemon frmpkm = new PKMDS.Pokemon();
        PKMDS.Pokemon frmpkm2 = new PKMDS.Pokemon();
        public frmMemMapTestA()
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
        private void frmMemMapTestA_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                PKMDS.SQL.CloseDB();
            }
            catch (Exception ex)
            {

            }
        }
        private void frmMemMapTestB_Load(object sender, EventArgs e)
        {
            ((Control)(pbSprite)).AllowDrop = true;
            ((Control)(pbSprite2)).AllowDrop = true;
            frmpkm = PKMDS.ReadPokemonFile("C:\\Users\\codem_000\\Desktop\\5CE4720E_Feraligatr.pkm");
            frmpkm2 = PKMDS.ReadPokemonFile("C:\\Users\\codem_000\\Desktop\\42FCBC7E_Suicune.pkm");
            Random rnd = new Random(DateTime.Now.Millisecond);
            frmpkm.SpeciesID = (UInt16)(rnd.Next(1, 649));
            frmpkm2.SpeciesID = (UInt16)(rnd.Next(1, 649));
            frmpkm2.SID = 0;
            lblData.Text = frmpkm.SpeciesName;
            lblData2.Text = frmpkm2.SpeciesName;
            pbSprite.Image = frmpkm.Sprite;
            pbSprite2.Image = frmpkm2.Sprite;
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
            if (pb.Name == pbSprite.Name)
            {
                data = new DataObject(DataFormats.Serializable, frmpkm);
            }
            else
            {
                data = new DataObject(DataFormats.Serializable, frmpkm2);
            }
            pb.DoDragDrop(data, DragDropEffects.Move);
            MemoryMappedFile MemoryMapped = MemoryMappedFile.CreateOrOpen("name", 1000, MemoryMappedFileAccess.ReadWrite);
            using (MemoryMappedViewAccessor FileMap = MemoryMapped.CreateViewAccessor())
            {
                PKMDS.Pokemon otherpkm = new PKMDS.Pokemon();
                for (int i = 0; i < Marshal.SizeOf(otherpkm); i++)
                {
                    FileMap.Read<byte>(i, out otherpkm.Data[i]);
                }
                if (pb.Name == pbSprite.Name)
                {
                    frmpkm.Data = otherpkm.Data;
                }
                else
                {
                    frmpkm2.Data = otherpkm.Data;
                }
                lblData.Text = frmpkm.SpeciesName;
                lblData2.Text = frmpkm2.SpeciesName;
                pbSprite.Image = frmpkm.Sprite;
                pbSprite2.Image = frmpkm2.Sprite;
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
                        if (pb.Name == pbSprite.Name)
                        {
                            FileMap.Write<byte>(i, ref frmpkm.Data[i]);
                        }
                        else
                        {
                            FileMap.Write<byte>(i, ref frmpkm2.Data[i]);
                        }
                    }
                }
                if (pb.Name == pbSprite.Name)
                {
                    frmpkm.Data = otherpkm.Data;
                }
                else
                {
                    frmpkm2.Data = otherpkm.Data;
                }
                lblData.Text = frmpkm.SpeciesName;
                lblData2.Text = frmpkm2.SpeciesName;
                pbSprite.Image = frmpkm.Sprite;
                pbSprite2.Image = frmpkm2.Sprite;
            }
        }
    }
}
