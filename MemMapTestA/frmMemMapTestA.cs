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
            frmpkm = PKMDS.ReadPokemonFile("Feraligatr.pkm");
            frmpkm2 = PKMDS.ReadPokemonFile("Genesect.pkm");
            Random rnd = new Random(DateTime.Now.Millisecond);
            frmpkm.SpeciesID = (UInt16)(rnd.Next(1, 649));
            frmpkm2.SpeciesID = (UInt16)(rnd.Next(1, 649));
            frmpkm.SID = 0x1234;
            frmpkm2.SID = 0x1234;
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
            MemoryMappedFile MemoryMapped = MemoryMappedFile.OpenExisting("name", MemoryMappedFileRights.FullControl);
            using (MemoryMappedViewAccessor FileMap = MemoryMapped.CreateViewAccessor())
            {
                PKMDS.Pokemon otherpkm = new PKMDS.Pokemon();
                FileMap.ReadArray<byte>(0, otherpkm.Data, 0, 136);
                if (otherpkm.SpeciesID == 0)
                {
                    FileMap.Dispose();
                    return;
                }
                UInt16 otherpkmcheck = BitConverter.ToUInt16(otherpkm.Data, 0x06);
                if (pb.Name == pbSprite.Name)
                {
                    UInt16 frmpkmcheck = BitConverter.ToUInt16(frmpkm.Data, 0x06);
                    if (frmpkmcheck == otherpkmcheck)
                    {
                        FileMap.Dispose();
                        return;
                    }
                    frmpkm.Data = otherpkm.Data;
                }
                else
                {
                    UInt16 frmpkmcheck = BitConverter.ToUInt16(frmpkm2.Data, 0x06);

                    if (frmpkmcheck == otherpkmcheck)
                    {
                        FileMap.Dispose();
                        return;
                    }
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
                    if (pb.Name == pbSprite.Name)
                    {
                        FileMap.WriteArray<byte>(0, frmpkm.Data, 0, 136);
                    }
                    else
                    {
                        FileMap.WriteArray<byte>(0, frmpkm2.Data, 0, 136);
                    }
                }
                UInt16 otherpkmcheck = BitConverter.ToUInt16(otherpkm.Data, 0x06);
                if (pb.Name == pbSprite.Name)
                {
                    UInt16 frmpkmcheck = BitConverter.ToUInt16(frmpkm.Data, 0x06);
                    if (frmpkmcheck == otherpkmcheck)
                    {
                        return;
                    }
                    frmpkm.Data = otherpkm.Data;
                }
                else
                {
                    UInt16 frmpkmcheck = BitConverter.ToUInt16(frmpkm2.Data, 0x06);
                    if (frmpkmcheck == otherpkmcheck)
                    {
                        return;
                    }
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
