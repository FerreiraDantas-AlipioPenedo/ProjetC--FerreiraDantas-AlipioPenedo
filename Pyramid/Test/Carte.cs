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
        public int valeur;
        public Image carte;

        public Carte(int Valeur, Image Carte)
        {
            this.valeur = Valeur;
            this.carte = Carte;        
        }

        public int GetCarteValeur()
        {
            return this.valeur;
        }

        public Image GetImage()
        {
            return this.carte;
        }
    }
}
