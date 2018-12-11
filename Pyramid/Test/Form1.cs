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


namespace Pyramid
{
    public partial class Form1 : Form
    {
        string fichierScores = @"..\Scores.txt";
        string pathCartes = @"..\Cartes.txt";
        Random rd = new Random();        
        List<Image> Cartes = CarteGenerator.getToutesCartes(0.5);
<<<<<<< HEAD
        int ClickScore = 0;
=======
        List<Image> CartesCheckList = CarteGenerator.getToutesCartes(0.5);
        int nbClickNextCard = 0;       
>>>>>>> d4caf44d4896d585f9d5f8a8d78f11f092bb0249

        public Form1()
        {
            InitializeComponent();
<<<<<<< HEAD

=======
>>>>>>> d4caf44d4896d585f9d5f8a8d78f11f092bb0249
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void MyPaint()
<<<<<<< HEAD
        {

=======
        {            
>>>>>>> d4caf44d4896d585f9d5f8a8d78f11f092bb0249
            PictureBox[] boxesCarte =
            {
                imgCarte1, imgCarte2, imgCarte3, imgCarte4, imgCarte5, imgCarte6, imgCarte7, imgCarte8, imgCarte9, imgCarte10, imgCarte11,
                imgCarte12, imgCarte13, imgCarte14, imgCarte15, imgCarte16, imgCarte17, imgCarte18, imgCarte19, imgCarte20, imgCarte21,
                imgCarte22, imgCarte23, imgCarte24, imgCarte25, imgCarte26, imgCarte27, imgCarte28
            };

            for (int i = 0; i <= boxesCarte.Count()-1; i++)
            {
                int random = rd.Next(0, Cartes.Count());
                boxesCarte[i].Image = Cartes.ElementAt(random);
                Cartes.RemoveAt(random);
            }

            imgNouvelleCarte.Image = CarteGenerator.getDos(0.5);
<<<<<<< HEAD

=======
            Shuffle(Cartes);
>>>>>>> d4caf44d4896d585f9d5f8a8d78f11f092bb0249
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
<<<<<<< HEAD
            if (ClickScore == 0)
=======

            using (var reader = new StreamReader(fichierScores))
>>>>>>> d4caf44d4896d585f9d5f8a8d78f11f092bb0249
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
            else
            {
                lstScores.Visible = true;
                cmdAfficherScores.Visible = false;
                cmdCacherScores.Visible = true;
            }



        }

        private void cmdCacherScores_Click(object sender, EventArgs e)
        {
            lstScores.Visible = false;
            cmdAfficherScores.Visible = true;
            cmdCacherScores.Visible = false;
            ClickScore = 1;
        }

        private void Shuffle<T>(List<T> list)
        {
            for (int i = 0; i < 100; i++)
            {
                int index1 = rd.Next(0, list.Count - 1);
                int index2 = rd.Next(0, list.Count - 1);
                T o = list[index1];
                list[index1] = list[index2];
                list[index2] = o;
            }
        }

        private void cmdNextCarte_Click(object sender, EventArgs e)
        {
            int random2 = rd.Next(0, Cartes.Count);
            var randomList = Cartes.OrderBy(x => rd.Next()).ToList();
            nbClickNextCard++;

<<<<<<< HEAD
            if (Cartes.Count() > 1)
=======
            if (nbClickNextCard == 1)
>>>>>>> d4caf44d4896d585f9d5f8a8d78f11f092bb0249
            {
                imgNouvelleCarte.Image = Cartes.ElementAt(0);
                Cartes.RemoveAt(0);
            }
            else
            {
<<<<<<< HEAD
                cmdSecondPlate.Visible = true;
=======
                if (Cartes.Count() > 0)
                {
                    imgLastCarte.Image = imgNouvelleCarte.Image;
                    imgNouvelleCarte.Image = Cartes.ElementAt(0);
                    Cartes.RemoveAt(0);
                }
                else
                {
                    imgLastCarte.Image = imgNouvelleCarte.Image;
                    cmdSecondPlate.Visible = true;
                    imgNouvelleCarte.Visible = false;
                }
            }          
        }

        private void imgLastCarte_Click(object sender, EventArgs e)
        {
            int count = 1;
            foreach (Image c in CartesCheckList)
            {
                if (imgLastCarte.Image.Equals(c))
                {
                    MessageBox.Show(count.ToString());
                    count = 0;
                    break;
                }
                else
                {
                    if(count == 13)
                    {
                        count = 1;
                    }
                    else
                    {
                        count++;
                    }                    
                }
            }            
        }

        private void cmdNouvellePartie_Click(object sender, EventArgs e)
        {
            //MyPaint();
        }

        private void imgNouvelleCarte_Click(object sender, EventArgs e)
        {
>>>>>>> d4caf44d4896d585f9d5f8a8d78f11f092bb0249

            }
        }
    }
}
