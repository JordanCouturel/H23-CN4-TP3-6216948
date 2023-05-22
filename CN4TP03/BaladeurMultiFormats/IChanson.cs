using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BaladeurMultiFormats
{
    public interface IChanson
    {
        //proprietes
        int Annee { get; }

        string Artiste { get; }

        string Format { get; }

        string NomFicher { get; }

        string Paroles { get; }

        string Titre { get; }

        //methodes

        void Ecrire(string pParoles);

        void EcrireEntete(StreamWriter pobjFichier);

        void EcrireParoles(StreamWriter pobjFichier, string pParoles);

        void LireEntete();

        string LireParoles(StreamReader pobjFichier);

        void SauterEntete(StreamReader pobjFichier);

    }
}

