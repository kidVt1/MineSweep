using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweep
{
    public partial class Form1 : Form
    {
        List<List<Area>> areaList;
        List<Area> areaSet;
        int cols = 10;
        int rows = 10;
        int mineCount = 10;
        DateTime start;
        public Form1()
        {
            InitializeComponent();

            cmbLevel.SelectedIndex = 0;
        }

        private void AddAreas()
        {
            areaList = new List<List<Area>>();
            areaSet = new List<Area>(); ;
            int x = 0, y = 0;
            for (int i = 0; i < cols; i++)
            {
                x = 0; y = 30 * i;
                List<Area> list = new List<Area>();
                for (int j = 0; j < rows; j++)
                {
                    Area area = new Area(i,j);
                    area.Name = "area" + i + j;
                    area.Location = new Point(x, y);
                    area.afterClick += Area_OnStatusChange;
                    list.Add(area);
                    //this.mainContainer.Controls.Add(area);
                    areaSet.Add(area);
                    x += 30;
                }
                areaList.Add(list);
            }
            for(int i = 0; i < areaList.Count; i++)
            {
                for (int j = 0; j < areaList[i].Count; j++)
                    areaList[i][j].Neighbours = GetNeighbours(i, j);
            }
        }

        private void Area_OnStatusChange(AreaStatus status)
        {
            if(status == AreaStatus.boom)
            {
                timer1.Stop();
                for (int i = 0; i < areaSet.Count; i++)
                {
                    areaSet[i].mineArea.Click(false);
                }
                MessageBox.Show("you fail");               
            }
            else
            {
                int count = 0;
                for (int i = 0; i < areaSet.Count; i++)
                {
                    if (areaSet[i].mineArea.status == AreaStatus.block && !areaSet[i].mineArea.isMine)
                        count++;
                }
                if(count == 0)
                {
                    timer1.Stop();
                    for (int i = 0; i < areaSet.Count; i++)
                    {
                        if (areaSet[i].mineArea.status == AreaStatus.block && areaSet[i].mineArea.isMine)
                            areaSet[i].mineArea.Click(true);
                    }
                    MessageBox.Show("you success,total time:"+lbTimer.Text);
                }
            }
        }

        List<Area> GetNeighbours(int x,int y)
        {
            List<Area> res = new List<Area>();
            //leftTop
            if (x > 0 && y > 0)
                res.Add(areaList[x - 1][y - 1]);
            //top
            if (y > 0)
                res.Add(areaList[x][y - 1]);
            //rightTop
            if (x < cols - 1 && y > 0)
                res.Add(areaList[x + 1][y - 1]);
            //left
            if (x > 0)
                res.Add(areaList[x - 1][y]);
            //right
            if (x < cols - 1)
                res.Add(areaList[x + 1][y]);
            //leftBottom
            if (x > 0 && y < rows - 1)
                res.Add(areaList[x - 1][y + 1]);
            //bottom
            if (y < rows - 1)
                res.Add(areaList[x][y + 1]);
            //rightBottom
            if (x < cols - 1 && y < rows - 1)
                res.Add(areaList[x + 1][y + 1]);

            return res;
        }

        private void RandomLayMines()
        {
            if (areaList == null)
                return;
            int count = areaSet.Count;
            int[] ramdomArr = new int[count];
            for (int i = 0; i < mineCount; i++)
            {
                ramdomArr[i] = -1;
            }
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                int random = r.Next() % count;
                int temp = ramdomArr[i];
                ramdomArr[i] = ramdomArr[random];
                ramdomArr[random] = temp;
            }

            for(int i = 0; i < count; i++)
            {
                areaSet[i].InitMineArea(ramdomArr[i] == -1);
            }
            for (int i = 0; i < count; i++)
            {
                var a = areaSet[i].mineArea.neighbourMineAreas;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnRestart_Click(null, null);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            if (areaSet != null)
                areaSet.Clear();
            this.mainContainer.Controls.Clear();
            mainContainer.Visible = false;
            Task.Run(() => {
                AddAreas();
                RandomLayMines();
                start = DateTime.Now;
            });
            Task.Run(() =>
            {
                int i = 0;
                while (true)
                {
                    while(areaSet != null && areaSet.Count > i && i < cols*rows)
                    {
                        Area area = areaSet[i++];
                        BeginInvoke(new Action(()=> {

                            this.mainContainer.Controls.Add(area);
                        }));
                        Thread.Sleep(1);
                    }
                    if(i >= cols * rows)
                    {
                        BeginInvoke(new Action(() => {
                            if(mainContainer.Width < this.Width)
                            {
                                int x = (this.Width - mainContainer.Width) / 2;
                                mainContainer.Location = new Point(x, mainContainer.Location.Y);
                            }
                            else
                            {
                                mainContainer.Location = new Point(0, mainContainer.Location.Y);
                            }
                            mainContainer.Visible = true;
                            timer1.Start();
                        }));
                        
                        break;
                    }
                }
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTimer.Text = Math.Round((DateTime.Now - start).TotalSeconds,2).ToString();
        }

        private void cmbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbLevel.Text == "初级")
            {
                cols = 8;
                rows = 8;
                mineCount = 6;
            }
            else if(cmbLevel.Text == "中级")
            {
                cols = 10;
                rows = 10;
                mineCount = 10;
            }
            else if(cmbLevel.Text == "高级")
            {
                cols = 15;
                rows = 15;
                mineCount = 25;
            }
            else if (cmbLevel.Text == "极难")
            {
                cols = 20;
                rows = 20;
                mineCount = 50;
            }
            else if (cmbLevel.Text == "地狱")
            {
                cols = 20;
                rows = 30;
                mineCount = 100;
            }
        }
    }
}
