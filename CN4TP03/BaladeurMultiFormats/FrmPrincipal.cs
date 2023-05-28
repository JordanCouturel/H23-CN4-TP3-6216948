using System;
using System.Windows.Forms;

namespace BaladeurMultiFormats
{
    // Étapes de  réalisation :
    // Étape #1 : Définir les classes Chanson et ChansonAAC

    public partial class FrmPrincipal : Form
    {
        public const string APP_INFO = "(Jordan Couture-Lafranchise 6216948)";

        #region Propriété : MonHistorique
        public Historique MonHistorique { get; }
        public Baladeur baladeur;
        #endregion
        //---------------------------------------------------------------------------------
        #region FrmPrincipal
        public FrmPrincipal()
        {
            InitializeComponent();
            Text += APP_INFO;
            MonHistorique = new Historique();
            // À COMPLÉTER...


            baladeur = new Baladeur();
            baladeur.ConstruireLaListeDesChansons();
            baladeur.AfficherLesChansons(lsvChansons);
            MettreAJourSelonContexte();
            lblNbChansons.Text = lsvChansons.Items.Count.ToString();

        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Méthode : MettreAJourSelonContexte
        private void MettreAJourSelonContexte()
        {
            // À COMPLÉTER...

            if (lsvChansons.SelectedIndices.Count > 0)
            {
                if (baladeur.ChansonAt(lsvChansons.SelectedIndices[0]).Format == "wma")
                {
                    MnuFormatConvertirVersWMA.Enabled = false;
                }
                else
                {
                    MnuFormatConvertirVersWMA.Enabled = true;
                }

                if (baladeur.ChansonAt(lsvChansons.SelectedIndices[0]).Format == "mp3")
                {
                    MnuFormatConvertirVersMP3.Enabled = false;
                }
                else
                {
                    MnuFormatConvertirVersMP3.Enabled = true;
                }

                if (baladeur.ChansonAt(lsvChansons.SelectedIndices[0]).Format == "aac")
                {
                    MnuFormatConvertirVersAAC.Enabled = false;
                }
                else
                {
                    MnuFormatConvertirVersAAC.Enabled = true;
                }

                lsvChansons.Items[lsvChansons.SelectedIndices[0]].SubItems[3].Text = baladeur.ChansonAt(lsvChansons.SelectedIndices[0]).Format.ToUpper();
            }

        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Événement : LsvChansons_SelectedIndexChanged
        private void LsvChansons_SelectedIndexChanged(object sender, EventArgs e)
        {
            // À COMPLÉTER...
            if (lsvChansons.SelectedIndices.Count != 0)
            {
                txtParoles.Text = baladeur.ChansonAt(lsvChansons.SelectedIndices[0]).Paroles;
                MonHistorique.Add(new Consultation(DateTime.Now, baladeur.ChansonAt(lsvChansons.SelectedIndices[0])));
                MettreAJourSelonContexte();
            }
            MettreAJourSelonContexte();


        }
        #endregion

        //---------------------------------------------------------------------------------
        #region Méthodes : Convertir vers les formats AAC, MP3 ou WMA
        private void MnuFormatConvertirVersAAC_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...

            MonHistorique.Clear();


            if (lsvChansons.SelectedIndices.Count != 0)
            {
                baladeur.ConvertirVersAAC(lsvChansons.SelectedIndices[0]);
                MettreAJourSelonContexte();
            }





        }
        private void MnuFormatConvertirVersMP3_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
            MonHistorique.Clear();


            if (lsvChansons.SelectedIndices.Count != 0)
            {

                baladeur.ConvertirVersMP3(lsvChansons.SelectedIndices[0]);
                MettreAJourSelonContexte();
            }


        }
        private void MnuFormatConvertirVersWMA_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
            MonHistorique.Clear();


            if (lsvChansons.SelectedIndices.Count != 0)
            {
                baladeur.ConvertirVersWMA(lsvChansons.SelectedIndices[0]);
                MettreAJourSelonContexte();
            }
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Historique
        private void MnuSpécialHistorique_Click(object sender, EventArgs e)
        {
            FrmHistorique objFormulaire = new FrmHistorique(MonHistorique);
            objFormulaire.ShowDialog();
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Méthodes : MnuFichierQuitter_Click
        //---------------------------------------------------------------------------------
        private void MnuFichierQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
