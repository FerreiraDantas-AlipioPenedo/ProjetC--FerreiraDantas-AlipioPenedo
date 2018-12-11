using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pyramid
{
    class Carte
    {
        public int valeur;
        public Image carte;

        public Carte(int Valeur, Image Carte)
        {
            this.valeur = Valeur;
            this.carte = Carte;        
        }

        public int GetCarteValeur(Image Carte)
        {
            /*foreach(Image carte in Cartes)
            {
                if(carte == Carte)
                {
                    return valeur;
                }
            }*/
            return 0;
        }

        public Image GetImage()
        {
            return this.carte;
        }
    }
}
