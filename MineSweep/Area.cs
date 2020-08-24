using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweep
{
    public partial class Area : UserControl
    {
        public delegate void AfterClickHandler(AreaStatus status);
        public event AfterClickHandler afterClick;
        public int ColIndex { get; }
        public int RowIndex { get; }
        public MineArea mineArea;
        public Area(int colIndex, int rowIndex)
        {
            InitializeComponent();
            ColIndex = colIndex;
            RowIndex = rowIndex;
            lbArea.MouseClick += LbArea_MouseClick;
        }
        public List<Area> Neighbours { get; set; }

        private void LbArea_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                mineArea.Click(true);
            }
            else
            {
                mineArea.Click(false);
            }
            afterClick(mineArea.status);
        }

        public void InitMineArea(bool isMine)
        {
            this.mineArea = new MineArea(isMine);
            this.mineArea.OnStatusChange += MineArea_OnStatusChange;
            this.mineArea.Area = this;
        }

        private void MineArea_OnStatusChange()
        {
            lbArea.BackColor = Color.AntiqueWhite;
            switch(mineArea.status)
            {
                case AreaStatus.block:lbArea.Text = string.Empty;lbArea.Image = null;break;
                case AreaStatus.boom: lbArea.Text = "🎃"; lbArea.Image = null; lbArea.BackColor = Color.Red; break;
                case AreaStatus.check: lbArea.Text = "🚩"; lbArea.Image = null; lbArea.BackColor = Color.CadetBlue; break;
                case AreaStatus.clear: lbArea.Text = mineArea.MineCount == 0?"":mineArea.MineCount.ToString(); lbArea.Image = null; break;
            }
        }


    }
    public class MineArea
    {
        public Area Area;
        public delegate void OnStatusChangeHandler();
        public event OnStatusChangeHandler OnStatusChange;
        public MineArea(bool isMine, MineArea[] neighbourMineAreas)
        {
            this.isMine = isMine;
            this._neighbourMineAreas = neighbourMineAreas;
        }
        public MineArea(bool isMine)
        {
            this.isMine = isMine;
        }
        public int Click(bool isRight)
        {
            if(isRight && status == AreaStatus.block)
            {
                this.status = AreaStatus.check;
            }
            else if(!isRight)
            {
                if(isMine)
                {
                    this.status = AreaStatus.boom;
                    return -1;
                }
                if(status == AreaStatus.block)
                {
                    Sweep();
                }
            }

            return 0;
        }
        public void Sweep()
        {
            if(status == AreaStatus.block && !isMine)
            {
                MineCount = GetNeighbourMineCount();
                status = AreaStatus.clear;
                if(MineCount == 0)
                {
                    for (int i = 0; i < neighbourMineAreas.Length; i++)
                    {
                        neighbourMineAreas[i].Sweep();
                    }
                }
            }
        }
        private int GetNeighbourMineCount()
        {
            int count = 0;
            for(int i = 0; i < neighbourMineAreas.Length; i++)
            {
                if (neighbourMineAreas[i].isMine)
                    count++;
            }
            return count;
        }

        private int _mineCount = 0;
        public int MineCount 
        { 
            get {
                return _mineCount;
            }
            private set
            {
                _mineCount = value;
                //OnStatusChange();
            }
        }

        public bool isMine { get; }
        bool isBoom { get; } = false;

        private MineArea[] _neighbourMineAreas;
        public MineArea[] neighbourMineAreas 
        { 
            get 
            {
                if (_neighbourMineAreas == null)
                    InitNeighbour();
                return _neighbourMineAreas;
            }  
        }
        void InitNeighbour()
        {
            _neighbourMineAreas = new MineArea[Area.Neighbours.Count];
            for(int i = 0; i < Area.Neighbours.Count; i++ )
            {
                _neighbourMineAreas[i] = Area.Neighbours[i].mineArea;
            }
        }

        private AreaStatus  _status = AreaStatus.block;
        public AreaStatus status
        {
            get
            {
                return _status;
            }
            private set
            {
                _status = value;
                OnStatusChange();
            }
        }
     

    }
    public enum AreaStatus
    {
        block,
        clear,
        boom,
        check
    }
}
