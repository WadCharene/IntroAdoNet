using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MedicoWeb.Models
{
    public class HoraireModel
    {

        public List<HoraireModel> GetAll()

            
            //1-Connexion
        {
            List<HoraireModel> laliste = new List<HoraireModel>();
            SqlConnection oConn = new SqlConnection();

            //1.1 Xhemin vers le serveur ==> ConnectionString 
            
            oConn.ConnectionString = @"Data Source=26R2-09\WADSQL;Initial Catalog=MedicoDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

             //1.2 Ouvrir la connexion 
            try //Ctrl+K+S
            {
                oConn.Open();

                //2 - Commande
                SqlCommand oCmd = new SqlCommand(@"SELECT * 
                                                    FROM Horaire 
                                                    WHERE DebDate<= GETDATE() 
                                                        and FinDate >= GETDATE()"
                                                    ,oConn);
                //3 - Execute
                SqlDataReader oDr = oCmd.ExecuteReader();
                //3.1 - Lire toutes les lignes
                //3.1 - Lire toutes les lignes
                while (oDr.Read())
                {
                    HoraireModel HM = new HoraireModel();
                    HM.IdHoraire = (int)oDr["IdHoraire"];
                    HM.Jour = oDr["Jour"].ToString();
                    HM.DebtMat = (TimeSpan)oDr["DebMat"];
                    HM.FinMat = (TimeSpan)oDr["FinMat"];
                    HM.DebAprem = (TimeSpan)oDr["DebAprem"];
                    HM.FinAprem = (TimeSpan)oDr["FinAprem"];
                    HM.DebDate = (DateTime)oDr["DebDate"];
                    HM.FinDate = (DateTime)oDr["FinDate"];
                    laliste.Add(HM);
                }
                //3.2 - Fermer le reader
                oDr.Close();
                //4 - Ferme la connexion
                oConn.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return laliste;
        }
        private int _idHoraire;

        public int IdHoraire
        {
            get { return _idHoraire; }
            set { _idHoraire = value; }
        }

        private string _jour;

        public string Jour
        {
            get { return _jour; }
            set { _jour = value; }
        }

        private TimeSpan _debtMat;

        public TimeSpan DebtMat
        {
            get { return _debtMat; }
            set { _debtMat = value; }
        }

        private TimeSpan _finMat;

        public TimeSpan FinMat
        {
            get { return _finMat; }
            set { _finMat = value; }
        }

        private TimeSpan _debAprem;

        public TimeSpan DebAprem
        {
            get { return _debAprem; }
            set { _debAprem = value; }
        }

        private TimeSpan _finAprem;

        public TimeSpan FinAprem
        {
            get { return _finAprem; }
            set { _finAprem = value; }
        }

        private DateTime _debDate;

        public DateTime DebDate
        {
            get { return _debDate; }
            set { _debDate = value; }
        }

        private DateTime _finDate;

        public DateTime FinDate
        {
            get { return _finDate; }
            set { _finDate = value; }
        }

    }
}