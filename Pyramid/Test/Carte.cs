using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Pyramid
{
    public class Carte
    {
        //attributes of this class
        public int valeur;
        public Image carte;

        //constructor
        public Carte(int Valeur, Image Carte)
        {
            this.valeur = Valeur;
            this.carte = Carte;        
        }

        //this function returns the value of the selected  object  Carte
        public int GetCarteValeur()
        {
            return this.valeur;
        }

        //this function returns the image of the selected object Carte
        public Image GetImage()
        {
            return this.carte;
        }
    }
}
