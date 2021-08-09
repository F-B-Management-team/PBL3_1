﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.Views
{
    public partial class Revenue : UserControl
    {
        public Revenue()
        {
            InitializeComponent();
            //render_column();
            //LoadTong();
        }

        public void render_column()
        {
            var canvas = new Bunifu.Dataviz.WinForms.BunifuDatavizBasic.Canvas();
            var datapoint = new Bunifu.Dataviz.WinForms.BunifuDatavizBasic.DataPoint(Bunifu.Dataviz.WinForms.BunifuDatavizBasic._type.Bunifu_column);

            for (int i = 6; i >= 0; i--)
            {
                DateTime dt = DateTime.Today.AddDays(-i);
                datapoint.addLabely(dt.ToString("dd / MM"), Convert.ToString(BLL.BLL_Revenue.Instance.GetTongDoanhThu_NgayXuat(dt)));
            }


            canvas.addData(datapoint);
            bunifuDatavizBasic1.Render(canvas);


            var canvas1 = new Bunifu.Dataviz.WinForms.BunifuDatavizBasic.Canvas();
            var datapoint1 = new Bunifu.Dataviz.WinForms.BunifuDatavizBasic.DataPoint(Bunifu.Dataviz.WinForms.BunifuDatavizBasic._type.Bunifu_column);

            for (int i = 6; i >= 0; i--)
            {
                DateTime dt1 = DateTime.Today.AddDays(-i);
                datapoint1.addLabely(dt1.ToString("dd / MM"), Convert.ToString(BLL.BLL_Revenue.Instance.GetTongHoaDon_NgayXuat(dt1)));
            }
            canvas1.addData(datapoint1);
            bunifuDatavizBasic2.Render(canvas1);


            //Bunifu.DataViz.WinForms.Canvas canvas = new Bunifu.DataViz.WinForms.Canvas();
            //Bunifu.DataViz.WinForms.DataPoint data1 = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_column);
            //Bunifu.DataViz.WinForms.DataPoint data2 = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_column);
            //Bunifu.DataViz.WinForms.DataPoint data3 = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_column);

            //Random r = new Random();

            //for (int i = 1; i <= 12; i++)
            //{
            //    issued.addLabely(new DateTime(date.Value.Year, i, 1).ToString("MMM", CultureInfo.InvariantCulture), records.Where(b => b.IssueDate.Year == date.Value.Year && b.IssueDate.Month == i).Count());
            //    received.addLabely(new DateTime(date.Value.Year, i, 1).ToString("MMM", CultureInfo.InvariantCulture), records.Where(b => !b.isLost && b.ActualReturnDate.Value.Year == date.Value.Year && b.ActualReturnDate.Value.Month == i).Count());
            //    lost.addLabely(new DateTime(date.Value.Year, i, 1).ToString("MMM", CultureInfo.InvariantCulture), records.Where(b => b.isLost && b.ActualReturnDate.Value.Year == date.Value.Year && b.ActualReturnDate.Value.Month == i).Count());
            //}

            //canvas.addData(issued);
            //canvas.addData(received);
            //canvas.addData(lost);

            //chartYear.Render(canvas);


        }
        public void LoadTong()
        {
            List<DateTime?> listnx = BLL.BLL_Revenue.Instance.GetNgayXuat();

            DateTime today = DateTime.Now;
            double? tdt = 0;
            double? thd = 0;
            for (int i = 0; i <= listnx.Count - 1; i++)
            {
                int month = Convert.ToDateTime(listnx[i]).Month;
                int monthnow = today.Month;
                if (month == monthnow)
                {
                    //thd += BLL.BLL_Revenue.Instance.GetTongHoaDon_NgayXuat(Convert.ToDateTime(listnx[i]));
                    thd += 1;
                }
            }
            //tong tien
            for (int i = 0; i < listnx.Count - 1; i++)
            {
                if (listnx[i] == listnx[i + 1])
                {
                    continue;
                }
                else
                {
                    int month = Convert.ToDateTime(listnx[i]).Month;
                    int monthnow = today.Month;
                    if (month == monthnow)
                    {
                        tdt += BLL.BLL_Revenue.Instance.GetTongDoanhThuThang_NgayXuat(listnx[i]);
                        //thd += BLL.BLL_Revenue.Instance.GetTongHoaDon_NgayXuat(Convert.ToDateTime(listnx[i]));
                    }
                }
            }
            //bunifuLabel2.Text = Convert.ToString(tdt + BLL.BLL_Revenue.Instance.GetTongDoanhThuThang_NgayXuat(listnx[listnx.Count - 1])) + "VND";
            bunifuLabel2.Text = Convert.ToString(tdt) + "VND";
            bunifuLabel4.Text = Convert.ToString(thd);
        }
    }
}
