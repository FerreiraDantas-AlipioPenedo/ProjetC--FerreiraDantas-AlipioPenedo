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
        //variables

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
        int turn = 0;

        int score = 0;

        int tempValue = 0;
        int tempCarte = 0;
        int value1 = 0;
        int value2 = 0;
        int value3 = 0;
        int value4 = 0;
        int total = 0;
        int total1 = 0;
        int total2 = 0;

        bool firstRang = false;
        bool secondRang = false;
        bool thirtRang = false;
        bool fourthRang = false;
        bool fifthRang = false;
        bool sixRang = false;
        bool sevenRang = false;

        int nbPlateau = 0;

        PictureBox ptb = new PictureBox();

        //end of variables

        public Form1()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        //  This function place de cards on the pyramid
        public void MyPaint()
        {
            PictureBox[] boxesCarte =
            {
                imgCarte1, imgCarte2, imgCarte3, imgCarte4, imgCarte5, imgCarte6, imgCarte7, imgCarte8, imgCarte9, imgCarte10, imgCarte11,
                imgCarte12, imgCarte13, imgCarte14, imgCarte15, imgCarte16, imgCarte17, imgCarte18, imgCarte19, imgCarte20, imgCarte21,
                imgCarte22, imgCarte23, imgCarte24, imgCarte25, imgCarte26, imgCarte27, imgCarte28
            };

            for (int i = 0; i < boxesCarte.Count(); i++)
            {
                Shuffle(Cartes);
                boxesCarte[i].Image = Cartes.ElementAt(0).GetImage();
                CartesCheckList.Add(Cartes.ElementAt(0));
                Cartes.RemoveAt(0);
            }

            imgNouvelleCarte.Image = CarteGenerator.getDos(0.5);
            Shuffle(Cartes);
        }

        // Ask the name of the user
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

        // this functions displays the score board on the click of the button
        private void cmdAfficherScores_Click(object sender, EventArgs e)
        {
            using (var reader = new StreamReader(fichierScores))
            {

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (FirstTime == 0)
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

        //this function undisplays the score board on the click of the button
        private void cmdCacherScores_Click(object sender, EventArgs e)
        {
            lstScores.Visible = false;
            cmdAfficherScores.Visible = true;
            cmdCacherScores.Visible = false;
        }

        // this function permits to shuffle all types of lists 
        private void Shuffle<T>(List<T> list)
        {
            for (int i = 0; i < 100; i++)
            {
                int index1 = rd.Next(0, list.Count);
                int index2 = rd.Next(0, list.Count);
                T o = list[index1];
                list[index1] = list[index2];
                list[index2] = o;
            }
        }

        // this function shows the next card of the deck of the user and counts is tours (max tours of is deck = 3)
        private void cmdNextCarte_Click(object sender, EventArgs e)
        {
            nbClickNextCard++;
            if (nbClickNextCard == 1)
            {
                imgNouvelleCarte.Image = Cartes.ElementAt(i).GetImage();
                imgNouvelleCarte.Visible = true;
                imgLastCarte.Visible = false;
                i++;
            }
            else
            {
                if (i < Cartes.Count())
                {
                    UsedCarte.Add(imgLastCarte.Image);
                    imgLastCarte.Image = imgNouvelleCarte.Image;
                    imgNouvelleCarte.Image = Cartes.ElementAt(i).GetImage();
                    imgLastCarte.Visible = true;
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

            if (tour == 0)
            {
                cmdNextCarte.Enabled = false;
            }
        }

        //this function gets the value of the last card displayed and elininates it
        // if the pair addition is = 13 and if its a king card
        private void imgLastCarte_Click(object sender, EventArgs e)
        {
            score = Int32.Parse(lblScore.Text);
            if (i < Cartes.Count())
            {
                value1 = Cartes.ElementAt(i - 2).GetCarteValeur();
            }

            if (value1 == 13)
            {
                imgLastCarte.Image = UsedCarte.Last();
                Cartes.RemoveAt(i - 2);
                score += 5;
                lblScore.Text = score.ToString();
                value1 = 0;
            }
        }

        // does the same as the last function but on the new card displayed from the user deck
        private void imgNouvelleCarte_Click(object sender, EventArgs e)
        {
            score = Int32.Parse(lblScore.Text);
            if (i < Cartes.Count())
            {
                value2 = Cartes.ElementAt(i - 1).GetCarteValeur();
            }

            if (value2 == 13)
            {
                imgNouvelleCarte.Image = UsedCarte.Last();
                Cartes.RemoveAt(i - 1);
                score += 5;
                lblScore.Text = score.ToString();
                value2 = 0;
            }
        }

        // this funciton creates a new game on the click of the button "Nouvelle Partie"
        private void cmdNouvellePartie_Click(object sender, EventArgs e)
        {
            PictureBox[] boxesCarte =
            {
                imgCarte1, imgCarte2, imgCarte3, imgCarte4, imgCarte5, imgCarte6, imgCarte7, imgCarte8, imgCarte9, imgCarte10, imgCarte11,
                imgCarte12, imgCarte13, imgCarte14, imgCarte15, imgCarte16, imgCarte17, imgCarte18, imgCarte19, imgCarte20, imgCarte21,
                imgCarte22, imgCarte23, imgCarte24, imgCarte25, imgCarte26, imgCarte27, imgCarte28
            };

            Cartes = CarteGenerator.getToutesCartes(0.5);
            CartesCheckList = new List<Carte>();
            UsedCarte = new List<Image>();
            nbClickNextCard = 0;
            i = 0;
            tour = 3;

            FirstTime = 0;

            score = 0;

            tempValue = 0;
            tempCarte = 0;
            value1 = 0;
            value2 = 0;
            value3 = 0;
            value4 = 0;
            total = 0;
            total1 = 0;

            firstRang = false;
            secondRang = false;
            thirtRang = false;
            fourthRang = false;
            fifthRang = false;
            sixRang = false;
            sevenRang = false;

            MyPaint();
            lblScore.Text = score.ToString();

            imgLastCarte.Visible = false;

            foreach (PictureBox p in boxesCarte)
            {
                if (p.Visible == false)
                {
                    p.Visible = true;
                }
            }
        }

        public void ClickOnCard(object sender, EventArgs e)
        {
            ptb = sender as PictureBox;
        }

        // this function manages the clicks on a card from the displayed pyramid 
        public void ClickSurPlateau1(int nbCarte)
        {
            int nbVisibleCard = 0;

            total = 0;
            total1 = 0;
            total2 = 0;

            PictureBox[] boxesCarte =
            {
                imgCarte1, imgCarte2, imgCarte3, imgCarte4, imgCarte5, imgCarte6, imgCarte7, imgCarte8, imgCarte9, imgCarte10, imgCarte11,
                imgCarte12, imgCarte13, imgCarte14, imgCarte15, imgCarte16, imgCarte17, imgCarte18, imgCarte19, imgCarte20, imgCarte21,
                imgCarte22, imgCarte23, imgCarte24, imgCarte25, imgCarte26, imgCarte27, imgCarte28
            };

            value3 = CartesCheckList.ElementAt(nbCarte).GetCarteValeur();
            total = value3 + value1;
            total1 = value3 + value2;
            total2 = value3 + value4;
            bool clickVerif = CanClick(nbCarte);
            score = Int32.Parse(lblScore.Text);

            if (value3 == 13 && clickVerif == false)
            {
                boxesCarte.ElementAt(nbCarte).Visible = false;
                value3 = 0;
                score += 5;
                lblScore.Text = score.ToString();
            }
            else if (total == 13 && clickVerif == false)
            {
                boxesCarte.ElementAt(nbCarte).Visible = false;
                imgLastCarte.Image = UsedCarte.Last();
                Cartes.RemoveAt(i - 2);
                score += 5;
                lblScore.Text = score.ToString();
                total = 0;
                value3 = 0;
            }
            else if (total1 == 13 && clickVerif == false)
            {
                boxesCarte.ElementAt(nbCarte).Visible = false;
                imgNouvelleCarte.Image = Cartes.ElementAt(i).GetImage();
                Cartes.RemoveAt(i - 1);
                total1 = 0;
                value3 = 0;
                score += 5;
                lblScore.Text = score.ToString();
            }
            else if (total2 == 13 && clickVerif == false)
            {
                boxesCarte.ElementAt(nbCarte).Visible = false;
                boxesCarte.ElementAt(tempCarte).Visible = false;
                score += 5;
                lblScore.Text = score.ToString();
                value3 = 0;
                value4 = 0;
                total2 = 0;
            }
            else
            {
                value4 = value3;
                tempCarte = nbCarte;


            }
            ScorePoints();



            foreach (PictureBox p in boxesCarte)
            {
                if (p.Visible == false)
                {
                    nbVisibleCard++;
                }
            }

            if (nbVisibleCard == 28)
            {
                FinduPlateau();
                nbPlateau++;
            }

            if (cmdSecondPlate.Text == "0" && tour == 0)
            {
                MessageBox.Show("Fin de partie");
                StreamWriter sw = new StreamWriter(fichierScores, true);
                sw.WriteLine(PseudoUser + " : " + score + " / " + nbPlateau + "panneaux");
                sw.Close();

                imgLastCarte.Enabled = false;
            }

        }

        //All this function call the function above with the number of the clicked PictureBox
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

        // this function manages if the user can or can not click on the cards displayed on the pyramid
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

        // this function containts the code to ask the user name and call the function MyPaint()
        // once the user have insert an allowed name 
        private void button1_Click(object sender, EventArgs e)
        {
            PseudoUser = txtPseudoUser.Text;
            if (txtPseudoUser.Text != "")
            {
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

        // this function adds score points to the user score once he eliminates an entier line of cards
        private void ScorePoints()
        {
            if (imgCarte22.Visible == false && imgCarte23.Visible == false && imgCarte24.Visible == false && imgCarte25.Visible == false && imgCarte26.Visible == false && imgCarte27.Visible == false && imgCarte28.Visible == false && firstRang == false)
            {
                score += 25;
                lblScore.Text = score.ToString();
                firstRang = true;
            }

            if (imgCarte16.Visible == false && imgCarte17.Visible == false && imgCarte18.Visible == false && imgCarte19.Visible == false && imgCarte20.Visible == false && imgCarte21.Visible == false && secondRang == false)
            {
                score += 50;
                lblScore.Text = score.ToString();
                secondRang = true;
            }

            if (imgCarte11.Visible == false && imgCarte12.Visible == false && imgCarte13.Visible == false && imgCarte14.Visible == false && imgCarte15.Visible == false && thirtRang == false)
            {
                score += 75;
                lblScore.Text = score.ToString();
                thirtRang = true;
            }

            if (imgCarte7.Visible == false && imgCarte8.Visible == false && imgCarte9.Visible == false && imgCarte10.Visible == false && fourthRang == false)
            {
                score += 100;
                lblScore.Text = score.ToString();
                fourthRang = true;
            }

            if (imgCarte4.Visible == false && imgCarte5.Visible == false && imgCarte6.Visible == false && fifthRang == false)
            {
                score += 150;
                lblScore.Text = score.ToString();
                firstRang = true;
            }

            if (imgCarte2.Visible == false && imgCarte3.Visible == false && sixRang == false)
            {
                score += 250;
                lblScore.Text = score.ToString();
                sixRang = true;
            }

            if (imgCarte1.Visible == false && sevenRang == false)
            {
                score += 500;
                lblScore.Text = score.ToString();
                sevenRang = true;
            }
        }

        // this function displays a new pyramid and give a new deck of cards to the user on the click of the button "2" or "1"
        private void cmdSecondPlate_Click(object sender, EventArgs e)
        {
            turn++;
            cmdNextCarte.Enabled = true;

            PictureBox[] boxesCarte =
            {
                imgCarte1, imgCarte2, imgCarte3, imgCarte4, imgCarte5, imgCarte6, imgCarte7, imgCarte8, imgCarte9, imgCarte10, imgCarte11,
                imgCarte12, imgCarte13, imgCarte14, imgCarte15, imgCarte16, imgCarte17, imgCarte18, imgCarte19, imgCarte20, imgCarte21,
                imgCarte22, imgCarte23, imgCarte24, imgCarte25, imgCarte26, imgCarte27, imgCarte28
            };

            Cartes = CarteGenerator.getToutesCartes(0.5);
            CartesCheckList = new List<Carte>();
            UsedCarte = new List<Image>();
            nbClickNextCard = 0;
            i = 0;
            tour = 3;

            FirstTime = 0;

            tempValue = 0;
            tempCarte = 0;
            value1 = 0;
            value2 = 0;
            value3 = 0;
            value4 = 0;
            total = 0;
            total1 = 0;

            firstRang = false;
            secondRang = false;
            thirtRang = false;
            fourthRang = false;
            fifthRang = false;
            sixRang = false;
            sevenRang = false;

            MyPaint();

            imgLastCarte.Visible = false;

            foreach (PictureBox p in boxesCarte)
            {
                if (p.Visible == false)
                {
                    p.Visible = true;
                }
            }

            if (turn == 1)
            {
                cmdSecondPlate.Text = 1.ToString();
            }
            else
            {
                cmdSecondPlate.Text = 0.ToString();
            }

            if (cmdSecondPlate.Text == "0")
            {
                cmdSecondPlate.Enabled = false;
            }
        }


        private void FinduPlateau()
        {

            PictureBox[] boxesCarte =
            {
                imgCarte1, imgCarte2, imgCarte3, imgCarte4, imgCarte5, imgCarte6, imgCarte7, imgCarte8, imgCarte9, imgCarte10, imgCarte11,
                imgCarte12, imgCarte13, imgCarte14, imgCarte15, imgCarte16, imgCarte17, imgCarte18, imgCarte19, imgCarte20, imgCarte21,
                imgCarte22, imgCarte23, imgCarte24, imgCarte25, imgCarte26, imgCarte27, imgCarte28
            };

            turn++;
            cmdNextCarte.Enabled = true;

            Cartes = CarteGenerator.getToutesCartes(0.5);
            CartesCheckList = new List<Carte>();
            UsedCarte = new List<Image>();
            nbClickNextCard = 0;
            i = 0;
            tour = 3;

            FirstTime = 0;

            tempValue = 0;
            tempCarte = 0;
            value1 = 0;
            value2 = 0;
            value3 = 0;
            value4 = 0;
            total = 0;
            total1 = 0;

            firstRang = false;
            secondRang = false;
            thirtRang = false;
            fourthRang = false;
            fifthRang = false;
            sixRang = false;
            sevenRang = false;

            MyPaint();

            imgLastCarte.Visible = false;

            foreach (PictureBox p in boxesCarte)
            {
                if (p.Visible == false)
                {
                    p.Visible = true;
                }
            }
        }
    }
}

