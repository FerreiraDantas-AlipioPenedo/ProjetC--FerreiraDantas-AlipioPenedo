using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GameCardGenerator;

namespace Pyramid
{
    public partial class Form1 : Form
    {
        string fichierScores = @"..\Scores.txt";
        Random rd = new Random();
        int random2 = 0;
        List<Image> Cartes = CarteGenerator.getToutesCartes(0.5);

        public Form1()
        {
            InitializeComponent();
            
        }  

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void MyPaint()
        {    

            PictureBox[] boxesCarte =
            {
                imgCarte1, imgCarte2, imgCarte3, imgCarte4, imgCarte5, imgCarte6, imgCarte7, imgCarte8, imgCarte9, imgCarte10, imgCarte11, imgCarte12, imgCarte13, imgCarte14,
                imgCarte15, imgCarte16, imgCarte17, imgCarte18, imgCarte19, imgCarte20, imgCarte21, imgCarte22, imgCarte23, imgCarte24, imgCarte25, imgCarte26, imgCarte27, imgCarte28
            };

            for (int i = 0; i <= 27; i++)
            {
                int random = rd.Next(0, Cartes.Count());
                boxesCarte[i].Image = Cartes.ElementAt(random);
                Cartes.RemoveAt(random);
            }

            imgNouvelleCarte = CarteGenerator.getDos(0.5);          

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyPaint();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cmdAfficherScores_Click(object sender, EventArgs e)
        {
            
            using (var reader = new StreamReader(fichierScores))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    lstScores.Items.Add(line);
                }
            }

            lstScores.Visible = true;
            cmdAfficherScores.Visible = false;
            cmdCacherScores.Visible = true;
        }

        private void cmdCacherScores_Click(object sender, EventArgs e)
        {
            lstScores.Visible = false;
            cmdAfficherScores.Visible = true;
            cmdCacherScores.Visible = false;
        }

        private void cmdNextCarte_Click(object sender, EventArgs e)
        {
            random2 = rd.Next(0, Cartes.Count);
            imgNouvelleCarte.Image = Cartes.ElementAt(random2);

            if (Cartes.Count() != 0)
            {
                imgLastCarte.Image = imgNouvelleCarte.Image;
                Cartes.RemoveAt(random2);
                imgNouvelleCarte.Image = Cartes.ElementAt(rd.Next(0, Cartes.Count));
            }
            else
            {
                cmdSecondPlate.Visible = true;
            }
            

        }
    }
}
