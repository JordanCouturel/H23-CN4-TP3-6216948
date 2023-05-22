using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaladeurMultiFormats
{
    public interface IBaladeur
    {
        int NbChansons { get; }

        void AfficherLesChansons(ListView pListView);

        Chanson ChansonAt(int pIndex);

        void ConstruireLaListeDesChansons();

        void ConvertirVersAAC(int pIndex);

        void ConvertirVersMP3(int pIndex);

        void ConvertirVersWMA(int pIndex);
    }
}
