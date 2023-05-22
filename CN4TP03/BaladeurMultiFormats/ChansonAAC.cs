using System.IO;

namespace BaladeurMultiFormats
{
    public class ChansonAAC : Chanson
    {
        public override string Format
        {
            get { return "aac"; }
        }

        public ChansonAAC(string pNomFichier) : base(pNomFichier)
        {

        }

        public ChansonAAC(string pRepertoire, string pArtiste, string pTitre, int pAnnée) : base(pRepertoire, pArtiste, pTitre, pAnnée)
        {

        }

        public override void LireEntete()
        {
            StreamReader fichier = new StreamReader(NomFicher);

            string Entete = fichier.ReadLine();
            string[] valeurs = Entete.Split(':');
            string[] titre = valeurs[0].Split('=');
            string[] artiste = valeurs[1].Split('=');
            string[] annee = valeurs[2].Split('=');

            m_titre = titre[1].Trim();
            m_artiste = artiste[1].Trim();
            m_annee = int.Parse(annee[1].Trim());

            fichier.Close();

        }

        public override string LireParoles(StreamReader pobjFichier)
        {
            string paroles = "";
            ///////////
            paroles = pobjFichier.ReadToEnd();


            return OutilsFormats.DecoderAAC(paroles);
        }

        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine($"TITRE = {Titre} : ARTISTE = {Artiste} : ANNÉE = {Annee}");

        }

        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            pobjFichier.WriteLine(pParoles);
            OutilsFormats.EncoderAAC(pParoles);

        }



    }
}
