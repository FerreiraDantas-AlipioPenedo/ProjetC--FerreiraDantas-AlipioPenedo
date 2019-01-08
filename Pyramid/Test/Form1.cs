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

        int FirstTime = 0;
        string PseudoUser;

        int value1 = 0;
        int value2 = 0;
        int value3 = 0;
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

            Shuffle(Cartes);

            for (int i = 0; i < boxesCarte.Count(); i++)
            {
               
                boxesCarte[i].Image = Cartes.ElementAt(0).GetImage();
                CartesCheckList.Add(Cartes.ElementAt(0));
                Cartes.RemoveAt(0);
            }

            imgNouvelleCarte.Image = CarteGenerator.getDos(0.5);
            Shuffle(Cartes);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            grpInfoUser.Visible = true;
            if (grpInfoUser.Visible == true)
            {
                cmdAfficherScores.Enabled = false;
                cmdNextCarte.Enabled = false;
                cmdNouvellePartie.Enabled = false;
            }

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

                    if(FirstTime == 0)
                    {
                        lstScores.Items.Add(line);
                    }
                }
            }
            
            lstScores.Visible = true;
            cmdAfficherScores.Visible = false;
            cmdCacherScores.Visible = true;
            FirstTime++;

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
                    i++;
                    //MessageBox.Show(Cartes.ElementAt(i).GetCarteValeur().ToString());
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
            PictureBox[] boxesCarte =
            {
                imgCarte1, imgCarte2, imgCarte3, imgCarte4, imgCarte5, imgCarte6, imgCarte7, imgCarte8, imgCarte9, imgCarte10, imgCarte11,
                imgCarte12, imgCarte13, imgCarte14, imgCarte15, imgCarte16, imgCarte17, imgCarte18, imgCarte19, imgCarte20, imgCarte21,
                imgCarte22, imgCarte23, imgCarte24, imgCarte25, imgCarte26, imgCarte27, imgCarte28
            };
            value1 = Cartes.ElementAt(i - 2).GetCarteValeur();
            if(value1 == 13)
            {
                imgLastCarte.Image = UsedCarte.Last();
                Cartes.RemoveAt(i - 2);
                value1 = 0;
            }else
            {
                int t = value1 + value2;
                if(t == 13)
                {
                    imgLastCarte.Image = UsedCarte.Last();
                    Cartes.RemoveAt(i - 2);
                    value1 = 0;
                    value2 = 0;
                    boxesCarte.ElementAt(value3).Visible = false;
                }
            }
            //MessageBox.Show(Cartes.ElementAt(i-2).GetCarteValeur().ToString());    
        }
        private void imgNouvelleCarte_Click(object sender, EventArgs e)
        {
            PictureBox[] boxesCarte =
            {
                imgCarte1, imgCarte2, imgCarte3, imgCarte4, imgCarte5, imgCarte6, imgCarte7, imgCarte8, imgCarte9, imgCarte10, imgCarte11,
                imgCarte12, imgCarte13, imgCarte14, imgCarte15, imgCarte16, imgCarte17, imgCarte18, imgCarte19, imgCarte20, imgCarte21,
                imgCarte22, imgCarte23, imgCarte24, imgCarte25, imgCarte26, imgCarte27, imgCarte28
            };

            value1 = Cartes.ElementAt(i - 1).GetCarteValeur();
            if (value1 == 13)
            {
                imgNouvelleCarte.Image = Cartes.ElementAt(i).GetImage();
                Cartes.RemoveAt(i - 1);
                value1 = 0;
                value2 = 0;            }
            else
            {
                int t = value1 + value2;
                if(t == 13)
                {
                    imgNouvelleCarte.Image = Cartes.ElementAt(i).GetImage();
                    Cartes.RemoveAt(i - 1);
                    value1 = 0;
                    boxesCarte.ElementAt(value3).Visible = false;
                }
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
            bool clickVerif = CanClick(nbCarte);
            PictureBox[] boxesCarte =
            {
                imgCarte1, imgCarte2, imgCarte3, imgCarte4, imgCarte5, imgCarte6, imgCarte7, imgCarte8, imgCarte9, imgCarte10, imgCarte11,
                imgCarte12, imgCarte13, imgCarte14, imgCarte15, imgCarte16, imgCarte17, imgCarte18, imgCarte19, imgCarte20, imgCarte21,
                imgCarte22, imgCarte23, imgCarte24, imgCarte25, imgCarte26, imgCarte27, imgCarte28
            };

            if (total == 13 && clickVerif == false)
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

        public void ClickSurPlateau1(int nbCarte)
        {
            total = CartesCheckList.ElementAt(nbCarte).GetCarteValeur();
            value2 = CartesCheckList.ElementAt(nbCarte).GetCarteValeur();
            value3 = nbCarte;
            bool clickVerif = CanClick(nbCarte);
            PictureBox[] boxesCarte =
            {
                imgCarte1, imgCarte2, imgCarte3, imgCarte4, imgCarte5, imgCarte6, imgCarte7, imgCarte8, imgCarte9, imgCarte10, imgCarte11,
                imgCarte12, imgCarte13, imgCarte14, imgCarte15, imgCarte16, imgCarte17, imgCarte18, imgCarte19, imgCarte20, imgCarte21,
                imgCarte22, imgCarte23, imgCarte24, imgCarte25, imgCarte26, imgCarte27, imgCarte28
            };

            if (total == 13 && clickVerif == false)
            {
                boxesCarte.ElementAt(nbCarte).Visible = false;
            }
            else
            {
                ClickSurPlateau(nbCarte);
            }            
        }

        private void imgCarte1_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(0);
        }
        private void imgCarte2_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(1);
        }
        private void imgCarte3_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(2);
        }
        private void imgCarte4_Click_1(object sender, EventArgs e)
        {
            ClickSurPlateau1(3);
        }
        private void imgCarte5_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(4);
        }
        private void imgCarte6_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(5);
        }
        private void imgCarte7_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(6);
        }
        private void imgCarte8_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(7);
        }
        private void imgCarte9_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(8);
        }
        private void imgCarte10_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(9);
        }
        private void imgCarte11_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(10);
        }
        private void imgCarte12_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(11);
        }
        private void imgCarte13_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(12);
        }
        private void imgCarte14_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(13);
        }
        private void imgCarte15_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(14);
        }
        private void imgCarte16_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(15);
        }
        private void imgCarte17_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(16);
        }
        private void imgCarte18_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(17);
        }
        private void imgCarte19_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(18);
        }
        private void imgCarte20_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(19);
        }
        private void imgCarte21_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(20);
        }
        private void imgCarte22_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(21);
        }
        private void imgCarte23_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(22);
        }
        private void imgCarte24_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(23);
        }
        private void imgCarte25_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(24);
        }
        private void imgCarte26_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(25);
        }
        private void imgCarte27_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(26);
        }
        private void imgCarte28_Click(object sender, EventArgs e)
        {
            ClickSurPlateau1(27);
        }

        public bool CanClick(int nbCarte)
        {
            switch (nbCarte)
            {
                case 0:
                    if (imgCarte2.Visible == true || imgCarte3.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 1:
                    if (imgCarte4.Visible == true || imgCarte5.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 2:
                    if (imgCarte5.Visible == true || imgCarte6.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 3:
                    if (imgCarte7.Visible == true || imgCarte8.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 4:
                    if (imgCarte8.Visible == true || imgCarte9.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 5:
                    if (imgCarte9.Visible == true || imgCarte10.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 6:
                    if (imgCarte11.Visible == true || imgCarte12.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 7:
                    if (imgCarte12.Visible == true || imgCarte13.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 8:
                    if (imgCarte13.Visible == true || imgCarte14.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 9:
                    if (imgCarte14.Visible == true || imgCarte15.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 10:
                    if (imgCarte16.Visible == true || imgCarte17.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 11:
                    if (imgCarte17.Visible == true || imgCarte18.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 12:
                    if (imgCarte18.Visible == true || imgCarte19.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 13:
                    if (imgCarte19.Visible == true || imgCarte20.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 14:
                    if (imgCarte20.Visible == true || imgCarte21.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 15:
                    if (imgCarte22.Visible == true || imgCarte23.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 16:
                    if (imgCarte23.Visible == true || imgCarte24.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 17:
                    if (imgCarte24.Visible == true || imgCarte25.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 18:
                    if (imgCarte25.Visible == true || imgCarte26.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 19:
                    if (imgCarte26.Visible == true || imgCarte27.Visible == true)
                    {
                        return true;
                    }
                    break;
                case 20:
                    if (imgCarte27.Visible == true || imgCarte28.Visible == true)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        private void cmdValiderPseudo_Click(object sender, EventArgs e)
        {
            if(txtPseudoUser.Text != "")
            {
                PseudoUser = txtPseudoUser.Text;
                grpInfoUser.Visible = false;
                cmdAfficherScores.Enabled = true;
                cmdNextCarte.Enabled = true;
                cmdNouvellePartie.Enabled = true;
                MyPaint();
            }
            else
            {
                MessageBox.Show("Veuillez insérer un pseudo !");
            }
            
        }
    }
}
