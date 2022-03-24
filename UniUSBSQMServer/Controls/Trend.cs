using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Configuration;

namespace UniUSBSQMServer
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class Trend : UserControl
    {

        private readonly SettingsManager settings;

        private readonly DataStore store;

        private  double trendMaximum = 30;
        private  double trendMinimum = 0;
        private  double _range = 30;

        private Bitmap? backgroundTrendRecord;
        private Bitmap? backgroundMasterTrend;

        private int drawVerticalMainDivisionCounter;
        private int drawVerticalSubDivisionCounter;
        private bool drawHorizontalBlankSubdivision;
        private int drawHorizontalBlankSubdivisionCounter;

        private bool autoScroll = true;     //Should trend scroll when DataPoint is added once trend width exceeds container

        private int lastPointRawMPas;       //Store the last draw points, used for drawing vertical lines on change between new and old.
        private int lastPointAvgMPas;
        private int lastPointTemp;
        private int lastPointNELM;
        private bool firstPointsDrawn = false;      //Once the first set of points draw we can start adding the additional joining verticals.

        //Local Buffer
        private List<DataStoreDataPoint> localBuffer = new();
        private bool updateInProgress = false;


        public Trend()
        {
            InitializeComponent();

            settings = SettingsManager.Instance;

            store = DataStore.Store;

            //Clear and prepare
            ClearCanvas();

            SetupTrend();

            //Attach events
            store.DataStoreRecordAdded += Store_DataStoreRecordAdded;
            store.DataStoreCleared += Store_DataStoreCleared;

            settings.SettingsChanged += Settings_SettingsChanged;
        }

        private void Settings_SettingsChanged(object? sender, EventArgs e)
        {
            SetupTrend();
            ClearCanvas();

            localBuffer.Clear();
            localBuffer = DataStore.GetAllData();

            UpdatePoints();
        }

        private void SetupTrend()
        {
            trendMaximum = Convert.ToDouble(SettingsManager.TrendMax);
            trendMinimum = Convert.ToDouble(SettingsManager.TrendMin);
            _range = trendMaximum - trendMinimum;

            checkBoxRawMPAS.Checked = SettingsManager.TrendDrawRawMPas;
            checkBoxAvgMPAS.Checked = SettingsManager.TrendDrawAvgMPas;
            checkBoxTemp.Checked = SettingsManager.TrendDrawTemp;
            checkBoxNELM.Checked = SettingsManager.TrendDrawNELM;

            checkBoxRawMPAS.ForeColor = SettingsManager.TrendRawMPasColor;
            checkBoxAvgMPAS.ForeColor = SettingsManager.TrendAvgMPasColor;
            checkBoxTemp.ForeColor = SettingsManager.TrendTempColor;
            checkBoxNELM.ForeColor = SettingsManager.TrendNELMColor;
        }


        private void ClearCanvas()
        {
            backgroundTrendRecord = null;
            backgroundMasterTrend = null;

            firstPointsDrawn = false;


            pictureBoxTrend.Width = 1;
            using Graphics gPen = pictureBoxPens.CreateGraphics();
            {
                gPen.Clear(pictureBoxTrend.BackColor);
            }

            //Horizontal sub division lines
            drawHorizontalBlankSubdivision = true;              //used to draw horiztonally dashed lines
            drawHorizontalBlankSubdivisionCounter = -1;         //

            //set the Main and sub counter to trigger first draw
            drawVerticalMainDivisionCounter = 51;
            drawVerticalSubDivisionCounter = 11;

            //No trend data - hide the labels
            labelMax.Visible = false;
            labelValue34.Visible = false;
            labelMid.Visible = false;
            labelValue14.Visible = false;
            labelMin.Visible = false;
        }

        private void Store_DataStoreCleared(object? sender, EventArgs e)
        {
            ClearCanvas();
        }

        private void Store_DataStoreRecordAdded(object? sender, EventArgs e)
        {
            //Add the new point to the buffer
            localBuffer.Add(DataStore.GetLatestRecord());

            //update point
            if (!updateInProgress)
            {
                UpdatePoints();
            }
        }

        private void UpdatePoints()
        {
            updateInProgress = true;
            
            while (localBuffer.Count > 0)
            {

                if (backgroundTrendRecord == null)
                {
                    backgroundTrendRecord = new(1, pictureBoxTrend.Height);

                    //Trend Starting, so show the labels
                    labelMax.Visible = true;
                    labelValue34.Visible = true;
                    labelMid.Visible = true;
                    labelValue14.Visible = true;
                    labelMin.Visible = true;
                }

                //set the background color
                for (int i = 0; i < backgroundTrendRecord.Height; i++)
                {
                    backgroundTrendRecord.SetPixel(0, i, pictureBoxTrend.BackColor);
                }

                //Draw background trend lines
                //int mainInterval = backgroundTrendRecord.Height / 4;
                //int subInterval = backgroundTrendRecord.Height / 40;
                double subInterval = backgroundTrendRecord.Height / 20.0;

                //increment the horizontal dash counter
                drawHorizontalBlankSubdivisionCounter++;
                if (drawHorizontalBlankSubdivisionCounter > 9)
                {
                    drawHorizontalBlankSubdivision = !drawHorizontalBlankSubdivision;
                    drawHorizontalBlankSubdivisionCounter = 0;
                }

                for (double position = 0; position < backgroundTrendRecord.Height; position += subInterval)
                {
                    if (position < backgroundTrendRecord.Height)
                    {
                        backgroundTrendRecord.SetPixel(0, Convert.ToInt32(position), Color.FromKnownColor(KnownColor.LightGray));
                    }
                }

                //Main

                //increment the 2 vertical position counters.
                drawVerticalSubDivisionCounter++;
                drawVerticalMainDivisionCounter++;

                if (drawVerticalSubDivisionCounter > 9)
                {
                    for (int outer = 0; outer < backgroundTrendRecord.Height; outer++)
                    {
                        backgroundTrendRecord.SetPixel(0, outer, Color.FromKnownColor(KnownColor.LightGray));
                    }
                    drawVerticalSubDivisionCounter = 0;
                }

                if (drawVerticalMainDivisionCounter > 49)
                {
                    for (int i = 0; i < backgroundTrendRecord.Height; i++)
                    {
                        backgroundTrendRecord.SetPixel(0, i, Color.FromKnownColor(KnownColor.Black));
                    }
                    drawVerticalMainDivisionCounter = 0;
                }

                //Main Division Horizontal lines
                backgroundTrendRecord.SetPixel(0, 0, Color.FromKnownColor(KnownColor.Black));
                backgroundTrendRecord.SetPixel(0, Convert.ToInt32(subInterval * 5), Color.FromKnownColor(KnownColor.Black));
                backgroundTrendRecord.SetPixel(0, Convert.ToInt32(subInterval * 10), Color.FromKnownColor(KnownColor.Black));
                backgroundTrendRecord.SetPixel(0, Convert.ToInt32(subInterval * 15), Color.FromKnownColor(KnownColor.Black));
                backgroundTrendRecord.SetPixel(0, backgroundTrendRecord.Height - 1, Color.FromKnownColor(KnownColor.Black));


                //Draw DataPoints
                DataStoreDataPoint data = localBuffer.First();

                int y;

                int penRaw = 0;     //Store the y for each point as will reuse later for drawing the Pen Markers
                int penAvg = 0;
                int penTemp = 0;
                int penNELM = 0;

                //Draw the datapoints - Draw the least priority first for overlap
                if (checkBoxTemp.Checked)
                {
                    if (SettingsManager.TemperatureUnits == Enums.TemperatureUnits.Centrigrade)
                    {
                        y = backgroundTrendRecord.Height - (Convert.ToInt32(data.AvgTemp / (trendMaximum - trendMinimum) * backgroundTrendRecord.Height));
                    }
                    else
                    {
                        y = backgroundTrendRecord.Height - (Convert.ToInt32(Utility.ConvertTempCtoF(data.AvgTemp) / (trendMaximum - trendMinimum) * backgroundTrendRecord.Height));
                    }
                    if (y < 0) { y = 0; } else if (y >= pictureBoxTrend.Height) { y = pictureBoxTrend.Height - 1; }
                    backgroundTrendRecord.SetPixel(0, y, checkBoxTemp.ForeColor);

                    penTemp = y;

                    //Vertical Joins
                    if (firstPointsDrawn && y != lastPointTemp)
                    {
                        if (lastPointTemp > y)
                        {
                            for (int pos = lastPointTemp; pos > y; pos--)
                            {
                                backgroundTrendRecord.SetPixel(0, pos, checkBoxTemp.ForeColor);
                            }
                        }
                        else
                        {
                            for (int pos = lastPointTemp; pos < y; pos++)
                            {
                                backgroundTrendRecord.SetPixel(0, pos, checkBoxTemp.ForeColor);
                            }
                        }
                    }

                    lastPointTemp = y;
                }

                if (checkBoxNELM.Checked)
                {
                    y = backgroundTrendRecord.Height - (Convert.ToInt32(data.NELM / (trendMaximum - trendMinimum) * backgroundTrendRecord.Height));
                    if (y < 0) { y = 0; } else if (y >= pictureBoxTrend.Height) { y = pictureBoxTrend.Height - 1; }
                    backgroundTrendRecord.SetPixel(0, y, checkBoxNELM.ForeColor);

                    penNELM = y;
                    //Vertical Joins
                    if (firstPointsDrawn && y != lastPointNELM)
                    {
                        if (lastPointNELM > y)
                        {
                            for (int pos = lastPointNELM; pos > y; pos--)
                            {
                                backgroundTrendRecord.SetPixel(0, pos, checkBoxNELM.ForeColor);
                            }
                        }
                        else
                        {
                            for (int pos = lastPointNELM; pos < y; pos++)
                            {
                                backgroundTrendRecord.SetPixel(0, pos, checkBoxNELM.ForeColor);
                            }
                        }
                    }
                    lastPointNELM = y;

                }

                if (checkBoxRawMPAS.Checked)
                {
                    y = backgroundTrendRecord.Height - (Convert.ToInt32(data.RawMPAS / (trendMaximum - trendMinimum) * backgroundTrendRecord.Height));
                    if (y < 0) { y = 0; } else if (y >= pictureBoxTrend.Height) { y = pictureBoxTrend.Height - 1; }
                    backgroundTrendRecord.SetPixel(0, y, checkBoxRawMPAS.ForeColor);

                    penRaw = y;
                    //Vertical Joins
                    if (firstPointsDrawn && y != lastPointRawMPas)
                    {
                        if (lastPointRawMPas > y)
                        {
                            for (int pos = lastPointRawMPas; pos > y; pos--)
                            {
                                backgroundTrendRecord.SetPixel(0, pos, checkBoxRawMPAS.ForeColor);
                            }
                        }
                        else
                        {
                            for (int pos = lastPointRawMPas; pos < y; pos++)
                            {
                                backgroundTrendRecord.SetPixel(0, pos, checkBoxRawMPAS.ForeColor);
                            }
                        }
                    }
                    lastPointRawMPas = y;
                }

                if (checkBoxAvgMPAS.Checked)
                {
                    y = backgroundTrendRecord.Height - (Convert.ToInt32(data.AvgMPAS / (trendMaximum - trendMinimum) * backgroundTrendRecord.Height));
                    if (y < 0) { y = 0; } else if (y >= pictureBoxTrend.Height) { y = pictureBoxTrend.Height - 1; }
                    backgroundTrendRecord.SetPixel(0, y, checkBoxAvgMPAS.ForeColor);

                    penAvg = y;
                    //Vertical Joins
                    if (firstPointsDrawn && y != lastPointAvgMPas)
                    {
                        if (lastPointAvgMPas > y)
                        {
                            for (int pos = lastPointAvgMPas; pos > y; pos--)
                            {
                                backgroundTrendRecord.SetPixel(0, pos, checkBoxAvgMPAS.ForeColor);
                            }
                        }
                        else
                        {
                            for (int pos = lastPointAvgMPas; pos < y; pos++)
                            {
                                backgroundTrendRecord.SetPixel(0, pos, checkBoxAvgMPAS.ForeColor);
                            }
                        }
                    }
                    lastPointAvgMPas = y;
                }

                firstPointsDrawn = true;    //Allow the vertical joins to be added the next update.

                //Join the trend record to the master background trend, check its size if needed
                if (backgroundMasterTrend == null)
                {
                    backgroundMasterTrend = new (1, pictureBoxTrend.Height);
                }
                else
                {
                    //Check if there is a logging limit and crop the mastertrend accordingly
                    if (!SettingsManager.MemoryLoggingNoLimit && backgroundMasterTrend.Width > SettingsManager.MemoryLoggingRecordLimit)
                    {
                        Bitmap newBitmap = new (SettingsManager.MemoryLoggingRecordLimit, backgroundMasterTrend.Height);
                        using (Graphics gNew = Graphics.FromImage(newBitmap))
                        {
                            Rectangle cloneRect = new (backgroundMasterTrend.Width - SettingsManager.MemoryLoggingRecordLimit, 0, SettingsManager.MemoryLoggingRecordLimit, backgroundMasterTrend.Height);
                            Bitmap clone = backgroundMasterTrend.Clone(cloneRect, backgroundMasterTrend.PixelFormat);

                            gNew.DrawImage(clone, 0, 0);
                        }
                        backgroundMasterTrend = newBitmap;
                    }
                }

                Bitmap bitmap = new (backgroundMasterTrend.Width + backgroundTrendRecord.Width, Math.Max(backgroundMasterTrend.Height, backgroundTrendRecord.Height));
                using Graphics g = Graphics.FromImage(bitmap);
                {
                    g.DrawImage(backgroundMasterTrend, 0, 0);
                    g.DrawImage(backgroundTrendRecord, backgroundMasterTrend.Width, 0);
                }
                backgroundMasterTrend = bitmap;

                //draw the new bitmap into the picturebox
                pictureBoxTrend.Width = backgroundMasterTrend.Width;
                pictureBoxTrend.Image = backgroundMasterTrend;

                if (pictureBoxTrend.Width > (this.Width - pictureBoxPens.Width))
                {
                    buttonRunStop.Visible = true;
                    horizontalTrendScroll.Maximum = pictureBoxTrend.Width - this.Width + pictureBoxPens.Width;  //increase the maximum on the scroll bar
                    if (autoScroll)
                    {
                        horizontalTrendScroll.Value = horizontalTrendScroll.Maximum;
                        pictureBoxTrend.Left = pictureBoxPens.Left - pictureBoxTrend.Width;     //shift the picturebox left, so latest data is visible
                    }
                    else
                    {
                        pictureBoxTrend.Left = horizontalTrendScroll.Value * -1;
                    }
                }
                else
                {
                    buttonRunStop.Visible = false;
                    horizontalTrendScroll.Enabled = false;
                    horizontalTrendScroll.Maximum = 0;
                    pictureBoxTrend.Left = this.Width - pictureBoxTrend.Width - pictureBoxPens.Width;
                }
                if (autoScroll)
                {
                    buttonRunStop.Text = "\u23F8"; //Pause
                }
                else
                {
                    buttonRunStop.Text = "\u23F5"; //Run
                }

                pictureBoxTrend.Refresh();


                //Draw the Pen Markers
                using Graphics gPen = pictureBoxPens.CreateGraphics();
                {
                    gPen.Clear(pictureBoxTrend.BackColor);
                    //Draw them in this order for overlap priority
                    if (checkBoxTemp.Checked)
                    {
                        Point[] points = { new Point(0, penTemp), new Point(15, penTemp - 4), new Point(15, penTemp + 4) };
                        gPen.FillPolygon(new SolidBrush(checkBoxTemp.ForeColor), points);
                    }
                    if (checkBoxNELM.Checked)
                    {
                        Point[] points = { new Point(0, penNELM), new Point(15, penNELM - 4), new Point(15, penNELM + 4) };
                        gPen.FillPolygon(new SolidBrush(checkBoxNELM.ForeColor), points);
                    }
                    if (checkBoxRawMPAS.Checked)
                    {
                        Point[] points = { new Point(0, penRaw), new Point(15, penRaw - 4), new Point(15, penRaw + 4) };
                        gPen.FillPolygon(new SolidBrush(checkBoxRawMPAS.ForeColor), points);
                    }
                    if (checkBoxAvgMPAS.Checked)
                    {
                        Point[] points = { new Point(0, penAvg), new Point(15, penAvg - 4), new Point(15, penAvg + 4) };
                        gPen.FillPolygon(new SolidBrush(checkBoxAvgMPAS.ForeColor), points);
                    }
                }

                //remove the updated point from buffer
                localBuffer.RemoveAt(0);
            }

            updateInProgress = false;
        }

        private void HorizontalTrendScroll_Scroll(object sender, ScrollEventArgs e)
        {
            pictureBoxTrend.Left = horizontalTrendScroll.Value * -1;

        }

        private void Trend_Layout(object sender, LayoutEventArgs e)
        {
            //Main Trend
            pictureBoxTrend.Height = this.Height - pictureBoxTrend.Top - horizontalTrendScroll.Height;
            horizontalTrendScroll.Top = this.Height - horizontalTrendScroll.Height;
            horizontalTrendScroll.Width = this.Width;

            //Pen Markers
            pictureBoxPens.Height = pictureBoxTrend.Height;
            pictureBoxPens.Left = this.Width - pictureBoxPens.Width;


            //Set the trend label values
            labelMax.Text = trendMaximum.ToString();
            labelValue34.Text = ((_range / 4.0) * 3.0).ToString("#0.0"); //divide by 4.0 and not 4 so keep all math operations on same data type
            labelMid.Text = (_range / 2.0).ToString("#0.0");
            labelValue14.Text = (_range / 4.0).ToString("#0.0");
            labelMin.Text = trendMinimum.ToString();

            //determine left for each Max/Mid/Min label
            int posLeft;

            labelMax.Top = pictureBoxTrend.Top;
            posLeft = pictureBoxTrend.Left - labelMax.Width;
            if (posLeft < 0) { labelMax.Left = 0; } else { labelMax.Left = posLeft;}

            labelValue34.Top = pictureBoxTrend.Top + (pictureBoxTrend.Height / 4) - (labelValue34.Height/2);
            posLeft = pictureBoxTrend.Left - labelValue34.Width;
            if (posLeft < 0) { labelValue34.Left = 0; } else { labelValue34.Left = posLeft; }

            labelMid.Top = pictureBoxTrend.Top + (pictureBoxTrend.Height/2) - (labelMid.Height / 2);
            posLeft = pictureBoxTrend.Left - labelMid.Width;
            if (posLeft <0) { labelMid.Left = 0; } else { labelMid.Left = posLeft;}

            labelValue14.Top = pictureBoxTrend.Top + ((pictureBoxTrend.Height / 4)*3) - (labelValue34.Height / 2);
            posLeft = pictureBoxTrend.Left - labelValue14.Width;
            if (posLeft < 0) { labelValue14.Left = 0; } else { labelValue14.Left = posLeft; }

            labelMin.Top = horizontalTrendScroll.Top - labelMin.Height;
            posLeft = pictureBoxTrend.Left - labelMin.Width;
            if (posLeft < 0) { labelMin.Left = 0; } else { labelMin.Left = posLeft;}

        }

        private void ButtonRunStop_Click(object sender, EventArgs e)
        {
            autoScroll = !autoScroll;
            if (autoScroll)
            {
                horizontalTrendScroll.Enabled = false;
                buttonRunStop.Text = "\u23F8"; //Pause
            }
            else
            {
                horizontalTrendScroll.Enabled = true;
                buttonRunStop.Text = "\u23F5"; //Run
            }
        }
    }
}
