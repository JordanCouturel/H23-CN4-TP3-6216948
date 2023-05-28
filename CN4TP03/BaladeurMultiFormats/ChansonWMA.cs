using System;
using System.IO;

namespace BaladeurMultiFormats
{
    public class ChansonWMA : Chanson
    {
        private int m_codage;

        public override string Format
        {
            get { return "wma"; }
        }

        public ChansonWMA(string pNomFichier) : base(pNomFichier)
        {

        }

        public ChansonWMA(string pRepertoire, string pArtiste, string pTitre, int pAnnée) : base(pRepertoire, pArtiste, pTitre, pAnnée)
        {

        }

        public override void LireEntete()
        {
            StreamReader fichier = new StreamReader(NomFicher);

            string Entete = fichier.ReadLine();
            string[] valeurs = Entete.Split('/');
            m_codage = int.Parse(valeurs[0].Trim());
            m_annee = int.Parse(valeurs[1].Trim());
            m_titre = valeurs[2].Trim();
            m_artiste = valeurs[3].Trim();

            fichier.Close();

        }

        public override string LireParoles(StreamReader pobjFichier)
        {

            string paroles = "";

            paroles = pobjFichier.ReadToEnd();
            paroles = OutilsFormats.DecoderWMA(paroles, m_codage);
            return paroles;
        }

        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine($"{m_codage} / {Annee} / {Titre} / {Artiste}");
        }

        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            string parolesencodees = OutilsFormats.EncoderWMA(pParoles, m_codage);
            pobjFichier.WriteLine(parolesencodees);



        }



    }
}
