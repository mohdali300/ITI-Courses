using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms.DataVisualization.Charting;

namespace Day7_WinForms
{
    public partial class Form1 : Form
    {
        string[,] TableData = new string[,]
        {
        { "Year", "Revenue"},
        { "1988", "150"},
        { "1989", "170"},
        { "1990", "180"},
        { "1991", "175"},
        { "1992", "200"},
        { "1993", "250"},
        { "1994", "210"},
        { "1995", "240"},
        { "1996", "280"},
        { "1997", "140"},
        };

        int chartX = 250;
        int chartY = 250;
        int chartWidth = 600;
        int chartHeight = 500;

        Color lineColor = Color.Blue;
        Rectangle[] pointAreas;
        Rectangle[] barAreas;
        string[] years;
        int[] revenues;


        public Form1()
        {
            InitializeComponent();

            this.Paint += Form1_Paint;
            this.MouseClick += Form1_MouseClick;
            this.KeyDown += Form1_KeyDown;
            this.KeyPreview = true;

            int dataCount = TableData.GetLength(0) - 1;
            years = new string[dataCount];
            revenues = new int[dataCount];
            pointAreas = new Rectangle[dataCount];
            barAreas = new Rectangle[dataCount];

            for (int i = 0; i < dataCount; i++)
            {
                years[i] = TableData[i + 1, 0];
                revenues[i] = int.Parse(TableData[i + 1, 1]);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            DrawTitle(g);
            DrawTable(g);
            DrawChart(g);
        }

        void DrawTitle(Graphics g)
        {
            string CompanyName = "ABC Company";
            string ReportTitle = "Annual Revenue";

            Font titleFont = new Font("Arial", 24, FontStyle.Bold);
            Brush titleBrush = new SolidBrush(Color.Blue);
            Brush reportBrush = new SolidBrush(Color.Chocolate);
            StringFormat titleFormat = new StringFormat();
            titleFormat.Alignment = StringAlignment.Center;
            titleFormat.LineAlignment = StringAlignment.Center;
            var titleX = (this.ClientSize.Width - titleFont.Size) / 2;
            var titleY = 50;

            g.DrawString(CompanyName, titleFont, titleBrush, titleX, titleY, titleFormat);
            g.DrawString(ReportTitle, titleFont, reportBrush, titleX, titleY + 70, titleFormat);
        }

        void DrawTable(Graphics g)
        {
            int startX = this.ClientSize.Width - 700;
            int startY = 250;
            int cellWidth = 180;
            int cellHeight = 60;
            int rows = TableData.GetLength(0);
            int cols = TableData.GetLength(1);

            Pen borderPen = new Pen(Color.Black, 2);
            Brush headerBrush = new SolidBrush(Color.AliceBlue);
            Brush textBrush = new SolidBrush(Color.Black);
            Font font = new Font("Arial", 14);
            Font headerFont = new Font("Arial", 16, FontStyle.Bold);


            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Rectangle cellRect = new Rectangle(
                        startX + (col * cellWidth),
                        startY + (row * cellHeight),
                        cellWidth,
                        cellHeight
                    );

                    if (row == 0)
                    {
                        g.FillRectangle(headerBrush, cellRect);
                    }

                    g.DrawRectangle(borderPen, cellRect);

                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;

                    g.DrawString(
                        TableData[row, col],
                        row == 0 ? headerFont : font,
                        textBrush,
                        cellRect,
                        format
                    );
                }
            }

            borderPen.Dispose();
            headerBrush.Dispose();
            textBrush.Dispose();
            font.Dispose();
            headerFont.Dispose();
        }

