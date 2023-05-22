using System.IO;

namespace BaladeurMultiFormats
{
    public abstract class Chanson : IChanson
    {
        //champs
        protected int m_annee;
        protected string m_artiste;
        protected string m_nomFichier;
        protected string m_titre;

        //proprietes
        public int Annee
        {
            get { return m_annee; }
        }

        public string Artiste
        {
            get { return m_artiste; }
        }

        public abstract string Format
        {
            get;
        }


        public string NomFicher
        {
            get { return m_nomFichier; }
        }

        public string Paroles
        {
            get
            {
                string paroles = "";
                if (File.Exists(NomFicher))
                {
                    StreamReader objFichier = new StreamReader(NomFicher);
                    SauterEntete(objFichier);
                    paroles = LireParoles(objFichier);
                    objFichier.Close();
                }

                return paroles;
            }
        }



        public string Titre
        {
            get { return m_titre; }
        }

        //constructeur
        public Chanson(string pnomFichier)
        {
            m_nomFichier = pnomFichier;
            LireEntete();
        }

        public Chanson(string pRepertoire, string pArtiste, string pTitre, int pAnnée)
        {
            m_artiste = pArtiste;
            m_titre = pTitre;                                                                           /////////////////////////////
            m_annee = pAnnée;
            m_nomFichier = pRepertoire + "\\" + pTitre + "." + Format.ToLower();
        }

        //methodes
        public void Ecrire(string pParoles)
        {
            StreamWriter fichier = new StreamWriter(NomFicher);
            EcrireEntete(fichier);
            EcrireParoles(fichier, pParoles);
            //fichier.Close();
        }
        public abstract void EcrireEntete(StreamWriter pobjFichier);


        public abstract void EcrireParoles(StreamWriter pobjFichier, string pParoles);


        public abstract void LireEntete();


        public abstract string LireParoles(StreamReader pobjFichier);


        public void SauterEntete(StreamReader pobjFichier)
        {
            pobjFichier.ReadLine();

        }
    }
}
