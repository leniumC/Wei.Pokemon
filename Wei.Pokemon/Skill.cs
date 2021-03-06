﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wei.Pokemon
{
    public partial class Skill : Form
    {
        public Skill()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Skill_Load(object sender, EventArgs e)
        {
            String m_conn_str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\Wei.Pokemon.mdb;";
            System.Data.OleDb.OleDbConnection m_conn = new System.Data.OleDb.OleDbConnection(m_conn_str);
            m_conn.Open();
            string query1 = "select * from Skill";
            System.Data.OleDb.OleDbDataAdapter dataAdapter1 = new System.Data.OleDb.OleDbDataAdapter(query1, m_conn);
            DataTable dt = new DataTable();
            dataAdapter1.Fill(dt);
            this.dgType.DataSource = dt;
            this.dgType.Show();
            m_conn.Close();
            m_conn.Dispose();
        }

        private void btnType_Click(object sender, EventArgs e)
        {
            String m_conn_str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\Wei.Pokemon.mdb;";
            System.Data.OleDb.OleDbConnection m_conn = new System.Data.OleDb.OleDbConnection(m_conn_str);
            m_conn.Open();
            Query q = new Query();
            q.ShowDialog();
            string query1;
            int query2;
            if (Query.num == 0)
                query1 = "select * from Skill";
            else
            {
                query2 = Query.num;
                query1 = "select * from Skill where SKILL_attribute = " + query2;
            }
            System.Data.OleDb.OleDbDataAdapter dataAdapter1 = new System.Data.OleDb.OleDbDataAdapter(query1, m_conn);
            DataTable dt = new DataTable();
            dataAdapter1.Fill(dt);
            this.dgType.DataSource = dt;
            this.dgType.Show();
            m_conn.Close();
            m_conn.Dispose();
        }
    }
}