        private void DrawChart(Graphics g)
        {
            int dataCount = years.Length;

            int maxRevenue = 0;
            foreach (int rev in revenues)
            {
                if (rev > maxRevenue) maxRevenue = rev;
            }
            maxRevenue = ((maxRevenue / 50) + 1) * 50;

            Brush bgBrush = new SolidBrush(Color.White);
            Pen borderPen = new Pen(Color.Black, 2);
            g.DrawRectangle(borderPen, chartX, chartY, chartWidth, chartHeight);
            g.FillRectangle(bgBrush, chartX, chartY, chartWidth, chartHeight);

            { // y axis
                Font labelFont = new Font("Arial", 9);
                Brush labelBrush = new SolidBrush(Color.Black);

                int gridLines = 5;
                for (int i = 0; i <= gridLines; i++)
                {
                    int y = chartY + chartHeight - (i * chartHeight / gridLines);

                    int value = (maxRevenue * i) / gridLines;
                    g.DrawString(value.ToString(), labelFont, labelBrush, chartX - 40, y - 7);
                }
            }

            int barWidth = (chartWidth - 100) / dataCount;
            int barSpacing = barWidth / 4;
            int actualBarWidth = barWidth - barSpacing;

            { // bar
                Pen barPen = new Pen(Color.DarkRed, 1);
                HatchBrush barBrush = new HatchBrush(HatchStyle.ForwardDiagonal, Color.Red, Color.LightCoral);
                for (int i = 0; i < dataCount; i++)
                {
                    int barHeight = (int)((double)revenues[i] / maxRevenue * chartHeight);
                    int x = chartX + 50 + (i * barWidth);
                    int y = chartY + chartHeight - barHeight;

                    Rectangle barRect = new Rectangle(x, y, actualBarWidth, barHeight);
                    barAreas[i]=barRect;

                    g.FillRectangle(barBrush, barRect);
                    g.DrawRectangle(barPen, barRect);
                }
            }

            { // line
                Pen linePen = new Pen(lineColor, 3);
                Brush pointBrush = new SolidBrush(lineColor);

                PointF[] points = new PointF[dataCount];
                for (int i = 0; i < dataCount; i++)
                {
                    int lineHeight = (int)((double)revenues[i] / maxRevenue * chartHeight);
                    float x = chartX + 50 + (i * barWidth) + (actualBarWidth / 2);
                    float y = chartY + chartHeight - lineHeight;
                    points[i] = new PointF(x, y);

                    int clickRadius = 10;
                    pointAreas[i] = new Rectangle(
                        (int)x - clickRadius,
                        (int)y - clickRadius,
                        clickRadius * 2,
                        clickRadius * 2
                    );
                }

                g.DrawLines(linePen, points);

                foreach (PointF point in points)
                {
                    g.FillEllipse(pointBrush, point.X - 4, point.Y - 4, 8, 8);
                    g.DrawEllipse(Pens.White, point.X - 4, point.Y - 4, 8, 8);
                }
            }

            { // x axis
                Font yearFont = new Font("Arial", 9);
                Brush yearBrush = new SolidBrush(Color.Black);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;

                for (int i = 0; i < dataCount; i++)
                {
                    float x = chartX + 50 + (i * barWidth) + (actualBarWidth / 2);
                    float y = chartY + chartHeight + 10;
                    g.DrawString(years[i], yearFont, yearBrush, x, y, format);
                }
            }

            { // labels
                Font axisFont = new Font("Arial", 12, FontStyle.Bold);
                Brush axisBrush = new SolidBrush(Color.Black);

                StringFormat yFormat = new StringFormat();
                yFormat.Alignment = StringAlignment.Center;
                g.TranslateTransform(20, chartY + chartHeight / 2);
                g.RotateTransform(-90);
                g.DrawString("Revenue", axisFont, axisBrush, 0, 150, yFormat);
                g.ResetTransform();

                StringFormat xFormat = new StringFormat();
                xFormat.Alignment = StringAlignment.Center;
                g.DrawString("Year", axisFont, axisBrush, chartX + chartWidth / 2, chartY + chartHeight + 40, xFormat);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                lineColor = Color.Red;
                this.Invalidate();
                e.Handled = true;
            }

            else if (e.Control && e.KeyCode == Keys.G)
            {
                lineColor = Color.Green;
                this.Invalidate();
                e.Handled = true;
            }

            else if (e.Control && e.KeyCode == Keys.B)
            {
                lineColor = Color.Blue;
                this.Invalidate();
                e.Handled = true;
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rectangle chartArea = new Rectangle(chartX, chartY, chartWidth, chartHeight);

                if (chartArea.Contains(e.Location))
                {
                    for (int i = 0; i < pointAreas.Length; i++)
                    {
                        if (pointAreas[i].Contains(e.Location))
                        {
                            MessageBox.Show(
                                $"Year: {years[i]}\nRevenue: {revenues[i]}",
                                "Data Point Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                            return;
                        }
                    }

                    for (int i = 0; i < barAreas.Length; i++)
                    {
                        if (barAreas[i].Contains(e.Location))
                        {
                            MessageBox.Show(
                                $"Year: {years[i]}\nRevenue: {revenues[i]}",
                                "Bar Chart Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                            return;
                        }
                    }
                }
            }
        }
    }
}
