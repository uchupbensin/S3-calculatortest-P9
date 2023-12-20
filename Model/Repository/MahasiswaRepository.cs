﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using PerpustakaanAppMVC.Model.Entity;
using PerpustakaanAppMVC.Model.Context;

namespace PerpustakaanAppMVC.Model.Repository
{
    class MahasiswaRepository
    {
        // deklarsi objek connection
        private OleDbConnection _conn;

        // constructor
        public MahasiswaRepository(DbContext context)
        {
            // inisialisasi objek connection
            _conn = context.Conn;
        }
    }

    public int Create(Mahasiswa mhs)
    {
        int result = 0;
        // deklarasi perintah SQL
        string sql = @"insert into mahasiswa (npm, nama, angkatan) values (@npm, @nama, @angkatan)";
        // membuat objek command menggunakan blok using
        using (OleDbCommand cmd = new OleDbCommand(sql, _conn))
        {
            // mendaftarkan parameter dan mengeset nilainya
            cmd.Parameters.AddWithValue("@npm", mhs.Npm);
            cmd.Parameters.AddWithValue("@nama", mhs.Nama);
            cmd.Parameters.AddWithValue("@angkatan", mhs.Angkatan);
            try
            {
                // jalankan perintah INSERT dan tampung hasilnya ke dalam  variabel result
            result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
            }
        }
        return result;
    }

}
