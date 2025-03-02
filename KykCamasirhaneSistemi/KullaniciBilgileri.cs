using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KykCamasirhaneSistemi
{
    public partial class KullaniciBilgileri : Form
    {

        public KullaniciBilgileri()
        {
            InitializeComponent();
        }


        private void btnkaydet_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-A10RFBMB;Initial Catalog=KykCamasirhaneProjesi;Integrated Security=True;";

          
            string query = "INSERT INTO Kullanici (Ad, Soyad, Telefon) " +
                           "VALUES (@Ad, @Soyad, @Telefon); SELECT SCOPE_IDENTITY();"; // KullaniciID'yi döndürmek için SCOPE_IDENTITY() kullanıyoruz.

            int kullaniciID = 0;

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                  
                    command.Parameters.AddWithValue("@Ad", txtadi.Text);
                    command.Parameters.AddWithValue("@Soyad", txtsoyadi.Text);
                    command.Parameters.AddWithValue("@Telefon", txttelno.Text);

                    try
                    {
                        
                        connection.Open();
                        kullaniciID = Convert.ToInt32(command.ExecuteScalar()); 

                        if (kullaniciID > 0)
                        {
                            MessageBox.Show("Kullanıcı başarıyla kaydedildi.");
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı kaydedilemedi.");
                            return; 
                        }
                    }
                    catch (Exception ex)
                    {
                       
                        MessageBox.Show("Hata: " + ex.Message);
                        return;
                    }
                }
            }

           
            query = "INSERT INTO KullaniciBilgileri (KullaniciID, BlokNo, OdaNo) VALUES (@KullaniciID, @BlokNo, @OdaNo)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    command.Parameters.AddWithValue("@KullaniciID", kullaniciID); 
                    command.Parameters.AddWithValue("@BlokNo", txtblokno.Text);
                    command.Parameters.AddWithValue("@OdaNo", txtodano.Text);

                    try
                    {
                       
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kullanıcı bilgileri başarıyla kaydedildi.");
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı bilgileri kaydedilemedi.");
                        }
                    }
                    catch (Exception ex)
                    {
                        
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }

                MakineSecimi MakineSecimi = new MakineSecimi();
                MakineSecimi.FormClosed += (s, args) => this.Show();
                MakineSecimi.Show();
            }
        }

        private void KullaniciBilgileri_Load(object sender, EventArgs e)
        {

        }
    }

        
    }

