using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BaladeurMultiFormats
{
    public class Baladeur : IBaladeur
    {
        private const string NOM_RÉPERTOIRE = "Chansons";
        private List<Chanson> m_colChansons;

        public int NbChansons
        {
            get { return m_colChansons.Count; }
        }

        public Baladeur()
        {
            m_colChansons = new List<Chanson>();
        }

        public Chanson ChansonAt(int pIndex)
        {
            return m_colChansons[pIndex];
        }

        public void ConstruireLaListeDesChansons()
        {
            if (Directory.Exists(NOM_RÉPERTOIRE))
            {
                string[] songslist = Directory.GetFiles(NOM_RÉPERTOIRE);
                Array.Sort(songslist);
                foreach (string chansons in songslist)
                {

                    try
                    {
                        string[] titreEtformat = chansons.Split('.');
                        Chanson chanson;
                        switch (titreEtformat[1])
                        {
                            case "aac":
                                chanson = new ChansonAAC(chansons);
                                m_colChansons.Add(chanson);
                                break;
                            case "mp3":
                                chanson = new ChansonMP3(chansons);
                                m_colChansons.Add(chanson);
                                break;
                            case "wma":
                                chanson = new ChansonWMA(chansons);
                                m_colChansons.Add(chanson);
                                break;
                        }
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
        }
        public void AfficherLesChansons(ListView pListView)
        {
            pListView.Items.Clear();

            foreach (Chanson chansons in m_colChansons)
            {
                ListViewItem objitem = new ListViewItem(chansons.Artiste);
                objitem.SubItems.Add(chansons.Titre);
                objitem.SubItems.Add(chansons.Annee.ToString());
                objitem.SubItems.Add(chansons.Format.ToUpper());

                pListView.Items.Add(objitem);
            }

        }

        public void ConvertirVersAAC(int pIndex)
        {
          
        }
        public void ConvertirVersMP3(int pIndex)
        {


         
        }

        public void ConvertirVersWMA(int pIndex)
        {
           
        }
    }
}
