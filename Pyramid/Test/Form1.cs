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
        List<Carte> Cartes = CarteGenerator.getToutesCartes(0.5);
        List<Carte> CartesCheckList = new List<Carte>();
        List<Image> UsedCarte = new List<Image>();
        int nbClickNextCard = 0;
        int i = 0;
        int tour = 3;
        int value1 = 0;
        int value2 = 0;
        int total = 0;
        PictureBox ptb = new PictureBox();

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
                imgCarte1, imgCarte2, imgCarte3, imgCarte4, imgCarte5, imgCarte6, imgCarte7, imgCarte8, imgCarte9, imgCarte10, imgCarte11,
                imgCarte12, imgCarte13, imgCarte14, imgCarte15, imgCarte16, imgCarte17, imgCarte18, imgCarte19, imgCarte20, imgCarte21,
                imgCarte22, imgCarte23, imgCarte24, imgCarte25, imgCarte26, imgCarte27, imgCarte28
            };

            for (int i = 0; i <= boxesCarte.Count()-1; i++)
            {
                Shuffle(Cartes);
                boxesCarte[i].Image = Cartes.ElementAt(0).GetImage();
                CartesCheckList.Add(Cartes.ElementAt(0));
                Cartes.RemoveAt(0);
            }


            imgNouvelleCarte.Image = CarteGenerator.getDos(0.5);
            Shuffle(Cartes);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyPaint();

            imgLastCarte.Click += ClickOnCard;
            imgNouvelleCarte.Click += ClickOnCard;
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

        private void Shuffle<T>(List<T> list)
        {
            for (int i = 0; i < 100; i++)
            {
                int index1 = rd.Next(0, list.Count );
                int index2 = rd.Next(0, list.Count );
                T o = list[index1];
                list[index1] = list[index2];
                list[index2] = o;
            }
        }

        private void cmdNextCarte_Click(object sender, EventArgs e)
        {         
            nbClickNextCard++;
            if (nbClickNextCard == 1)
                {
                imgNouvelleCarte.Image = Cartes.ElementAt(i).GetImage();
                imgNouvelleCarte.Visible = true;
                imgLastCarte.Visible = false;
                //MessageBox.Show(Cartes.ElementAt(i).GetCarteValeur().ToString());
                i++;
            }
            else
            {
                if (i <= 23 )
                {
                    UsedCarte.Add(imgLastCarte.Image);
                    imgLastCarte.Image = imgNouvelleCarte.Image;
                    imgNouvelleCarte.Image = Cartes.ElementAt(i).GetImage();
                    imgLastCarte.Visible = true;
                    
                    //MessageBox.Show(Cartes.ElementAt(i).GetCarteValeur().ToString());
                    i++;
                }
                else
                {
                    imgLastCarte.Image = imgNouvelleCarte.Image;               
                    cmdSecondPlate.Visible = true;
                    imgNouvelleCarte.Visible = false;
                    UsedCarte.Add(imgLastCarte.Image);
                    i = 0;
                    nbClickNextCard = 0;
                    tour--;
                }              
            }         
        }

        private void imgLastCarte_Click(object sender, EventArgs e)
        {
            value1 = Cartes.ElementAt(i - 2).GetCarteValeur();
            if(value1 == 13)
            {
                imgLastCarte.Image = UsedCarte.Last();
                Cartes.RemoveAt(i - 2);
            }
            //MessageBox.Show(Cartes.ElementAt(i-2).GetCarteValeur().ToString());    
        }
        private void imgNouvelleCarte_Click(object sender, EventArgs e)
        {
            value1 = Cartes.ElementAt(i - 1).GetCarteValeur();
            if (value1 == 13)
            {
                imgNouvelleCarte.Image = Cartes.ElementAt(i).GetImage();
                Cartes.RemoveAt(i - 1);
            }            
        }
        private void cmdNouvellePartie_Click(object sender, EventArgs e)
        {
            //MyPaint();
        }
        public void ClickOnCard(object sender, EventArgs e)
        {
             ptb = sender as PictureBox;
        }
        public void ClickSurPlateau(int nbCarte)
        {
            int NbClickOnPlateau = 0;
            total = value1 + CartesCheckList.ElementAt(nbCarte).GetCarteValeur();

            PictureBox[] boxesCarte =
            {
                imgCarte1, imgCarte2, imgCarte3, imgCarte4, imgCarte5, imgCarte6, imgCarte7, imgCarte8, imgCarte9, imgCarte10, imgCarte11,
                imgCarte12, imgCarte13, imgCarte14, imgCarte15, imgCarte16, imgCarte17, imgCarte18, imgCarte19, imgCarte20, imgCarte21,
                imgCarte22, imgCarte23, imgCarte24, imgCarte25, imgCarte26, imgCarte27, imgCarte28
            };

            if (total == 13)
            {
                boxesCarte.ElementAt(nbCarte).Visible = false;               
                value1 = 0;
                if(ptb.Name == "imgLastCarte")
                {
                    imgLastCarte.Image = UsedCarte.Last();
                    Cartes.RemoveAt(i - 2);
                }

                if(ptb.Name == "imgNouvelleCarte")
                {
                    imgNouvelleCarte.Image = Cartes.ElementAt(i).GetImage();
                    Cartes.RemoveAt(i);
                }
            }

            NbClickOnPlateau++;
            //MessageBox.Show(CartesCheckList.ElementAt(nbCarte).GetCarteValeur().ToString());
             
        }
        private void imgCarte1_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(0);
            if(total == 13)
            {
                imgCarte1.Visible = false;
            }
        }
        private void imgCarte2_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(1);
            if (total == 13)
            {
                imgCarte2.Visible = false;
            }
        }
        private void imgCarte3_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(2);
        }
        private void imgCarte4_Click_1(object sender, EventArgs e)
        {
            ClickSurPlateau(3);
        }
        private void imgCarte5_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(4);
        }
        private void imgCarte6_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(5);
        }
        private void imgCarte7_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(6);
        }
        private void imgCarte8_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(7);
        }
        private void imgCarte9_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(8);
        }
        private void imgCarte10_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(9);
        }
        private void imgCarte11_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(10);
        }
        private void imgCarte12_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(11);
        }
        private void imgCarte13_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(12);
        }
        private void imgCarte14_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(13);
        }
        private void imgCarte15_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(14);
        }
        private void imgCarte16_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(15);
        }
        private void imgCarte17_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(16);
        }
        private void imgCarte18_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(17);
        }
        private void imgCarte19_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(18);
        }
        private void imgCarte20_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(19);
        }
        private void imgCarte21_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(20);
        }
        private void imgCarte22_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(21);
        }
        private void imgCarte23_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(22);
        }
        private void imgCarte24_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(23);
        }
        private void imgCarte25_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(24);
        }
        private void imgCarte26_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(25);
        }
        private void imgCarte27_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(26);
        }
        private void imgCarte28_Click(object sender, EventArgs e)
        {
            ClickSurPlateau(27);
            if (total == 13)
            {
                imgCarte28.Visible = false;
            }
        }


    }
}
