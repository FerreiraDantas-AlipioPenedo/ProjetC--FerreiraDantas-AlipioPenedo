using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace Pyramid
{
    public class CarteGenerator
    {

        int rd = new Random().Next(0, 4);
        int rd2 = new Random().Next(0, 13);     

        // Le chemin pour se rendre a l'image.
        // Le chemin par défaut devrait fonctionner si vous avez suivi les instructions
        // Par défaut: return Application.StartupPath + "\\deck.png";
        public static string ImagePath
        {
            get
            {
                return Application.StartupPath + "deck.png";
            }
        }

        // Liste des sortes de cartes
        // L'ordre est important pour le découpage sur l'image
        public enum SorteCarte
        {
            Coeur,
            Carreau,
            Pique,
            Trefle
        }

        // Liste des valeur de cartes
        // L'ordre est important pour le découpage sur l'image
        public enum ValeurCarte
        {
            As,
            Deux,
            Trois,
            Quatre,
            Cinq,
            Six,
            Sept,
            Huit,
            Neuf,
            Dix,
            Valet,
            Dame,
            Roi
        }

        // Découpe et retourne la carte sur l'image de base
        public static Image getCarteImage(int x, int y, double size)
        {
            // On va chercher l'image de base          
            Image imgSource = new Bitmap(ImagePath);

            // On crée une nouvelle image sur laquel on va dessiner
            Image img = new Bitmap((int)(150 * size), (int)(200 * size));

            // On prends en main notre "crayon" pour dessiner
            Graphics g = Graphics.FromImage(img);

            // On note la position et la grosseur de l'image de la carte
            Rectangle rect = new Rectangle(1, 1, (int)(147 * size), (int)(197 * size));

            // On dessine la carte
            g.DrawImage(imgSource, rect, x, y, (int)150, (int)200, GraphicsUnit.Pixel);

            // On rajoute une toute petite bordure autour de la carte
            g.DrawRectangle(new Pen(Brushes.Black), 0, 0, (int)(149 * size), (int)(199 * size));

            // On renvoi la carte
            return img;
        }

        public static Image getCarte(SorteCarte sorte, ValeurCarte valeur, double size)
        {
            return getCarteImage(((int)valeur) * 150, ((int)sorte) * 200, size);
        }

        public static Image getJoker(bool colored, double size)
        {
            int coef = (colored ? 0 : 1);
            return getCarteImage(1950, 200 * coef, size);
        }
        public static Image getDos(double size)
        {
            return getCarteImage(1950, 400, size);
        }

        public static List<Carte> getToutesCartes(double size)
        {
            List<Image> Cartes = new List<Image>();
            List<Carte> Carte = new List<Carte>();

            //Add all heart cards in the list Cartes
            Cartes.Add(getCarte(SorteCarte.Coeur, ValeurCarte.As, size));
            Cartes.Add(getCarte(SorteCarte.Coeur, ValeurCarte.Deux, size));
            Cartes.Add(getCarte(SorteCarte.Coeur, ValeurCarte.Trois, size));
            Cartes.Add(getCarte(SorteCarte.Coeur, ValeurCarte.Quatre, size));
            Cartes.Add(getCarte(SorteCarte.Coeur, ValeurCarte.Cinq, size));
            Cartes.Add(getCarte(SorteCarte.Coeur, ValeurCarte.Six, size));
            Cartes.Add(getCarte(SorteCarte.Coeur, ValeurCarte.Sept, size));
            Cartes.Add(getCarte(SorteCarte.Coeur, ValeurCarte.Huit, size));
            Cartes.Add(getCarte(SorteCarte.Coeur, ValeurCarte.Neuf, size));
            Cartes.Add(getCarte(SorteCarte.Coeur, ValeurCarte.Dix, size));
            Cartes.Add(getCarte(SorteCarte.Coeur, ValeurCarte.Valet, size));
            Cartes.Add(getCarte(SorteCarte.Coeur, ValeurCarte.Dame, size));
            Cartes.Add(getCarte(SorteCarte.Coeur, ValeurCarte.Roi, size));
            //
            Carte.Add(new Carte(1, getCarte(SorteCarte.Coeur, ValeurCarte.As, size)));
            Carte.Add(new Carte(2, getCarte(SorteCarte.Coeur, ValeurCarte.Deux, size)));
            Carte.Add(new Carte(3, getCarte(SorteCarte.Coeur, ValeurCarte.Trois, size)));
            Carte.Add(new Carte(4, getCarte(SorteCarte.Coeur, ValeurCarte.Quatre, size)));
            Carte.Add(new Carte(5, getCarte(SorteCarte.Coeur, ValeurCarte.Cinq, size)));
            Carte.Add(new Carte(6, getCarte(SorteCarte.Coeur, ValeurCarte.Six, size)));
            Carte.Add(new Carte(7, getCarte(SorteCarte.Coeur, ValeurCarte.Sept, size)));
            Carte.Add(new Carte(8, getCarte(SorteCarte.Coeur, ValeurCarte.Huit, size)));
            Carte.Add(new Carte(9, getCarte(SorteCarte.Coeur, ValeurCarte.Neuf, size)));
            Carte.Add(new Carte(10, getCarte(SorteCarte.Coeur, ValeurCarte.Dix, size)));
            Carte.Add(new Carte(11, getCarte(SorteCarte.Coeur, ValeurCarte.Valet, size)));
            Carte.Add(new Carte(12, getCarte(SorteCarte.Coeur, ValeurCarte.Dame, size)));
            Carte.Add(new Carte(13, getCarte(SorteCarte.Coeur, ValeurCarte.Roi, size)));

            //Add all diamond cards in the list Cartes
            Cartes.Add(getCarte(SorteCarte.Carreau, ValeurCarte.As, size));
            Cartes.Add(getCarte(SorteCarte.Carreau, ValeurCarte.Deux, size));
            Cartes.Add(getCarte(SorteCarte.Carreau, ValeurCarte.Trois, size));
            Cartes.Add(getCarte(SorteCarte.Carreau, ValeurCarte.Quatre, size));
            Cartes.Add(getCarte(SorteCarte.Carreau, ValeurCarte.Cinq, size));
            Cartes.Add(getCarte(SorteCarte.Carreau, ValeurCarte.Six, size));
            Cartes.Add(getCarte(SorteCarte.Carreau, ValeurCarte.Sept, size));
            Cartes.Add(getCarte(SorteCarte.Carreau, ValeurCarte.Huit, size));
            Cartes.Add(getCarte(SorteCarte.Carreau, ValeurCarte.Neuf, size));
            Cartes.Add(getCarte(SorteCarte.Carreau, ValeurCarte.Dix, size));
            Cartes.Add(getCarte(SorteCarte.Carreau, ValeurCarte.Valet, size));
            Cartes.Add(getCarte(SorteCarte.Carreau, ValeurCarte.Dame, size));
            Cartes.Add(getCarte(SorteCarte.Carreau, ValeurCarte.Roi, size));
            //
            Carte.Add(new Carte(1, getCarte(SorteCarte.Carreau, ValeurCarte.As, size)));
            Carte.Add(new Carte(2, getCarte(SorteCarte.Carreau, ValeurCarte.Deux, size)));
            Carte.Add(new Carte(3, getCarte(SorteCarte.Carreau, ValeurCarte.Trois, size)));
            Carte.Add(new Carte(4, getCarte(SorteCarte.Carreau, ValeurCarte.Quatre, size)));
            Carte.Add(new Carte(5, getCarte(SorteCarte.Carreau, ValeurCarte.Cinq, size)));
            Carte.Add(new Carte(6, getCarte(SorteCarte.Carreau, ValeurCarte.Six, size)));
            Carte.Add(new Carte(7, getCarte(SorteCarte.Carreau, ValeurCarte.Sept, size)));
            Carte.Add(new Carte(8, getCarte(SorteCarte.Carreau, ValeurCarte.Huit, size)));
            Carte.Add(new Carte(9, getCarte(SorteCarte.Carreau, ValeurCarte.Neuf, size)));
            Carte.Add(new Carte(10, getCarte(SorteCarte.Carreau, ValeurCarte.Dix, size)));
            Carte.Add(new Carte(11, getCarte(SorteCarte.Carreau, ValeurCarte.Valet, size)));
            Carte.Add(new Carte(12, getCarte(SorteCarte.Carreau, ValeurCarte.Dame, size)));
            Carte.Add(new Carte(13, getCarte(SorteCarte.Carreau, ValeurCarte.Roi, size)));

            //Add all spades cards in the list Cartes
            Cartes.Add(getCarte(SorteCarte.Pique, ValeurCarte.As, size));
            Cartes.Add(getCarte(SorteCarte.Pique, ValeurCarte.Deux, size));
            Cartes.Add(getCarte(SorteCarte.Pique, ValeurCarte.Trois, size));
            Cartes.Add(getCarte(SorteCarte.Pique, ValeurCarte.Quatre, size));
            Cartes.Add(getCarte(SorteCarte.Pique, ValeurCarte.Cinq, size));
            Cartes.Add(getCarte(SorteCarte.Pique, ValeurCarte.Six, size));
            Cartes.Add(getCarte(SorteCarte.Pique, ValeurCarte.Sept, size));
            Cartes.Add(getCarte(SorteCarte.Pique, ValeurCarte.Huit, size));
            Cartes.Add(getCarte(SorteCarte.Pique, ValeurCarte.Neuf, size));
            Cartes.Add(getCarte(SorteCarte.Pique, ValeurCarte.Dix, size));
            Cartes.Add(getCarte(SorteCarte.Pique, ValeurCarte.Valet, size));
            Cartes.Add(getCarte(SorteCarte.Pique, ValeurCarte.Dame, size));
            Cartes.Add(getCarte(SorteCarte.Pique, ValeurCarte.Roi, size));
            //
            Carte.Add(new Carte(1, getCarte(SorteCarte.Pique, ValeurCarte.As, size)));
            Carte.Add(new Carte(2, getCarte(SorteCarte.Pique, ValeurCarte.Deux, size)));
            Carte.Add(new Carte(3, getCarte(SorteCarte.Pique, ValeurCarte.Trois, size)));
            Carte.Add(new Carte(4, getCarte(SorteCarte.Pique, ValeurCarte.Quatre, size)));
            Carte.Add(new Carte(5, getCarte(SorteCarte.Pique, ValeurCarte.Cinq, size)));
            Carte.Add(new Carte(6, getCarte(SorteCarte.Pique, ValeurCarte.Six, size)));
            Carte.Add(new Carte(7, getCarte(SorteCarte.Pique, ValeurCarte.Sept, size)));
            Carte.Add(new Carte(8, getCarte(SorteCarte.Pique, ValeurCarte.Huit, size)));
            Carte.Add(new Carte(9, getCarte(SorteCarte.Pique, ValeurCarte.Neuf, size)));
            Carte.Add(new Carte(10, getCarte(SorteCarte.Pique, ValeurCarte.Dix, size)));
            Carte.Add(new Carte(11, getCarte(SorteCarte.Pique, ValeurCarte.Valet, size)));
            Carte.Add(new Carte(12, getCarte(SorteCarte.Pique, ValeurCarte.Dame, size)));
            Carte.Add(new Carte(13, getCarte(SorteCarte.Pique, ValeurCarte.Roi, size)));

            //Add all clubs cards in the Cartes
            Cartes.Add(getCarte(SorteCarte.Trefle, ValeurCarte.As, size));
            Cartes.Add(getCarte(SorteCarte.Trefle, ValeurCarte.Deux, size));
            Cartes.Add(getCarte(SorteCarte.Trefle, ValeurCarte.Trois, size));
            Cartes.Add(getCarte(SorteCarte.Trefle, ValeurCarte.Quatre, size));
            Cartes.Add(getCarte(SorteCarte.Trefle, ValeurCarte.Cinq, size));
            Cartes.Add(getCarte(SorteCarte.Trefle, ValeurCarte.Six, size));
            Cartes.Add(getCarte(SorteCarte.Trefle, ValeurCarte.Sept, size));
            Cartes.Add(getCarte(SorteCarte.Trefle, ValeurCarte.Huit, size));
            Cartes.Add(getCarte(SorteCarte.Trefle, ValeurCarte.Neuf, size));
            Cartes.Add(getCarte(SorteCarte.Trefle, ValeurCarte.Dix, size));
            Cartes.Add(getCarte(SorteCarte.Trefle, ValeurCarte.Valet, size));
            Cartes.Add(getCarte(SorteCarte.Trefle, ValeurCarte.Dame, size));
            Cartes.Add(getCarte(SorteCarte.Trefle, ValeurCarte.Roi, size));
            //
            Carte.Add(new Carte(1, getCarte(SorteCarte.Trefle, ValeurCarte.As, size)));
            Carte.Add(new Carte(2, getCarte(SorteCarte.Trefle, ValeurCarte.Deux, size)));
            Carte.Add(new Carte(3, getCarte(SorteCarte.Trefle, ValeurCarte.Trois, size)));
            Carte.Add(new Carte(4, getCarte(SorteCarte.Trefle, ValeurCarte.Quatre, size)));
            Carte.Add(new Carte(5, getCarte(SorteCarte.Trefle, ValeurCarte.Cinq, size)));
            Carte.Add(new Carte(6, getCarte(SorteCarte.Trefle, ValeurCarte.Six, size)));
            Carte.Add(new Carte(7, getCarte(SorteCarte.Trefle, ValeurCarte.Sept, size)));
            Carte.Add(new Carte(8, getCarte(SorteCarte.Trefle, ValeurCarte.Huit, size)));
            Carte.Add(new Carte(9, getCarte(SorteCarte.Trefle, ValeurCarte.Neuf, size)));
            Carte.Add(new Carte(10, getCarte(SorteCarte.Trefle, ValeurCarte.Dix, size)));
            Carte.Add(new Carte(11, getCarte(SorteCarte.Trefle, ValeurCarte.Valet, size)));
            Carte.Add(new Carte(12, getCarte(SorteCarte.Trefle, ValeurCarte.Dame, size)));
            Carte.Add(new Carte(13, getCarte(SorteCarte.Trefle, ValeurCarte.Roi, size)));

            //return the list Cartes
            return Carte;
        }
    }
}
