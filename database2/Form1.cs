using System.Data;
using System.Data.OleDb;

namespace database2
{
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Elif\\Documents\\Database3.accdb;");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string soyad = textBox2.Text;
            string telefon = textBoxTelefon.Text;
            DateTime alinanTar = dateTimePicker1.Value; // Tarih de�i�kenini g�ncelle

            string urunAdi = textBoxUrunAdi.Text;
            decimal tutar = decimal.Parse(textBoxTutar.Text); // �r�n tutar�
            decimal odenenTutar = decimal.Parse(textBoxOdenenTutar.Text); // �denen tutar
            decimal kalanTutar = tutar - odenenTutar; // Kalan tutar

            try
            {
                con.Open();

                // Ayn� isimde kay�t var m� diye kontrol et
                string checkSql = "SELECT * FROM Musteriler WHERE Ad = ? AND Soyad = ?";
                using (OleDbCommand checkCmd = new OleDbCommand(checkSql, con))
                {
                    checkCmd.Parameters.Add("?", OleDbType.VarChar).Value = ad;
                    checkCmd.Parameters.Add("?", OleDbType.VarChar).Value = soyad;

                    using (OleDbDataReader reader = checkCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["Ad"].ToString().Equals(ad, StringComparison.OrdinalIgnoreCase) &&
                                reader["Soyad"].ToString().Equals(soyad, StringComparison.OrdinalIgnoreCase))
                            {
                                MessageBox.Show("Ayn� isimde kay�t bulunmaktad�r.");
                                return;
                            }
                        }
                    }
                }

                // Musteriler tablosuna m��teri bilgilerini ekle
                string sqlMusteri = "INSERT INTO Musteriler (Ad, Soyad, Telefon, AlinanTarih) VALUES (?, ?, ?, ?)";
                using (OleDbCommand cmdMusteri = new OleDbCommand(sqlMusteri, con))
                {
                    cmdMusteri.Parameters.Add("?", OleDbType.VarChar).Value = ad;
                    cmdMusteri.Parameters.Add("?", OleDbType.VarChar).Value = soyad;
                    cmdMusteri.Parameters.Add("?", OleDbType.VarChar).Value = telefon;
                    cmdMusteri.Parameters.Add("?", OleDbType.Date).Value = alinanTar;

                    cmdMusteri.ExecuteNonQuery();
                }

                // Urunler tablosuna �r�n bilgilerini ve kalan tutar� ekle
                string sqlUrun = "INSERT INTO Urunler (�r�n, Tutar, KalanTutar) VALUES (?, ?, ?)";
                using (OleDbCommand cmdUrun = new OleDbCommand(sqlUrun, con))
                {
                    cmdUrun.Parameters.Add("?", OleDbType.VarChar).Value = urunAdi;
                    cmdUrun.Parameters.Add("?", OleDbType.Currency).Value = tutar;
                    cmdUrun.Parameters.Add("?", OleDbType.Currency).Value = kalanTutar;

                    cmdUrun.ExecuteNonQuery();
                }

                // ListBox'a yeni bir ��e ekle
                listBox1.Items.Add("Ad: " + ad + ", Soyad: " + soyad + ", Telefon: " + telefon + ", Al�nan Tarih: " + alinanTar.ToShortDateString());
                listBox1.Items.Add("�r�n: " + urunAdi + ", Tutar: " + tutar.ToString("C") + ", �denen: " + odenenTutar.ToString("C") + ", Kalan: " + kalanTutar.ToString("C"));

                // TextBox'lar� ve DateTimePicker'� temizle
                textBox1.Text = "";
                textBox2.Text = "";
                textBoxTelefon.Text = "";
                textBoxUrunAdi.Text = "";
                textBoxTutar.Text = "";
                textBoxOdenenTutar.Text = "";
                dateTimePicker1.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata olu�tu: " + ex.Message);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchName = textBox1.Text;
    string searchSurname = textBox2.Text;

    try
    {
        con.Open();

        // SQL komutunu olu�tur
        string sql = "SELECT Musteriler.Ad, Musteriler.Soyad, Musteriler.Telefon, Musteriler.AlinanTarih, Urunler.�r�n, Urunler.Tutar, Urunler.KalanTutar " +
                     "FROM Musteriler " +
                     "LEFT JOIN Urunler ON Musteriler.ID = Urunler.MusteriID " +
                     "WHERE 1=1";

        // Parametre listesi olu�tur
        List<OleDbParameter> parameters = new List<OleDbParameter>();

        if (!string.IsNullOrEmpty(searchName))
        {
            sql += " AND Musteriler.Ad LIKE ?";
            parameters.Add(new OleDbParameter("?", "%" + searchName + "%"));
        }
        if (!string.IsNullOrEmpty(searchSurname))
        {
            sql += " AND Musteriler.Soyad LIKE ?";
            parameters.Add(new OleDbParameter("?", "%" + searchSurname + "%"));
        }

        using (OleDbCommand cmd = new OleDbCommand(sql, con))
        {
            // Parametreleri komuta ekle
            cmd.Parameters.AddRange(parameters.ToArray());

            // Veritaban�ndan verileri al
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                // ListBox'� temizle
                listBox1.Items.Clear();

                // Kay�tlar�n say�s�n� takip et
                int recordCount = 0;

                // Verileri ListBox'a ekle
                while (reader.Read())
                {
                    // Null de�er kontrol� ve varsay�lan de�er atama
                    string ad = reader["Ad"] != DBNull.Value ? reader["Ad"].ToString() : "Bilinmiyor";
                    string soyad = reader["Soyad"] != DBNull.Value ? reader["Soyad"].ToString() : "Bilinmiyor";
                    string telefon = reader["Telefon"] != DBNull.Value ? reader["Telefon"].ToString() : "Bilinmiyor";
                    string alinanTarih = reader["AlinanTarih"] != DBNull.Value ? Convert.ToDateTime(reader["AlinanTarih"]).ToShortDateString() : "Tarih Yok";
                    string urun = reader["�r�n"] != DBNull.Value ? reader["�r�n"].ToString() : "�r�n Yok";
                    string tutar = reader["Tutar"] != DBNull.Value ? Convert.ToDecimal(reader["Tutar"]).ToString("C") : "Tutar Yok";
                    string kalanTutar = reader["KalanTutar"] != DBNull.Value ? Convert.ToDecimal(reader["KalanTutar"]).ToString("C") : "Kalan Tutar Yok";

                    listBox1.Items.Add("Ad: " + ad + ", Soyad: " + soyad + ", Telefon: " + telefon + ", Al�nan Tarih: " + alinanTarih);
                    listBox1.Items.Add("�r�n: " + urun + ", Tutar: " + tutar + ", Kalan Tutar: " + kalanTutar);

                    recordCount++;
                }

                // Kay�t bulunamad�ysa mesaj g�ster
                if (recordCount == 0)
                {
                    MessageBox.Show("Bu isimde kay�t bulunamad�.");
                }
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Bir hata olu�tu: " + ex.Message);
    }
    finally
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
    }
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;

            // Emin misiniz onay kutusu
            DialogResult dialogResult = MessageBox.Show("Bu kayd� silmek istedi�inize emin misiniz?", "Silme Onay�", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    // Veritaban� ba�lant�s�n� a�
                    con.Open();

                    // SQL komutunu olu�tur
                    string sql = "DELETE FROM Musteriler WHERE Ad = ? AND Soyad = ?";

                    // Komutu olu�tur
                    using (OleDbCommand cmd = new OleDbCommand(sql, con))
                    {
                        // Parametreleri ekle
                        cmd.Parameters.AddWithValue("?", name);
                        cmd.Parameters.AddWithValue("?", surname);

                        // Komutu �al��t�r
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kay�t(lar) ba�ar�yla silindi.");
                        }
                        else
                        {
                            MessageBox.Show("Kay�t bulunamad�.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hata mesaj�n� g�ster
                    MessageBox.Show("Bir hata olu�tu: " + ex.Message);
                }
                finally
                {
                    // Veritaban� ba�lant�s�n� kapat
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                // Kullan�c� "Hay�r" dediyse i�lem iptal edilir
                MessageBox.Show("Silme i�lemi iptal edildi.");
            }
        }

    }
}

