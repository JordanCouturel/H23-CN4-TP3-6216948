using System.IO;

namespace BaladeurMultiFormats
{
    public class ChansonMP3 : Chanson
    {
        public override string Format
        {
            get { return "mp3"; }
        }

        public ChansonMP3(string pNomFichier) : base(pNomFichier)
        {

        }

        public ChansonMP3(string pRepertoire, string pArtiste, string pTitre, int pAnnée) : base(pRepertoire, pArtiste, pTitre, pAnnée)
        {

        }

        public override void LireEntete()
        {
            StreamReader fichier = new StreamReader(NomFicher);

            string Entete = fichier.ReadLine();
            string[] valeurs = Entete.Split('|');

            m_artiste = valeurs[0].Trim();
            m_annee = int.Parse(valeurs[1].Trim());
            m_titre = valeurs[2].Trim();

            fichier.Close();

        }

        public override string LireParoles(StreamReader pobjFichier)
        {
            string paroles = "";

            paroles = pobjFichier.ReadToEnd();
            paroles = OutilsFormats.DecoderMP3(paroles);


            return paroles;



        }

        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine($"{Artiste} | {Annee} | {Titre}");
        }

        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            string parolesencodés = OutilsFormats.EncoderMP3(pParoles);
            pobjFichier.WriteLine(parolesencodés);



        }



    }
}